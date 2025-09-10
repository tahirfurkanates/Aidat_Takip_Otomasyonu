using System;
using System.Data;
using System.Data.SqlClient;

namespace AidatTakip
{
    /// <summary>
    /// ADO.NET ile SQL Server erisimi: Properties.Settings uzerinden baglanti okur.
    /// C# 7.3 uyumlu (using var yok).
    /// </summary>
    public static class Veritabani
    {
        // Proje adin farkliyssa "AidatTakip" kismini degistir.
        private static readonly string _cs =
            global::AidatTakip.Properties.Settings.Default.AidatTakipDBConnectionString;

        /// <summary>Yeni ve acik SqlConnection dondurur.</summary>
        public static SqlConnection GetConn()
        {
            SqlConnection cn = new SqlConnection(_cs);
            cn.Open();
            return cn;
        }

        /// <summary>Tek deger donduren sorgular (SELECT COUNT(*) vb.)</summary>
        public static object ExecuteScalar(string sql, params SqlParameter[] p)
        {
            using (SqlConnection cn = GetConn())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                if (p != null && p.Length > 0) cmd.Parameters.AddRange(p);
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>SELECT sorgulari icin DataTable dondurur.</summary>
        public static DataTable Query(string sql, params SqlParameter[] p)
        {
            using (SqlConnection cn = GetConn())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                if (p != null && p.Length > 0) cmd.Parameters.AddRange(p);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        // ... Veritabani.cs icinde diger metodlarin altina ekle:
        public static int ExecuteNonQuery(string sql, params SqlParameter[] p)
        {
            using (SqlConnection cn = GetConn())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                if (p != null && p.Length > 0) cmd.Parameters.AddRange(p);
                return cmd.ExecuteNonQuery();
            }
        }

    }
}
