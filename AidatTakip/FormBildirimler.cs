using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AidatTakip.SmtpAyar;

namespace AidatTakip
{
    public partial class FormBildirimler : Form
    {
        private CancellationTokenSource _cts;

        public FormBildirimler()
        {
            InitializeComponent();

            // Designer bazı event’leri bağlamıyor → burada açıkça bağla
            this.Load += FormBildirimler_Load;
            btnListele.Click += (s, e) => Listele();
            btnAyarlar.Click += (s, e) => AcAyarlar();

            // Designer genelde btnGonder’e bağlı; yine de idempotent bağlayalım
            btnGonder.Click -= btnGonder_Click;
            btnGonder.Click += btnGonder_Click;

            // Grid görünümleri
            gridBorclular.MultiSelect = true;
            gridBorclular.ReadOnly = true;
            gridBorclular.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridBorclular.AllowUserToAddRows = false;
            gridBorclular.AllowUserToDeleteRows = false;
            gridBorclular.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gridLog.ReadOnly = true;
            gridLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridLog.AllowUserToAddRows = false;
            gridLog.AllowUserToDeleteRows = false;
            gridLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormBildirimler_Load(object sender, EventArgs e)
        {
            // Yıl/Ay comboları
            int yil = DateTime.Now.Year;
            cmbYil.Items.Clear();
            for (int y = yil - 2; y <= yil + 2; y++) cmbYil.Items.Add(y);
            cmbYil.SelectedItem = yil;

            cmbAy.Items.Clear();
            for (int a = 1; a <= 12; a++) cmbAy.Items.Add(a);
            cmbAy.SelectedItem = DateTime.Now.Month;

            chkSadeceEmailiOlanlar.Checked = true;

            // Varsayılan şablon
            txtKonu.Text = "Aidat Hatırlatma - {Yil}/{Ay}";
            txtGovde.Text =
@"Sayın {AdSoyad},

{Yil}/{Ay} dönemine ait aidat borcunuz: {Kalan} TL'dir.
Blok/Daire: {Blok}/{DaireNo}
Toplam: {Tutar}  Ödenen: {Odenen}  Kalan: {Kalan}

İyi günler dileriz.";

            // İlk listeleme
            Listele();
        }

        private void Listele()
        {
            // Yıl ve ay seçili mi?
            if (!int.TryParse(Convert.ToString(cmbYil.SelectedItem), out int yil) ||
                !int.TryParse(Convert.ToString(cmbAy.SelectedItem), out int ay))
            {
                MessageBox.Show("Lütfen yıl ve ay seçin.");
                return;
            }

            const string sql = @"
SELECT 
    u.UyeId,
    u.AdSoyad,
    u.Blok,
    u.DaireNo,
    u.Email,
    a.Yil,
    a.Ay,
    a.Tutar AS Tutar,
    ISNULL(SUM(o.Tutar), 0) AS Odenen,
    (a.Tutar - ISNULL(SUM(o.Tutar), 0)) AS Kalan
FROM Aidatlar a
JOIN Uyeler u          ON u.UyeId = a.UyeId
LEFT JOIN Odemeler o   ON o.AidatId = a.AidatId
WHERE a.Yil = @Y AND a.Ay = @A
GROUP BY u.UyeId, u.AdSoyad, u.Blok, u.DaireNo, u.Email, a.Yil, a.Ay, a.Tutar
HAVING (a.Tutar - ISNULL(SUM(o.Tutar), 0)) > 0
ORDER BY Kalan DESC, u.Blok, u.DaireNo;";

            DataTable dt = Veritabani.Query(sql,
                new SqlParameter("@Y", yil),
                new SqlParameter("@A", ay));

            // E-postası olmayanları filtrele (isteğe bağlı)
            if (chkSadeceEmailiOlanlar.Checked)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    var emailObj = dt.Rows[i]["Email"];
                    string email = emailObj == DBNull.Value ? "" : Convert.ToString(emailObj);
                    if (string.IsNullOrWhiteSpace(email))
                        dt.Rows.RemoveAt(i);
                }
                dt.AcceptChanges();
            }

            // Grid’e bas
            gridBorclular.DataSource = dt;

            // Başlıkları düzenle
            if (gridBorclular.Columns.Contains("AdSoyad")) gridBorclular.Columns["AdSoyad"].HeaderText = "Ad Soyad";
            if (gridBorclular.Columns.Contains("DaireNo")) gridBorclular.Columns["DaireNo"].HeaderText = "Daire No";
            if (gridBorclular.Columns.Contains("Tutar")) gridBorclular.Columns["Tutar"].HeaderText = "Aidat Tutarı";
            if (gridBorclular.Columns.Contains("Odenen")) gridBorclular.Columns["Odenen"].HeaderText = "Ödenen";
            if (gridBorclular.Columns.Contains("Kalan")) gridBorclular.Columns["Kalan"].HeaderText = "Kalan";

            // Para kolonları için format
            if (gridBorclular.Columns.Contains("Tutar")) gridBorclular.Columns["Tutar"].DefaultCellStyle.Format = "N2";
            if (gridBorclular.Columns.Contains("Odenen")) gridBorclular.Columns["Odenen"].DefaultCellStyle.Format = "N2";
            if (gridBorclular.Columns.Contains("Kalan")) gridBorclular.Columns["Kalan"].DefaultCellStyle.Format = "N2";
        }


        private void SetHeaderText(DataGridView grid, string colName, string header)
        {
            if (grid.Columns.Contains(colName))
                grid.Columns[colName].HeaderText = header;
        }

        private void SetMoneyFormat(DataGridView grid, string colName)
        {
            if (grid.Columns.Contains(colName))
                grid.Columns[colName].DefaultCellStyle.Format = "N2";
        }

