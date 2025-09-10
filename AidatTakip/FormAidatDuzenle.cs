using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AidatTakip
{
    public partial class FormAidatDuzenle : Form
    {
        private readonly int? _aidatId;

        // Yeni kayit
        public FormAidatDuzenle() : this(null) { }

        // Duzenleme
        public FormAidatDuzenle(int? aidatId)
        {
            InitializeComponent();
            _aidatId = aidatId;

            this.StartPosition = FormStartPosition.CenterParent;
            this.AcceptButton = btnKaydet;
            this.CancelButton = btnIptal;

            
            btnIptal.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            
        }

        private void FormAidatDuzenle_Load(object sender, EventArgs e)
        {
            // combolari doldur
            cmbYil.DataSource = Yardimci.YilListesi(DateTime.Now.Year - 2, DateTime.Now.Year + 2);
            cmbAy.DataSource = Yardimci.AyListesi();
            cmbDurum.Items.AddRange(new object[] { "Bekliyor", "Kismi", "Odendi" });

            UyeleriYukle();

            if (_aidatId.HasValue)
            {
                this.Text = "Aidat Duzenle";
                KaydiYukle(_aidatId.Value);
            }
            else
            {
                this.Text = "Aidat Ekle";
                cmbDurum.SelectedItem = "Bekliyor";
                cmbYil.SelectedItem = DateTime.Now.Year;
                cmbAy.SelectedItem = DateTime.Now.Month;
            }
        }
        private void UyeleriYukle()
        {
            // aktif uyeler
            DataTable dt = Veritabani.Query("SELECT UyeId, AdSoyad, Blok, DaireNo FROM Uyeler WHERE AktifMi=1 ORDER BY Blok, DaireNo");
            cmbUye.DisplayMember = "AdSoyad";
            cmbUye.ValueMember = "UyeId";
            cmbUye.DataSource = dt;
        }
        private void KaydiYukle(int aidatId)
        {
            const string sql = @"
SELECT a.AidatId, a.UyeId, a.Yil, a.Ay, a.Tutar, a.Durum, a.Notlar
FROM Aidatlar a
WHERE a.AidatId=@id";

            DataTable dt = Veritabani.Query(sql, new SqlParameter("@id", aidatId));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Kayit bulunamadi.");
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            DataRow r = dt.Rows[0];
            cmbUye.SelectedValue = Convert.ToInt32(r["UyeId"]);
            cmbYil.SelectedItem = Convert.ToInt32(r["Yil"]);
            cmbAy.SelectedItem = Convert.ToInt32(r["Ay"]);
            txtTutar.Text = Convert.ToDecimal(r["Tutar"]).ToString("N2");
            cmbDurum.SelectedItem = Convert.ToString(r["Durum"]);
            txtNot.Text = Convert.ToString(r["Notlar"]);
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbUye.SelectedValue == null)
            {
                MessageBox.Show("Uye seciniz."); return;
            }
            if (cmbYil.SelectedItem == null || cmbAy.SelectedItem == null)
            {
                MessageBox.Show("Yil/Ay seciniz."); return;
            }
            if (!Yardimci.TryParseTutar(txtTutar.Text, out decimal tutar))
            {
                MessageBox.Show("Gecerli bir tutar giriniz."); txtTutar.Focus(); return;
            }
            string durum = Convert.ToString(cmbDurum.SelectedItem);
            if (string.IsNullOrEmpty(durum)) durum = "Bekliyor";

            int uyeId = Convert.ToInt32(cmbUye.SelectedValue);
            int yil = (int)cmbYil.SelectedItem;
            int ay = (int)cmbAy.SelectedItem;
            string not = (txtNot.Text ?? "").Trim();

            try
            {
                if (_aidatId.HasValue)
                {
                    // Guncelle
                    const string up = @"
UPDATE Aidatlar
SET UyeId=@UyeId, Yil=@Yil, Ay=@Ay, Tutar=@Tutar, Durum=@Durum, Notlar=@Not
WHERE AidatId=@AidatId";

                    int n = Veritabani.ExecuteNonQuery(
                        up,
                        new SqlParameter("@UyeId", uyeId),
                        new SqlParameter("@Yil", yil),
                        new SqlParameter("@Ay", ay),
                        new SqlParameter("@Tutar", tutar),
                        new SqlParameter("@Durum", durum),
                        new SqlParameter("@Not", string.IsNullOrWhiteSpace(not) ? (object)DBNull.Value : not),
                        new SqlParameter("@AidatId", _aidatId.Value)
                    );

                    if (n > 0) this.DialogResult = DialogResult.OK;
                    else MessageBox.Show("Guncelleme yapilamadi. (Ayni Uye+Yil+Ay olabilir)");
                }
                else
                {
                    // Eklemeden once unique kuralini manuel kontrol (Uye+Yil+Ay)
                    const string kontrolSql = "SELECT COUNT(*) FROM Aidatlar WHERE UyeId=@U AND Yil=@Y AND Ay=@A";
                    int varMi = Convert.ToInt32(Veritabani.ExecuteScalar(kontrolSql,
                        new SqlParameter("@U", uyeId),
                        new SqlParameter("@Y", yil),
                        new SqlParameter("@A", ay)));

                    if (varMi > 0)
                    {
                        MessageBox.Show("Bu Uye icin bu Yil/Ay zaten mevcut.");
                        return;
                    }

                    const string ins = @"
INSERT INTO Aidatlar (UyeId, Yil, Ay, Tutar, Durum, Notlar)
VALUES (@UyeId, @Yil, @Ay, @Tutar, @Durum, @Not)";

                    int n = Veritabani.ExecuteNonQuery(
                        ins,
                        new SqlParameter("@UyeId", uyeId),
                        new SqlParameter("@Yil", yil),
                        new SqlParameter("@Ay", ay),
                        new SqlParameter("@Tutar", tutar),
                        new SqlParameter("@Durum", durum),
                        new SqlParameter("@Not", string.IsNullOrWhiteSpace(not) ? (object)DBNull.Value : not)
                    );

                    if (n > 0) this.DialogResult = DialogResult.OK;
                    else MessageBox.Show("Ekleme yapilamadi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydetme hatasi: " + ex.Message);
            }

        }
    }
}
    
