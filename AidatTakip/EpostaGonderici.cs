using System.Net;
using System.Net.Mail;
using System.Text;

namespace AidatTakip
{
    public static class EpostaGonderici
    {
        public static void Gonder(SmtpAyar ayar, string alici, string konu, string govde, bool isHtml = false)
        {
            using (var msg = new MailMessage())
            {
                msg.From = new MailAddress(ayar.FromAdresi, ayar.FromGorunenAd ?? ayar.FromAdresi);
                msg.To.Add(new MailAddress(alici));
                msg.Subject = konu ?? "";
                msg.SubjectEncoding = Encoding.UTF8;
                msg.Body = govde ?? "";
                msg.BodyEncoding = Encoding.UTF8;
                msg.IsBodyHtml = isHtml;

                using (var smtp = new SmtpClient(ayar.Host, ayar.Port))
                {
                    smtp.EnableSsl = ayar.EnableSsl;
                    smtp.Credentials = new NetworkCredential(ayar.Kullanici, ayar.Sifre);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Timeout = 60000; // önce ayarla

                    smtp.Send(msg);
                }
            }
        }
    }
}
