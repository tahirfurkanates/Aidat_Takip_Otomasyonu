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
    public partial class FormRaporUyeEkstresi: Form
    {
        public FormRaporUyeEkstresi()
        {
            InitializeComponent();
            
            btnListele.Click += (s, e) => Listele();
        }

        private void FormRaporUyeEkstresi_Load(object sender, EventArgs e)
        {
            // Uye listesi (aktif/pasif fark etmez; tum gecmis icin)
            DataTable du = Veritabani.Query("SELECT UyeId, AdSoyad, Blok, DaireNo FROM Uyeler ORDER BY Blok, DaireNo");
            cmbUye.DisplayMember = "AdSoyad";
            cmbUye.ValueMember = "UyeId";
            cmbUye.DataSource = du;

            Listele();
        }
        private void Listele()
        {
            if (cmbUye.SelectedValue == null) return;
            int uyeId = Convert.ToInt32(cmbUye.SelectedValue);

            DataTable dt = RaporYardimci.UyeEkstresi(uyeId);
            gridEkstre.DataSource = dt;

            if (gridEkstre.Columns.Contains("Tur")) gridEkstre.Columns["Tur"].HeaderText = "Tur";
            if (gridEkstre.Columns.Contains("Tutar")) gridEkstre.Columns["Tutar"].HeaderText = "Tutar";
            if (gridEkstre.Columns.Contains("Detay")) gridEkstre.Columns["Detay"].HeaderText = "Detay";
            if (gridEkstre.Columns.Contains("Tarih")) gridEkstre.Columns["Tarih"].HeaderText = "Tarih";

            decimal topAidat = 0, topOdeme = 0;
            foreach (DataRow r in dt.Rows)
            {
                string tur = Convert.ToString(r["Tur"]);
                decimal tutar = Convert.ToDecimal(r["Tutar"]);
                if (tur == "AIDAT") topAidat += tutar;
                else if (tur == "ODEME") topOdeme += tutar;
            }
            lblTopAidat.Text = "Toplam Aidat: " + topAidat.ToString("N2");
            lblTopOdeme.Text = "Toplam Odeme: " + topOdeme.ToString("N2");
            lblGenelBakiye.Text = "Bakiye (Aidat - Odeme): " + (topAidat - topOdeme).ToString("N2");
        }
    }
}

