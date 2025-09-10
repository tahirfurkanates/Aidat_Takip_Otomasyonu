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
    public partial class FormOdemeDuzenle : Form
    {
        private readonly int _aidatId;
        private readonly int? _odemeId;

        // Ekle: AidatId zorunlu
        public FormOdemeDuzenle(int aidatId) : this(aidatId, null) { }
        public FormOdemeDuzenle(int aidatId, int? odemeId)
        {
            InitializeComponent();
            _aidatId = aidatId;
            _odemeId = odemeId;

            this.StartPosition = FormStartPosition.CenterParent;
            this.AcceptButton = btnKaydet;
            this.CancelButton = btnIptal;

        
            btnIptal.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            
        }

        private void FormOdemeDuzenle_Load(object sender, EventArgs e)
        {
            // Uye ve Donem bilgisini getir
            const string infoSql = @"
SELECT u.AdSoyad, a.Yil, a.Ay, a.Tutar, a.Durum
FROM Aidatlar a
JOIN Uyeler u ON u.UyeId = a.UyeId
WHERE a.AidatId = @id";

            DataTable info = Veritabani.Query(infoSql, new SqlParameter("@id", _aidatId));
            if (info.Rows.Count == 0)
            {
                MessageBox.Show("Aidat kaydi bulunamadi.");
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            DataRow r = info.Rows[0];
            lblUye.Text = "Uye: " + Convert.ToString(r["AdSoyad"]);
            lblDonem.Text = "Donem: " + Convert.ToInt32(r["Yil"]) + "/" + Convert.ToInt32(r["Ay"]);

            // Yontem liste
            cmbYontem.Items.Clear();
            cmbYontem.Items.AddRange(new object[] { "Nakit", "EFT", "POS", "Havale", "Diger" });
            cmbYontem.SelectedIndex = 0;

            if (_odemeId.HasValue)
            {
                this.Text = "Odeme Duzenle";
                OdemeyiYukle(_odemeId.Value);
            }
            else
            {
                this.Text = "Odeme Ekle";
                dtOdemeTarihi.Value = DateTime.Today;
            }
        }
        private void OdemeyiYukle(int odemeId)
        {
            const string sql = @"
SELECT OdemeId, AidatId, OdemeTarihi, Tutar, Yontem, Aciklama
FROM Odemeler
WHERE OdemeId=@id";

            DataTable dt = Veritabani.Query(sql, new SqlParameter("@id", odemeId));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Odeme kaydi bulunamadi.");
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            DataRow r = dt.Rows[0];
            dtOdemeTarihi.Value = Convert.ToDateTime(r["OdemeTarihi"]);
            txtTutar.Text = Convert.ToDecimal(r["Tutar"]).ToString("N2");
            cmbYontem.SelectedItem = Convert.ToString(r["Yontem"]);
            txtAciklama.Text = Convert.ToString(r["Aciklama"]);
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {


            if (!Yardimci.TryParseTutar(txtTutar.Text, out decimal tutar) || tutar <= 0)
            {
                MessageBox.Show("Gecerli bir tutar giriniz.");
                txtTutar.Focus(); return;
            }
            DateTime tarih = dtOdemeTarihi.Value.Date;
            string yontem = Convert.ToString(cmbYontem.SelectedItem) ?? "Diger";
            string aciklama = (txtAciklama.Text ?? "").Trim();

            try
            {
                if (_odemeId.HasValue)
                {
                    const string up = @"
UPDATE Odemeler
SET OdemeTarihi=@t, Tutar=@tu, Yontem=@y, Aciklama=@a
WHERE OdemeId=@id AND AidatId=@aid";

                    int n = Veritabani.ExecuteNonQuery(
                        up,
                        new SqlParameter("@t", tarih),
                        new SqlParameter("@tu", tutar),
                        new SqlParameter("@y", yontem),
                        new SqlParameter("@a", string.IsNullOrWhiteSpace(aciklama) ? (object)DBNull.Value : aciklama),
                        new SqlParameter("@id", _odemeId.Value),
                        new SqlParameter("@aid", _aidatId)
                    );

                    if (n <= 0) { MessageBox.Show("Guncelleme yapilamadi."); return; }
                }
                else
                {
                    const string ins = @"
INSERT INTO Odemeler (AidatId, OdemeTarihi, Tutar, Yontem, Aciklama)
VALUES (@aid, @t, @tu, @y, @a)";

                    int n = Veritabani.ExecuteNonQuery(
                        ins,
                        new SqlParameter("@aid", _aidatId),
                        new SqlParameter("@t", tarih),
                        new SqlParameter("@tu", tutar),
                        new SqlParameter("@y", yontem),
                        new SqlParameter("@a", string.IsNullOrWhiteSpace(aciklama) ? (object)DBNull.Value : aciklama)
                    );

                    if (n <= 0) { MessageBox.Show("Ekleme yapilamadi."); return; }
                }

                // Her islemden sonra durum guncelle
                AidatIsKurallari.GuncelleAidatDurum(_aidatId);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydetme hatasi: " + ex.Message);
            }
        }
    }
}      