        private void AcAyarlar()
        {
            try
            {
                using (var f = new FormAyarlar())
                    f.ShowDialog(this);
            }
            catch
            {
                MessageBox.Show("Ayarlar ekranı henüz yok. SMTP anahtarlarını Ayarlar tablosunda düzenleyin.");
            }
        }

        private async void btnGonder_Click(object sender, EventArgs e)
        {
            // Satır yoksa
            if (gridBorclular.DataSource == null || ((DataTable)gridBorclular.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("Gönderilecek kayıt yok. Önce listeleyin.");
                return;
            }

            // SMTP ayarlarını al
            SmtpAyar smtp;
            try { smtp = AyarDepo.GetSmtpAyar(); }
            catch (Exception ex)
            {
                MessageBox.Show("SMTP ayarları eksik: " + ex.Message);
                return;
            }

            // Seçim yoksa hepsini seç
            if (gridBorclular.SelectedRows.Count == 0)
                gridBorclular.SelectAll();
            if (gridBorclular.SelectedRows.Count == 0)
            {
                MessageBox.Show("Gönderim için satır seçiniz.");
                return;
            }

            // İptal token'ı
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            ToggleUi(false);
            ClearOrInitLog();

            int basarili = 0, hatali = 0;

            try
            {
                foreach (DataGridViewRow row in gridBorclular.SelectedRows)
                {
                    token.ThrowIfCancellationRequested();

                    // Güvenli hücre okuma
                    string email = SafeStr(row, "Email");
                    string ad = SafeStr(row, "AdSoyad");
                    string blok = SafeStr(row, "Blok");
                    string daire = SafeStr(row, "DaireNo");
                    int yil = SafeInt(row, "Yil");
                    int ay = SafeInt(row, "Ay");
                    decimal tutar = SafeDec(row, "Tutar");
                    decimal odenen = SafeDec(row, "Odenen");
                    decimal kalan = SafeDec(row, "Kalan");

                    if (string.IsNullOrWhiteSpace(email))
                    {
                        AppendLog("(boş)", "Atlandı", "Email yok");
                        hatali++;
                        continue;
                    }

                    var map = new Dictionary<string, string>
                    {
                        ["AdSoyad"] = ad,
                        ["Blok"] = blok,
                        ["DaireNo"] = daire,
                        ["Yil"] = yil.ToString(),
                        ["Ay"] = ay.ToString(),
                        ["Tutar"] = tutar.ToString("N2"),
                        ["Odenen"] = odenen.ToString("N2"),
                        ["Kalan"] = kalan.ToString("N2"),
                    };

                    string konu = SablonMotoru.Doldur(txtKonu.Text, map) ?? "";
                    string govde = SablonMotoru.Doldur(txtGovde.Text, map) ?? "";

                    try
                    {
                        // EpostaGonderici.Gonder içinde UTF-8 ve (gerekirse) IsBodyHtml=true olmasını öneririm
                        await Task.Run(() => EpostaGonderici.Gonder(smtp, email, konu, govde /*, isHtml:false*/), token);
                        AppendLog(email, "Başarılı", "-");
                        basarili++;
                    }
                    catch (Exception exSatir)
                    {
                        AppendLog(email, "Hata", exSatir.Message);
                        hatali++;
                    }
                }

                MessageBox.Show($"Gönderim tamamlandı. Başarılı: {basarili}, Hatalı: {hatali}");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Gönderim iptal edildi.");
            }
            finally
            {
                ToggleUi(true);
            }
        }

        // (İstersen bir "İptal" butonu ekleyip buna bağlayabilirsin)
        private void CancelSend()
        {
            _cts?.Cancel();
        }

        private void ToggleUi(bool enabled)
        {
            btnListele.Enabled = enabled;
            btnGonder.Enabled = enabled;
            btnAyarlar.Enabled = enabled;
            cmbYil.Enabled = enabled;
            cmbAy.Enabled = enabled;
            chkSadeceEmailiOlanlar.Enabled = enabled;
        }

        private void ClearOrInitLog()
        {
            if (gridLog.DataSource == null)
            {
                var dt = new DataTable();
                dt.Columns.Add("Tarih", typeof(DateTime));
                dt.Columns.Add("Alici", typeof(string));
                dt.Columns.Add("Sonuc", typeof(string));
                dt.Columns.Add("Hata", typeof(string));
                gridLog.DataSource = dt;
            }
            else
            {
                ((DataTable)gridLog.DataSource).Rows.Clear();
                ((DataTable)gridLog.DataSource).AcceptChanges();
            }
        }

        private void AppendLog(string alici, string sonuc, string hata)
        {
            if (InvokeRequired) { BeginInvoke(new Action(() => AppendLog(alici, sonuc, hata))); return; }

            var table = (DataTable)gridLog.DataSource;
            var r = table.NewRow();
            r["Tarih"] = DateTime.Now;
            r["Alici"] = alici;
            r["Sonuc"] = sonuc;
            r["Hata"] = hata ?? "-";
            table.Rows.Add(r);
            table.AcceptChanges();
        }

        private static string SafeStr(DataGridViewRow row, string col)
        {
            try { return Convert.ToString(row.Cells[col].Value); }
            catch { return ""; }
        }

        private static int SafeInt(DataGridViewRow row, string col)
        {
            try { return Convert.ToInt32(row.Cells[col].Value); }
            catch { return 0; }
        }

        private static decimal SafeDec(DataGridViewRow row, string col)
        {
            try
            {
                var v = row.Cells[col].Value;
                if (v == null || v == DBNull.Value) return 0m;
                return Convert.ToDecimal(v);
            }
            catch { return 0m; }
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {

        }
    }
}
