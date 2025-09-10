using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidatTakip
{
    public class SmtpAyar
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string Kullanici { get; set; }
        public string Sifre { get; set; }
        public string FromAdresi { get; set; }
        public string FromGorunenAd { get; set; }

        public static class AyarDepo
        {
            public static string GetAyar(string key, string def = null)
            {
                object o = Veritabani.ExecuteScalar(
                    "SELECT AyarValue FROM Ayarlar WHERE AyarKey=@k",
                    new SqlParameter("@k", key));
                if (o == null || o == DBNull.Value) return def;
                return Convert.ToString(o);
            }

            public static SmtpAyar GetSmtpAyar()
            {
                var a = new SmtpAyar
                {
                    Host = GetAyar("SmtpHost"),
                    FromAdresi = GetAyar("FromAdresi"),
                    FromGorunenAd = GetAyar("FromGorunenAd"),
                    Kullanici = GetAyar("SmtpKullanici"),
                    Sifre = GetAyar("SmtpSifre")
                };

                int port;
                a.Port = int.TryParse(GetAyar("SmtpPort", "587"), out port) ? port : 587;

                bool ssl;
                a.EnableSsl = bool.TryParse(GetAyar("SmtpEnableSsl", "true"), out ssl) ? ssl : true;

                if (string.IsNullOrWhiteSpace(a.Host) ||
                    string.IsNullOrWhiteSpace(a.FromAdresi) ||
                    string.IsNullOrWhiteSpace(a.Kullanici) ||
                    string.IsNullOrWhiteSpace(a.Sifre))
                    throw new InvalidOperationException("SMTP ayarlari eksik. Ayarlar tablosunu doldurun.");

                return a;
            }
        }
    }
}
