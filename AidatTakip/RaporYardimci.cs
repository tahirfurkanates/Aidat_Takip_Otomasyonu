using System;
using System.Data;
using System.Data.SqlClient;

namespace AidatTakip
{
    public static class RaporYardimci
    {
        public static DataTable AylikTahsilatDetay(int yil, int ay)
        {
            const string sql = @"
SELECT u.UyeId, u.AdSoyad, u.Blok, u.DaireNo,
       a.Yil, a.Ay, a.Tutar AS AidatTutar, a.Durum,
       ISNULL((SELECT SUM(o.Tutar) FROM Odemeler o WHERE o.AidatId = a.AidatId),0) AS OdenenToplam,
       (a.Tutar - ISNULL((SELECT SUM(o.Tutar) FROM Odemeler o WHERE o.AidatId = a.AidatId),0)) AS Kalan
FROM Aidatlar a
JOIN Uyeler u ON u.UyeId = a.UyeId
WHERE a.Yil=@Y AND a.Ay=@A
ORDER BY u.Blok, u.DaireNo";

            return Veritabani.Query(sql, new SqlParameter("@Y", yil), new SqlParameter("@A", ay));
        }

        public static DataTable BorcluListesi(int yil, int ay)
        {
            const string sql = @"
SELECT u.UyeId, u.AdSoyad, u.Blok, u.DaireNo,
       a.Yil, a.Ay, a.Tutar AS AidatTutar,
       ISNULL((SELECT SUM(o.Tutar) FROM Odemeler o WHERE o.AidatId=a.AidatId),0) AS OdenenToplam,
       (a.Tutar - ISNULL((SELECT SUM(o.Tutar) FROM Odemeler o WHERE o.AidatId=a.AidatId),0)) AS Kalan
FROM Aidatlar a
JOIN Uyeler u ON u.UyeId = a.UyeId
WHERE a.Yil=@Y AND a.Ay=@A
  AND (a.Tutar - ISNULL((SELECT SUM(o.Tutar) FROM Odemeler o WHERE o.AidatId=a.AidatId),0)) > 0
ORDER BY Kalan DESC, u.Blok, u.DaireNo";

            return Veritabani.Query(sql, new SqlParameter("@Y", yil), new SqlParameter("@A", ay));
        }

        public static DataTable UyeEkstresi(int uyeId)
        {
            const string sql = @"
-- satir 1: Aidat
SELECT 'AIDAT' AS Tur, a.AidatId, a.Yil, a.Ay, a.Tutar AS Tutar, a.Durum AS Detay, a.OlusturmaTarihi AS Tarih
FROM Aidatlar a
WHERE a.UyeId=@U
UNION ALL
-- satir 2..n: Odeme (aidata bagli)
SELECT 'ODEME' AS Tur, o.OdemeId, a.Yil, a.Ay, o.Tutar AS Tutar, (ISNULL(o.Yontem,'') + CASE WHEN o.Aciklama IS NULL THEN '' ELSE ' - ' + o.Aciklama END) AS Detay, CAST(o.OdemeTarihi AS DATETIME) AS Tarih
FROM Odemeler o
JOIN Aidatlar a ON a.AidatId = o.AidatId
WHERE a.UyeId=@U
ORDER BY Yil, Ay, Tarih";

            return Veritabani.Query(sql, new SqlParameter("@U", uyeId));
        }
    }
}
