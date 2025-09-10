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
    public partial class FormGiris: Form
    {
        public FormGiris()
        {
            InitializeComponent();

            // Kontrol isimleri (Designer'da ver):
            // lblKullaniciAdi, txtKullaniciAdi, lblSifre, txtSifre, chkBeniHatirla (ops), btnGiris

            this.AcceptButton = btnGiris;     // Enter tusu ile giris
            txtSifre.UseSystemPasswordChar = true;

        }

        private void FormGiris_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kadi = (txtKullaniciAdi.Text ?? "").Trim();
            string sifre = (txtSifre.Text ?? "").Trim();

            if (kadi.Length == 0) { MessageBox.Show("Kullanici adi giriniz."); txtKullaniciAdi.Focus(); return; }
            if (sifre.Length == 0) { MessageBox.Show("Sifre giriniz."); txtSifre.Focus(); return; }

            try
            {
                // *** DİKKAT: SifreHash değil, Sifre kolonu ***
                const string sql = @"
SELECT TOP 1 KullaniciId, KullaniciAdi, Rol, AktifMi, Sifre
FROM dbo.Kullanicilar
WHERE KullaniciAdi = @ka";

                DataTable dt = Veritabani.Query(sql, new SqlParameter("@ka", kadi));
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Kullanici bulunamadi.");
                    return;
                }

                DataRow r = dt.Rows[0];

                bool aktif = r["AktifMi"] != DBNull.Value && Convert.ToBoolean(r["AktifMi"]);
                if (!aktif)
                {
                    MessageBox.Show("Hesap pasif.");
                    return;
                }

                // Düz şifre karşılaştırma
                string kayitliSifre = Convert.ToString(r["Sifre"]);
                if (!string.Equals(sifre, kayitliSifre))
                {
                    MessageBox.Show("Sifre hatali.");
                    txtSifre.Clear();
                    txtSifre.Focus();
                    return;
                }

                string rol = Convert.ToString(r["Rol"]);

                // Başarılı giriş → Ana form
                this.Hide();
                using (var ana = new FormAna(rol))
                {
                    // örn: ana.Text = "Aidat Takip - Rol: " + rol;
                    ana.ShowDialog(this);
                }
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giris sirasinda hata: " + ex.Message);
            }
        }

    }
    }

