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
    public partial class FormOdemeListe : Form
    {
        public FormOdemeListe()
        {
            InitializeComponent();

            

            dtBaslangic.ValueChanged += FiltreDegisti;
            dtBitis.ValueChanged += FiltreDegisti;
            txtUyeAra.TextChanged += FiltreDegisti;
            cmbYontemFiltre.SelectedIndexChanged += FiltreDegisti;

            

            gridOdemeler.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) btnDuzenle_Click(s, e); };
        }

        private void FormOdemeListe_Load(object sender, EventArgs e)
        {
            gridOdemeler.ReadOnly = true;
            gridOdemeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridOdemeler.AllowUserToAddRows = false;
            gridOdemeler.AllowUserToDeleteRows = false;
            gridOdemeler.MultiSelect = false;
            gridOdemeler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbYontemFiltre.Items.AddRange(new object[] { "Tum", "Nakit", "EFT", "POS", "Havale", "Diger" });
            cmbYontemFiltre.SelectedItem = "Tum";

            dtBaslangic.Value = DateTime.Today.AddMonths(-1);
            dtBitis.Value = DateTime.Today;

            ListeyiYukle();
        }

        private void girdOdemeler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void FiltreDegisti(object sender, EventArgs e)
        {
            ListeyiYukle();
        }

        private void ListeyiYukle()
        {
            DateTime t1 = dtBaslangic.Value.Date;
            DateTime t2 = dtBitis.Value.Date.AddDays(1).AddTicks(-1); // gunun sonu
            string ara = (txtUyeAra.Text ?? "").Trim();
            string yontem = Convert.ToString(cmbYontemFiltre.SelectedItem) ?? "Tum";

            const string sql = @"
SELECT o.OdemeId, o.AidatId, u.AdSoyad, u.Blok, u.DaireNo,
       a.Yil, a.Ay, o.OdemeTarihi, o.Tutar, o.Yontem, o.Aciklama
FROM Odemeler o
JOIN Aidatlar a ON a.AidatId = o.AidatId
JOIN Uyeler u ON u.UyeId = a.UyeId
WHERE o.OdemeTarihi >= @t1 AND o.OdemeTarihi <= @t2
  AND (@ara='' OR u.AdSoyad LIKE '%'+@ara+'%' OR u.Blok LIKE '%'+@ara+'%' OR u.DaireNo LIKE '%'+@ara+'%')
  AND (@y='Tum' OR o.Yontem=@y)
ORDER BY o.OdemeTarihi DESC";

            DataTable dt = Veritabani.Query(sql,
                new SqlParameter("@t1", t1),
                new SqlParameter("@t2", t2),
                new SqlParameter("@ara", ara),
                new SqlParameter("@y", yontem));

            gridOdemeler.DataSource = dt;

            if (gridOdemeler.Columns.Contains("OdemeId")) gridOdemeler.Columns["OdemeId"].HeaderText = "Odeme Id";
            if (gridOdemeler.Columns.Contains("AidatId")) gridOdemeler.Columns["AidatId"].HeaderText = "Aidat Id";
            if (gridOdemeler.Columns.Contains("AdSoyad")) gridOdemeler.Columns["AdSoyad"].HeaderText = "Ad Soyad";
            if (gridOdemeler.Columns.Contains("DaireNo")) gridOdemeler.Columns["DaireNo"].HeaderText = "Daire No";
        }

        private int? SeciliOdemeId()
        {
            if (gridOdemeler.CurrentRow == null) return null;
            return Convert.ToInt32(gridOdemeler.CurrentRow.Cells["OdemeId"].Value);
        }

        private int? SeciliAidatId()
        {
            if (gridOdemeler.CurrentRow == null) return null;
            return Convert.ToInt32(gridOdemeler.CurrentRow.Cells["AidatId"].Value);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            // Genel ekleme icin: once bir aidat secmek gerekir.
            MessageBox.Show("Odeme eklemek icin Aidat ekranindan 'Odeme Gir' ile acmanizi oneririz.");
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            int? odemeId = SeciliOdemeId();
            int? aidatId = SeciliAidatId();
            if (!odemeId.HasValue || !aidatId.HasValue) return;

            using (var f = new FormOdemeDuzenle(aidatId.Value, odemeId.Value))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    // Durum guncellemesi form icinde yapiliyor; burada listeyi yenile
                    ListeyiYukle();
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int? odemeId = SeciliOdemeId();
            int? aidatId = SeciliAidatId();
            if (!odemeId.HasValue || !aidatId.HasValue) return;

            if (MessageBox.Show("Bu odemeyi silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Veritabani.ExecuteNonQuery("DELETE FROM Odemeler WHERE OdemeId=@id", new SqlParameter("@id", odemeId.Value));
                    // Silince de durum guncelle
                    AidatIsKurallari.GuncelleAidatDurum(aidatId.Value);
                    ListeyiYukle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme hatasi: " + ex.Message);
                }
            }
        }
    }
}