using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Utils.Helpers
{
    public class Translate
    {
        private readonly Dictionary<char, char> d;
        public Translate()
        {
            string intab = "áéíóúàèìòùâêîôûäëïöüãõç";
            string outab = "aeiouaeiouaeiouaeiouaoc";
            d = Enumerable.Range(0, intab.Length).ToDictionary(i => intab[i], i => outab[i]);
        }
        public Translate(string intab, string outab)
        {
            d = Enumerable.Range(0, intab.Length).ToDictionary(i => intab[i], i => outab[i]);
        }
        public string TranslateString(string src)
        {
            System.Text.StringBuilder sb = new StringBuilder(src.Length);
            foreach (char src_c in src)
                sb.Append(d.ContainsKey(src_c) ? d[src_c] : src_c);
            return sb.ToString();
        }
    }

}
