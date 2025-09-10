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
    public partial class FormAidatListe: Form
    {
        public FormAidatListe()
        {
            InitializeComponent();

            gridAidatlar.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) btnDuzenle_Click(s, e); };
        }
        private void FiltreDegisti(object sender, EventArgs e)
        {
            ListeyiYukle();
        }
        private void ListeyiYukle()
        {
            int yil = (cmbYil.SelectedItem is int) ? (int)cmbYil.SelectedItem : DateTime.Now.Year;
            int ay = (cmbAy.SelectedItem is int) ? (int)cmbAy.SelectedItem : DateTime.Now.Month;
            string uyeAra = (txtUyeAra.Text ?? "").Trim();
            string secilenDurum = Convert.ToString(cmbDurum.SelectedItem) ?? "Tum";

            string sql = @"
SELECT a.AidatId, u.UyeId, u.AdSoyad, u.Blok, u.DaireNo,
       a.Yil, a.Ay, a.Tutar, a.Durum, a.OlusturmaTarihi
FROM Aidatlar a
JOIN Uyeler u ON u.UyeId = a.UyeId
WHERE (@yil=0 OR a.Yil=@yil)
  AND (@ay=0 OR a.Ay=@ay)
  AND (@ara='' OR u.AdSoyad LIKE '%'+@ara+'%' OR u.Blok LIKE '%'+@ara+'%' OR u.DaireNo LIKE '%'+@ara+'%')
  AND (@durum='Tum' OR a.Durum=@durum)
ORDER BY u.Blok, u.DaireNo";

            DataTable dt = Veritabani.Query(sql,
                new SqlParameter("@yil", yil),
                new SqlParameter("@ay", ay),
                new SqlParameter("@ara", uyeAra),
                new SqlParameter("@durum", secilenDurum));

            gridAidatlar.DataSource = dt;

            // Basliklar
            if (gridAidatlar.Columns.Contains("AidatId")) gridAidatlar.Columns["AidatId"].HeaderText = "Aidat Id";
            if (gridAidatlar.Columns.Contains("UyeId")) gridAidatlar.Columns["UyeId"].HeaderText = "Uye Id";
            if (gridAidatlar.Columns.Contains("AdSoyad")) gridAidatlar.Columns["AdSoyad"].HeaderText = "Ad Soyad";
            if (gridAidatlar.Columns.Contains("DaireNo")) gridAidatlar.Columns["DaireNo"].HeaderText = "Daire No";
            if (gridAidatlar.Columns.Contains("OlusturmaTarihi")) gridAidatlar.Columns["OlusturmaTarihi"].HeaderText = "Olusturma Tarihi";

            OzetHesapla(dt);
        }
        private void OzetHesapla(DataTable dt)
        {
            decimal bekleyen = 0, kismi = 0, odendi = 0;

            foreach (DataRow r in dt.Rows)
            {
                decimal tutar = Convert.ToDecimal(r["Tutar"]);
                string durum = Convert.ToString(r["Durum"]);
                if (durum == "Bekliyor") bekleyen += tutar;
                else if (durum == "Kismi") kismi += tutar;
                else if (durum == "Odendi") odendi += tutar;
            }

            lblOzetBekleyen.Text = "Bekleyen: " + bekleyen.ToString("N2");
            lblOzetKismi.Text = "Kismi: " + kismi.ToString("N2");
            lblOzetOdendi.Text = "Odendi: " + odendi.ToString("N2");
        }

        private int? SeciliAidatId()
        {
            if (gridAidatlar.CurrentRow == null) return null;
            return Convert.ToInt32(gridAidatlar.CurrentRow.Cells["AidatId"].Value);
        }

        private void FormAidatListe_Load(object sender, EventArgs e)
        {
            // Grid ayarlari
            gridAidatlar.ReadOnly = true;
            gridAidatlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridAidatlar.AllowUserToAddRows = false;
            gridAidatlar.AllowUserToDeleteRows = false;
            gridAidatlar.MultiSelect = false;
            gridAidatlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Filtre combolari
            int yil = DateTime.Now.Year;
            cmbYil.DataSource = Yardimci.YilListesi(yil - 2, yil + 2);
            cmbAy.DataSource = Yardimci.AyListesi();
            cmbDurum.DataSource = Yardimci.Durumlar.ToList();

            cmbYil.SelectedItem = yil;
            cmbAy.SelectedItem = DateTime.Now.Month;
            cmbDurum.SelectedItem = "Tum";

            ListeyiYukle();
        }

        private void btnTopluOlustur_Click(object sender, EventArgs e)
        {
            int yil = (int)cmbYil.SelectedItem;
            int ay = (int)cmbAy.SelectedItem;

            // Varsayilan tutari Ayarlar'dan veya sabitten al
            decimal varsayilanTutar = 1000m;
            try
            {
                // Ayarlar tablosundan okumak istersen:
                // var dt = Veritabani.Query("SELECT AyarValue FROM Ayarlar WHERE AyarKey='VarsayilanAidat'");
                // if (dt.Rows.Count>0 && Yardimci.TryParseTutar(Convert.ToString(dt.Rows[0][0]), out var t)) varsayilanTutar = t;

                // sp_TopluAidatOlustur @Yil, @Ay, @VarsayilanTutar
                using (var cn = Veritabani.GetConn())
                using (var cmd = new SqlCommand("sp_TopluAidatOlustur", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Yil", yil);
                    cmd.Parameters.AddWithValue("@Ay", ay);
                    cmd.Parameters.AddWithValue("@VarsayilanTutar", varsayilanTutar);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Toplu aidat olusturuldu.");
                ListeyiYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Toplu olusturma hatasi: " + ex.Message);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (var frm = new FormAidatDuzenle())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    ListeyiYukle();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            int? aidatId = SeciliAidatId();
            if (!aidatId.HasValue) return;

            using (var frm = new FormAidatDuzenle(aidatId.Value))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    ListeyiYukle();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int? aidatId = SeciliAidatId();
            if (!aidatId.HasValue) return;

            if (MessageBox.Show("Bu aidat kaydini silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    Veritabani.ExecuteNonQuery("DELETE FROM Aidatlar WHERE AidatId=@id", new SqlParameter("@id", aidatId.Value));
                    ListeyiYukle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme hatasi: " + ex.Message);
                }
            }
        }

        private void btnOdemeGir_Click(object sender, EventArgs e)
        {
            int? aidatId = SeciliAidatId();
            if (!aidatId.HasValue) return;

            using (var f = new FormOdemeDuzenle(aidatId.Value))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    // Odeme eklenince durum guncellendi; listeyi tazele
                    ListeyiYukle();
                }
            }
        }

        private void gridAidatlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
