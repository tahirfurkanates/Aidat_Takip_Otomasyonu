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
    public partial class FormRaporBorcluListe: Form
    {
        public FormRaporBorcluListe()
        {
            InitializeComponent();
            this.Load += FormRaporBorcluListe_Load;
            btnListele.Click += (s, e) => Listele();
        }
        private void Listele()
        {
            if (!(cmbYil.SelectedItem is int) || !(cmbAy.SelectedItem is int)) return;
            int yil = (int)cmbYil.SelectedItem;
            int ay = (int)cmbAy.SelectedItem;

            DataTable dt = RaporYardimci.BorcluListesi(yil, ay);
            gridBorclular.DataSource = dt;

            if (gridBorclular.Columns.Contains("AdSoyad")) gridBorclular.Columns["AdSoyad"].HeaderText = "Ad Soyad";
            if (gridBorclular.Columns.Contains("AidatTutar")) gridBorclular.Columns["AidatTutar"].HeaderText = "Aidat Tutar";
            if (gridBorclular.Columns.Contains("OdenenToplam")) gridBorclular.Columns["OdenenToplam"].HeaderText = "Odenen";
            if (gridBorclular.Columns.Contains("Kalan")) gridBorclular.Columns["Kalan"].HeaderText = "Kalan";

            decimal topKalan = 0;
            foreach (DataRow r in dt.Rows) topKalan += Convert.ToDecimal(r["Kalan"]);
            lblTopKalan.Text = "Toplam Kalan: " + topKalan.ToString("N2");
        }
        private void FormRaporBorcluListe_Load(object sender, EventArgs e)
        {
            int yil = DateTime.Now.Year;
            for (int y = yil - 2; y <= yil + 2; y++) cmbYil.Items.Add(y);
            cmbYil.SelectedItem = yil;

            for (int a = 1; a <= 12; a++) cmbAy.Items.Add(a);
            cmbAy.SelectedItem = DateTime.Now.Month;

            Listele();
        }
    }
}
