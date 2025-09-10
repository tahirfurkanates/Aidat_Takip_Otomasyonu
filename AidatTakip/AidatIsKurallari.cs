using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidatTakip
{
    public static class AidatIsKurallari
    {
        /// <summary>
        /// Odemeler toplamina gore Aidatlar.Durum alanini gunceller.
        /// Kural: toplam=0 -> Bekliyor, 0<toplam<tutar -> Kismi, toplam>=tutar -> Odendi
        /// </summary>
        public static void GuncelleAidatDurum(int aidatId)
        {
            const string sql = @"
SELECT a.Tutar AS AidatTutar,
       ISNULL((SELECT SUM(o.Tutar) FROM Odemeler o WHERE o.AidatId = a.AidatId), 0) AS ToplamOdeme
FROM Aidatlar a
WHERE a.AidatId = @AidatId";

            DataTable dt = Veritabani.Query(sql, new SqlParameter("@AidatId", aidatId));
            if (dt.Rows.Count == 0) return;

            decimal aidatTutar = Convert.ToDecimal(dt.Rows[0]["AidatTutar"]);
            decimal toplamOdeme = Convert.ToDecimal(dt.Rows[0]["ToplamOdeme"]);

            string yeniDurum;
            if (toplamOdeme <= 0) yeniDurum = "Bekliyor";
            else if (toplamOdeme < aidatTutar) yeniDurum = "Kismi";
            else yeniDurum = "Odendi";

            Veritabani.ExecuteNonQuery(
                "UPDATE Aidatlar SET Durum=@d WHERE AidatId=@id",
                new SqlParameter("@d", yeniDurum),
                new SqlParameter("@id", aidatId)
            );
        }
    }
}

