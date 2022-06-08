using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioRecu
{
    public class ClRecu
    {
        private Hashtable taulaH = new Hashtable();

        public List<Char> QuinesConsonants(String xs)
        {
            String consonants = "BCDFGHJKLMNÑPQRSTVWXYZbcdfghjklmnñpqrstvwxyz";
            List<Char> llistaConsonants = new List<Char>();
            Char[] charArray = xs.ToCharArray();

            for (int i = 0; i < xs.Length; i++)
            {
                if(consonants.Contains(charArray[i]))
                {
                    llistaConsonants.Add(charArray[i]);
                }
            }

            return (llistaConsonants);
        }

        public List<Char> VocalsMesRepetides(String xs1, String xs2)
        {
            String vocals = "AEIOU";
            int n = 0;
            List<Char> llistaVocalsMesRepetides = new List<Char>();
            Char[] s1 = xs1.ToUpper().ToCharArray();
            Char[] s2 = xs2.ToUpper().ToCharArray();

            for (int i = 0; i < xs1.Length; i++)
            {
                if (!taulaH.Contains(s1[i]) && vocals.Contains(s1[i]))
                {
                    taulaH.Add(s1[i], 0);
                }
            }

            for (int i = 0; i < xs2.Length; i++)
            {
                if (taulaH.Contains(s2[i]))
                {
                    taulaH[s2[i]] = ((Int32)taulaH[s2[i]]) + 1;
                }
            }
            
            foreach (char k in taulaH.Keys)
            {
                n = (Int32)taulaH[k];

                if (n > 0) llistaVocalsMesRepetides.Add(k);
            }
   
            llistaVocalsMesRepetides.Sort();
            llistaVocalsMesRepetides.Reverse();

            return (llistaVocalsMesRepetides);
        }

        public String Codifica(String xs, Int32 n)
        {
            String encodedAscii = "";

            foreach (char lletra in xs)
            {
                Int32 num = Convert.ToInt32(lletra);
                num += n;
                String lletraNum = num.ToString();
                
                if (lletraNum.Length != 4)
                {
                    while (lletraNum.Length != 4)
                    {
                        lletraNum = "0" + lletraNum;
                    }
                }
                encodedAscii += lletraNum;
            }

            return encodedAscii;
        }
        public String Descodifica(String xs, Int32 n)
        {
            String decodedAscii = "";
            int qttCaracters = xs.Length / 4;

            for (int i = 0; i < qttCaracters; i++)
            {
                ///voy avanzando para cojer el grupo de numeros que toque y me lo pase a la letra que corresponde
                Int32 num = Convert.ToInt32(xs.Substring(i*4, 4));
                num -= n;

                decodedAscii += (char)num;
            }

            return decodedAscii;
        }
    }
}
