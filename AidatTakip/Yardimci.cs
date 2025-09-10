using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidatTakip
{
    public static class Yardimci
    {
        public static bool TryParseTutar(string text, out decimal tutar)
        {
            // 12,34 veya 12.34 gibi girisleri kabul etmek icin
            text = (text ?? "").Trim().Replace('.', ',');
            return decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out tutar)
                   || decimal.TryParse(text, NumberStyles.Number, CultureInfo.GetCultureInfo("tr-TR"), out tutar)
                   || decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out tutar);
        }

        public static List<int> YilListesi(int baslangic, int bitis)
        {
            var list = new List<int>();
            for (int y = baslangic; y <= bitis; y++) list.Add(y);
            return list;
        }

        public static List<int> AyListesi()
        {
            var list = new List<int>();
            for (int a = 1; a <= 12; a++) list.Add(a);
            return list;
        }

        public static string[] Durumlar = { "Tum", "Bekliyor", "Kismi", "Odendi" };
    }
}

