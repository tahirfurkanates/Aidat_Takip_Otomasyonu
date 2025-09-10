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
    public partial class FormUyeListe: Form
    {
        public FormUyeListe()
        {
            InitializeComponent();
        }

        private void FormUyeListe_Load(object sender, EventArgs e)
        {
            // Grid ayarlari
            gridUyeler.ReadOnly = true;
            gridUyeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridUyeler.AllowUserToAddRows = false;
            gridUyeler.AllowUserToDeleteRows = false;
            gridUyeler.MultiSelect = false;
            gridUyeler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            UyeleriListele();
        }
        private void UyeleriListele(string filtre = "")
        {
            string sql = @"
SELECT UyeId, AdSoyad, Blok, DaireNo, Telefon, Email, AktifMi, Notlar
FROM Uyeler
WHERE (@f = '' OR AdSoyad LIKE '%' + @f + '%' OR Blok LIKE '%' + @f + '%' OR DaireNo LIKE '%' + @f + '%')
AND (@aktif=0 OR AktifMi=1)
ORDER BY Blok, DaireNo";

            DataTable dt = Veritabani.Query(sql,
                new SqlParameter("@f", filtre),
                new SqlParameter("@aktif", chkSadeceAktif.Checked ? 1 : 0));

            gridUyeler.DataSource = dt;
            if (gridUyeler.Columns.Contains("UyeId")) gridUyeler.Columns["UyeId"].HeaderText = "Uye Id";
            if (gridUyeler.Columns.Contains("AdSoyad")) gridUyeler.Columns["AdSoyad"].HeaderText = "Ad Soyad";
            if (gridUyeler.Columns.Contains("DaireNo")) gridUyeler.Columns["DaireNo"].HeaderText = "Daire No";
            if (gridUyeler.Columns.Contains("AktifMi")) gridUyeler.Columns["AktifMi"].HeaderText = "Aktif";
        }
        private void gridUyeler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            UyeleriListele(txtAra.Text.Trim());
        }

        private void chkSadeceAktif_CheckedChanged(object sender, EventArgs e)
        {
            UyeleriListele(txtAra.Text.Trim());
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (FormUyeDuzenle frm = new FormUyeDuzenle())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    UyeleriListele(txtAra.Text.Trim());
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (gridUyeler.CurrentRow == null) return;
            var cell = gridUyeler.CurrentRow.Cells["UyeId"]?.Value;
            if (cell == null || cell == DBNull.Value) return;

            int uyeId = Convert.ToInt32(cell);
            using (var frm = new FormUyeDuzenle(uyeId))
                if (frm.ShowDialog() == DialogResult.OK)
                    UyeleriListele(txtAra.Text.Trim());
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridUyeler.CurrentRow == null) return;
            int uyeId = Convert.ToInt32(gridUyeler.CurrentRow.Cells["UyeId"].Value);

            if (MessageBox.Show("Bu uyeyi silmek istiyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                string sql = "DELETE FROM Uyeler WHERE UyeId=@id";
                int n = Veritabani.ExecuteNonQuery(sql, new SqlParameter("@id", uyeId));
                if (n > 0)
                    UyeleriListele(txtAra.Text.Trim());
                else
                    MessageBox.Show("Silinecek kayit bulunamadi.");
            }
            catch (SqlException ex) when (ex.Number == 547) // FK violation
            {
                MessageBox.Show("Bu uye ile iliskili aidat/odeme kayitlari var. Once bagli kayitlari siliniz veya uyeyi pasif yapiniz.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme hatasi: " + ex.Message);
            }
        }

        private void btnAktifPasif_Click(object sender, EventArgs e)
        {
            if (gridUyeler.CurrentRow == null) return;

            int uyeId = Convert.ToInt32(gridUyeler.CurrentRow.Cells["UyeId"].Value);
            bool aktif = Convert.ToBoolean(gridUyeler.CurrentRow.Cells["AktifMi"].Value);

            try
            {
                string sql = "UPDATE Uyeler SET AktifMi=@a WHERE UyeId=@id";
                int n = Veritabani.ExecuteNonQuery(sql,
                            new SqlParameter("@a", !aktif),
                            new SqlParameter("@id", uyeId));

                if (n > 0)
                    UyeleriListele(txtAra.Text.Trim());
                else
                    MessageBox.Show("Guncellenecek kayit bulunamadi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Guncelleme hatasi: " + ex.Message);
            }
        }
        private void gridUyeler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnDuzenle_Click(sender, e);
        }
    }
}
