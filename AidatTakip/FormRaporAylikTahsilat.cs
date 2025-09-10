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
    public partial class FormRaporAylikTahsilat: Form
    {
        public FormRaporAylikTahsilat()
        {
            InitializeComponent();
            this.Load += FormRaporAylikTahsilat_Load;
            btnListele.Click += (s, e) => Listele();
        }

        private void gridDetay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormRaporAylikTahsilat_Load(object sender, EventArgs e)
        {
            int yil = DateTime.Now.Year;
            cmbYil.Items.Clear();
            for (int y = yil - 2; y <= yil + 2; y++) cmbYil.Items.Add(y);
            cmbYil.SelectedItem = yil;

            cmbAy.Items.Clear();
            for (int a = 1; a <= 12; a++) cmbAy.Items.Add(a);
            cmbAy.SelectedItem = DateTime.Now.Month;

            Listele();

        }
        private void Listele()
        {
            if (!(cmbYil.SelectedItem is int) || !(cmbAy.SelectedItem is int)) return;
            int yil = (int)cmbYil.SelectedItem;
            int ay = (int)cmbAy.SelectedItem;

            DataTable dt = RaporYardimci.AylikTahsilatDetay(yil, ay);
            gridDetay.DataSource = dt;

            // Kolon basliklari
            if (gridDetay.Columns.Contains("AdSoyad")) gridDetay.Columns["AdSoyad"].HeaderText = "Ad Soyad";
            if (gridDetay.Columns.Contains("AidatTutar")) gridDetay.Columns["AidatTutar"].HeaderText = "Aidat Tutar";
            if (gridDetay.Columns.Contains("OdenenToplam")) gridDetay.Columns["OdenenToplam"].HeaderText = "Odenen";
            if (gridDetay.Columns.Contains("Kalan")) gridDetay.Columns["Kalan"].HeaderText = "Kalan";

            // Ozetler
            decimal topBekleyen = 0, topKismi = 0, topOdendi = 0, topKalan = 0;
            foreach (DataRow r in dt.Rows)
            {
                decimal aidat = Convert.ToDecimal(r["AidatTutar"]);
                decimal odenen = Convert.ToDecimal(r["OdenenToplam"]);
                decimal kalan = Convert.ToDecimal(r["Kalan"]);
                string durum = Convert.ToString(r["Durum"]);

                if (durum == "Bekliyor") topBekleyen += aidat;
                else if (durum == "Kismi") topKismi += aidat;
                else if (durum == "Odendi") topOdendi += aidat;

                topKalan += Math.Max(kalan, 0);
            }
            lblTopBekleyen.Text = "Bekleyen: " + topBekleyen.ToString("N2");
            lblTopKismi.Text = "Kismi: " + topKismi.ToString("N2");
            lblTopOdendi.Text = "Odendi: " + topOdendi.ToString("N2");
            lblTopKalan.Text = "Genel Kalan: " + topKalan.ToString("N2");
        }
    }
}

