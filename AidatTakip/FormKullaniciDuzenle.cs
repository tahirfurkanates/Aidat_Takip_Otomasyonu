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
    public partial class FormKullaniciDuzenle: Form
    {
        private readonly int? _id; // null => yeni

        // Designer ve "yeni ekle" için parametresiz
        public FormKullaniciDuzenle() : this(null) { }
        public FormKullaniciDuzenle(int? kullaniciId)
        {
            InitializeComponent();
            _id = kullaniciId;

            this.StartPosition = FormStartPosition.CenterParent;
            this.AcceptButton = btnKaydet;
            this.CancelButton = btnIptal;

            
            btnIptal.Click += delegate { this.DialogResult = DialogResult.Cancel; };

            if (cmbRol.Items.Count == 0)
            {
                cmbRol.Items.Add("Admin");
                cmbRol.Items.Add("User");
            }

        }

        private void FormKullaniciDuzenle_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                this.Text = "Kullanici duzenle";
                txtSifre.Enabled = false;
                txtSifreTekrar.Enabled = false;

                DataTable dt = Veritabani.Query(
                    "SELECT * FROM Kullanicilar WHERE KullaniciId=@id",
                    new SqlParameter("@id", _id.Value)
                );
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Kayit yok.");
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }

                DataRow r = dt.Rows[0];
                txtKullaniciAdi.Text = Convert.ToString(r["KullaniciAdi"]);
                txtAdSoyad.Text = Convert.ToString(r["AdSoyad"]);
                txtEmail.Text = Convert.ToString(r["Email"]);
                cmbRol.SelectedItem = Convert.ToString(r["Rol"]);
                chkAktif.Checked = r["AktifMi"] != DBNull.Value && Convert.ToBoolean(r["AktifMi"]);
            }
            else
            {
                this.Text = "Kullanici ekle";
                cmbRol.SelectedItem = "User";
                chkAktif.Checked = true;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
            { MessageBox.Show("Kullanici adi zorunlu."); txtKullaniciAdi.Focus(); return; }

            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
            { MessageBox.Show("Ad soyad zorunlu."); txtAdSoyad.Focus(); return; }

            string rol = cmbRol.SelectedItem != null ? cmbRol.SelectedItem.ToString() : null;
            if (rol != "Admin" && rol != "User")
            { MessageBox.Show("Rol seciniz."); cmbRol.Focus(); return; }

            try
            {
                if (_id.HasValue)
                {
                    int n = Veritabani.ExecuteNonQuery(@"
UPDATE Kullanicilar
SET KullaniciAdi=@u, AdSoyad=@a, Email=@e, Rol=@r, AktifMi=@ak
WHERE KullaniciId=@id",
                        new SqlParameter("@u", txtKullaniciAdi.Text.Trim()),
                        new SqlParameter("@a", txtAdSoyad.Text.Trim()),
                        new SqlParameter("@e", string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim()),
                        new SqlParameter("@r", rol),
                        new SqlParameter("@ak", chkAktif.Checked),
                        new SqlParameter("@id", _id.Value)
                    );
                    if (n > 0) this.DialogResult = DialogResult.OK;
                    else MessageBox.Show("Guncelleme yapilamadi.");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtSifre.Text) ||
                        txtSifre.Text != (txtSifreTekrar.Text ?? ""))
                    {
                        MessageBox.Show("Sifreleri kontrol ediniz.");
                        txtSifre.Focus();
                        return;
                    }

                    int n = Veritabani.ExecuteNonQuery(@"
INSERT INTO Kullanicilar (KullaniciAdi, AdSoyad, Email, Rol, AktifMi, Sifre)
VALUES (@u, @a, @e, @r, @ak, @s)",
                        new SqlParameter("@u", txtKullaniciAdi.Text.Trim()),
                        new SqlParameter("@a", txtAdSoyad.Text.Trim()),
                        new SqlParameter("@e", string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim()),
                        new SqlParameter("@r", rol),
                        new SqlParameter("@ak", chkAktif.Checked),
                        new SqlParameter("@s", txtSifre.Text)
                    );
                    if (n > 0) this.DialogResult = DialogResult.OK;
                    else MessageBox.Show("Ekleme yapilamadi. (Kullanici adi benzersiz olmali)");
                }
            }
            catch (SqlException ex)
            {
                // 2627/2601: unique ihlali
                if (ex.Number == 2627 || ex.Number == 2601)
                    MessageBox.Show("Ayni kullanici adi veya email zaten mevcut.");
                else
                    MessageBox.Show("Kaydetme hatasi: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydetme hatasi: " + ex.Message);
            }
        }
    }
}

