using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidatTakip
{
    public static class SablonMotoru
    {
        public static string Doldur(string sablon, Dictionary<string, string> map)
        {
            if (string.IsNullOrEmpty(sablon)) return string.Empty;
            string s = sablon;
            foreach (var kv in map)
                s = s.Replace("{" + kv.Key + "}", kv.Value ?? "");
            return s;
        }
    }
}
