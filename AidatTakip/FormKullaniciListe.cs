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
    public partial class FormKullaniciListe: Form
    {
        public FormKullaniciListe()
        {
            InitializeComponent();

            

            btnListele.Click += delegate { Listele(); };
            txtAra.TextChanged += delegate { Listele(); };
            cmbRol.SelectedIndexChanged += delegate { Listele(); };
            chkSadeceAktif.CheckedChanged += delegate { Listele(); };

            btnEkle.Click += delegate { Ekle(); };
            btnDuzenle.Click += delegate { Duzenle(); };
            btnSil.Click += delegate { Sil(); };
            btnSifreYenile.Click += delegate { SifreYenile(); };
            btnKapat.Click += delegate { this.Close(); };

            gridKullanicilar.ReadOnly = true;
            gridKullanicilar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridKullanicilar.AllowUserToAddRows = false;
            gridKullanicilar.AllowUserToDeleteRows = false;
            gridKullanicilar.MultiSelect = false;
        }
        private void Listele()
        {
            string q = "%" + (txtAra.Text ?? "").Trim() + "%";
            string rol = cmbRol.SelectedItem != null ? cmbRol.SelectedItem.ToString() : "(Tumu)";
            int sadeceAktif = chkSadeceAktif.Checked ? 1 : 0;

            DataTable dt = Veritabani.Query(@"
SELECT KullaniciId, KullaniciAdi, AdSoyad, Email, Rol, AktifMi
FROM Kullanicilar
WHERE (@aktif=0 OR AktifMi=1)
  AND (@rol='(Tumu)' OR Rol=@rol)
  AND (KullaniciAdi LIKE @q OR AdSoyad LIKE @q OR ISNULL(Email,'') LIKE @q)
ORDER BY Rol DESC, AdSoyad",
                new SqlParameter("@aktif", sadeceAktif),
                new SqlParameter("@rol", rol),
                new SqlParameter("@q", q)
            );

            gridKullanicilar.DataSource = dt;

            if (gridKullanicilar.Columns.Contains("KullaniciAdi"))
                gridKullanicilar.Columns["KullaniciAdi"].HeaderText = "Kullanici adi";
            if (gridKullanicilar.Columns.Contains("AdSoyad"))
                gridKullanicilar.Columns["AdSoyad"].HeaderText = "Ad soyad";
            if (gridKullanicilar.Columns.Contains("AktifMi"))
                gridKullanicilar.Columns["AktifMi"].HeaderText = "Aktif";
        }

        private int? SeciliId()
        {
            if (gridKullanicilar.CurrentRow == null) return null;
            object v = gridKullanicilar.CurrentRow.Cells["KullaniciId"].Value;
            if (v == null || v == DBNull.Value) return null;
            return Convert.ToInt32(v);
        }

        private void Ekle()
        {
            using (var f = new FormKullaniciDuzenle())
            {
                if (f.ShowDialog(this) == DialogResult.OK) Listele();
            }
        }

        private void Duzenle()
        {
            int? id = SeciliId();
            if (id == null) { MessageBox.Show("Lutfen satir seciniz."); return; }

            using (var f = new FormKullaniciDuzenle(id))
            {
                if (f.ShowDialog(this) == DialogResult.OK) Listele();
            }
        }

        private void Sil()
        {
            int? id = SeciliId();
            if (id == null) { MessageBox.Show("Lutfen satir seciniz."); return; }

            if (MessageBox.Show("Secili kullaniciyi silmek istiyor musunuz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            Veritabani.ExecuteNonQuery(
                "DELETE FROM Kullanicilar WHERE KullaniciId=@id",
                new SqlParameter("@id", id.Value)
            );
            Listele();
        }

        private void SifreYenile()
        {
            int? id = SeciliId();
            if (id == null) { MessageBox.Show("Lutfen satir seciniz."); return; }

            using (var frm = new Form())
            {
                frm.Text = "Sifre yenile";
                frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ClientSize = new Size(290, 80);

                var lbl = new Label();
                lbl.Text = "Yeni sifre:";
                lbl.AutoSize = true;
                lbl.Left = 10;
                lbl.Top = 12;

                var txt = new TextBox();
                txt.Left = 90; txt.Top = 10; txt.Width = 180;
                txt.UseSystemPasswordChar = true;

                var btn = new Button();
                btn.Text = "Kaydet";
                btn.Left = 90; btn.Top = 40; btn.Width = 80;
                btn.DialogResult = DialogResult.OK;

                frm.Controls.Add(lbl);
                frm.Controls.Add(txt);
                frm.Controls.Add(btn);
                frm.AcceptButton = btn;

                if (frm.ShowDialog(this) != DialogResult.OK) return;

                string yeni = (txt.Text ?? "").Trim();
                if (yeni.Length < 1)
                {
                    MessageBox.Show("Gecerli sifre giriniz.");
                    return;
                }

                Veritabani.ExecuteNonQuery(
                    "UPDATE Kullanicilar SET Sifre=@s WHERE KullaniciId=@id",
                    new SqlParameter("@s", yeni),
                    new SqlParameter("@id", id.Value)
                );
                MessageBox.Show("Sifre guncellendi.");
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gridKullanicilar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormKullaniciListe_Load(object sender, EventArgs e)
        {
            if (cmbRol.Items.Count == 0)
            {
                cmbRol.Items.Add("(Tumu)");
                cmbRol.Items.Add("Admin");
                cmbRol.Items.Add("User");
            }
            cmbRol.SelectedIndex = 0;
            chkSadeceAktif.Checked = false;
            Listele();
        }
    }
}
