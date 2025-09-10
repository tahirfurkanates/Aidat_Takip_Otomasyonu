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
    public partial class FormUyeDuzenle : Form
    {
        private readonly int? _uyeId; // null ise yeni kayit, dolu ise duzenleme

        // Yeni kayit icin
        public FormUyeDuzenle() : this(null) { }

        // Duzenleme icin
        public FormUyeDuzenle(int? uyeId)
        {
            InitializeComponent();
            _uyeId = uyeId;

            this.StartPosition = FormStartPosition.CenterParent;
            this.AcceptButton = btnKaydet;

            // İKİ seçenekten birini kullan:
            // 1) Sadece DialogResult ile (en sade yol):
            this.CancelButton = btnIptal;
            btnIptal.DialogResult = DialogResult.Cancel;

           
            
        }

        private void FormUyeDuzenle_Load(object sender, EventArgs e)
        {
            if (_uyeId.HasValue)
            {
                this.Text = "Uye Duzenle";
                KaydiYukle(_uyeId.Value);
            }
            else
            {
                this.Text = "Yeni Uye";
                chkAktifMi.Checked = true; // varsayilan aktif
            }
        }
        private void KaydiYukle(int uyeId)
        {
            const string sql = @"
SELECT UyeId, AdSoyad, Blok, DaireNo, Telefon, Email, AktifMi, Notlar
FROM Uyeler
WHERE UyeId = @id";

            DataTable dt = Veritabani.Query(sql, new SqlParameter("@id", uyeId));
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Kayit bulunamadi.");
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            DataRow r = dt.Rows[0];
            txtAdSoyad.Text = Convert.ToString(r["AdSoyad"]);
            txtBlok.Text = Convert.ToString(r["Blok"]);
            txtDaireNo.Text = Convert.ToString(r["DaireNo"]);
            txtTelefon.Text = Convert.ToString(r["Telefon"]);
            txtEmail.Text = Convert.ToString(r["Email"]);
            txtNotlar.Text = Convert.ToString(r["Notlar"]);
            chkAktifMi.Checked = Convert.ToBoolean(r["AktifMi"]);
        }
        

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1) Zorunlu alanlar
            if (!ZorunluAlanlariDogrula()) return;

            // 2) Degerleri topla
            string adSoyad = txtAdSoyad.Text.Trim();
            string blok = txtBlok.Text.Trim();
            string daireNo = txtDaireNo.Text.Trim();
            string telefon = txtTelefon.Text.Trim();
            string email = txtEmail.Text.Trim();
            string notlar = txtNotlar.Text.Trim();
            bool aktifMi = chkAktifMi.Checked;

            try
            {
                if (_uyeId.HasValue)
                {
                    // GUNCELLE
                    const string up = @"
UPDATE Uyeler
SET AdSoyad=@AdSoyad, Blok=@Blok, DaireNo=@DaireNo, Telefon=@Telefon,
    Email=@Email, AktifMi=@AktifMi, Notlar=@Notlar
WHERE UyeId=@UyeId";

                    int etkilenen = Veritabani.ExecuteNonQuery(
                        up,
                        new SqlParameter("@AdSoyad", adSoyad),
                        new SqlParameter("@Blok", blok),
                        new SqlParameter("@DaireNo", daireNo),
                        new SqlParameter("@Telefon", telefon),
                        new SqlParameter("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email),
                        new SqlParameter("@AktifMi", aktifMi),
                        new SqlParameter("@Notlar", string.IsNullOrWhiteSpace(notlar) ? (object)DBNull.Value : notlar),
                        new SqlParameter("@UyeId", _uyeId.Value)
                    );

                    if (etkilenen > 0) this.DialogResult = DialogResult.OK;
                    else MessageBox.Show("Guncelleme yapilamadi.");
                }
                else
                {
                    // EKLE
                    const string ins = @"
INSERT INTO Uyeler (AdSoyad, Blok, DaireNo, Telefon, Email, AktifMi, Notlar)
VALUES (@AdSoyad, @Blok, @DaireNo, @Telefon, @Email, @AktifMi, @Notlar)";

                    int etkilenen = Veritabani.ExecuteNonQuery(
                        ins,
                        new SqlParameter("@AdSoyad", adSoyad),
                        new SqlParameter("@Blok", blok),
                        new SqlParameter("@DaireNo", daireNo),
                        new SqlParameter("@Telefon", telefon),
                        new SqlParameter("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email),
                        new SqlParameter("@AktifMi", aktifMi),
                        new SqlParameter("@Notlar", string.IsNullOrWhiteSpace(notlar) ? (object)DBNull.Value : notlar)
                    );

                    if (etkilenen > 0) this.DialogResult = DialogResult.OK;
                    else MessageBox.Show("Ekleme yapilamadi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydetme sirasinda hata: " + ex.Message);
            }
        }
        private bool ZorunluAlanlariDogrula()
        {
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
            {
                MessageBox.Show("AdSoyad zorunludur.");
                txtAdSoyad.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtBlok.Text))
            {
                MessageBox.Show("Blok zorunludur.");
                txtBlok.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtDaireNo.Text))
            {
                MessageBox.Show("Daire No zorunludur.");
                txtDaireNo.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                MessageBox.Show("Telefon zorunludur.");
                txtTelefon.Focus(); return false;
            }
            return true;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
        }
    }
}




