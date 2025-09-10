using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AidatTakip
{
    public partial class FormAna : Form
    {
        private readonly string _kullaniciRol;
        public FormAna(string kullaniciRol)
        {
            InitializeComponent();
            _kullaniciRol = kullaniciRol;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void FormAna_Load(object sender, EventArgs e)
        {
            this.Text = "Aidat Takip - Rol: " + _kullaniciRol;

            bool adminMi = string.Equals(_kullaniciRol, "Admin", StringComparison.OrdinalIgnoreCase);

            if (menuKullaniciYonetimi != null) menuKullaniciYonetimi.Visible = adminMi;
            if (menuAyarlar != null) menuAyarlar.Visible = adminMi;
        }
        private void menuUyeYonetimi_Click(object sender, EventArgs e)
        {
            using (var frm = new FormUyeListe())
            {
                frm.ShowDialog(this);
            }
        }
        private void menuAidatYonetimi_Click(object sender, EventArgs e)
        {
            using (var f = new FormAidatListe())
            {
                f.ShowDialog(this);
            }
        }
        private void menuOdemeler_Click(object sender, EventArgs e)
        {
            using (var f = new FormOdemeListe())
            {
                f.ShowDialog(this);
            }
        }
        private void menuRaporlar_Click(object sender, EventArgs e)
        {

        }
        private void menuRaporAylikTahsilatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var f = new FormRaporAylikTahsilat()) f.ShowDialog(this);
        }
        private void menuRaporBorcluListeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var f = new FormRaporBorcluListe()) f.ShowDialog(this);
        }
        private void menuRaporUyeEkstresiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var f = new FormRaporUyeEkstresi()) f.ShowDialog(this);
        }
        private void menuAyarlar_Click(object sender, EventArgs e)
        {
            using (var f = new FormKullaniciListe()) f.ShowDialog(this);
        }
        private void menuBildirimler_Click(object sender, EventArgs e)
        {
            using (var f = new FormBildirimler())
            {
                f.ShowDialog(this);
            }
        }
        private void menuKullaniciYonetimi_Click(object sender, EventArgs e)
        {
            using (var f = new FormKullaniciDuzenle())
            {
                f.ShowDialog(this);
            }
        }
    }
}


