using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt2
{
    class LFSR
    {
        string seed;
        string wiel;
        int [] generator;
        string[] wKey;
        int[] iKey;
        public LFSR(string s, string w)
        {
          

            string wiel_bez_spacji = w.Replace(" ", "");
            string output = "";
            wKey = wiel_bez_spacji.Split('+');
            iKey = new int[wKey.Length];
            for (int i = 0; i < wKey.Length; i++)
            {
               
                iKey[i] = int.Parse(wKey[i]);
            }

            generator = new int[iKey.Max()];
            string tmp = "";
            for (int i =0; i<iKey.Max(); i++)
            {
                tmp += s[i];
                generator[i] = int.Parse(tmp);
               tmp = "";
            }

        }

        public string wypisz()
        {
            string wyjscie = "";
            var number = 0;

            for (int i = generator.Count() - 1; i >= 0; i--)
            {
                wyjscie += generator[i];
                number += generator[i];
                if (i > 0)
                {
                    number <<= 1;
                }
            }

            wyjscie += " - " + number;

            return wyjscie;

        }

        public int xor(int a, int b)
        {
            if (a == b) return 0;
            else return 1;

        }

        public void iteracja()
        {
            int liczba = 0;
            for (int i = 0; i < iKey.Length; i++)
            {
                
                    liczba = xor(liczba, generator[iKey[i] - 1]);
                

            }


            for (int i = 0; i < generator.Length - 1; i++)
            {
                generator[i] = generator[i + 1];
            }
            generator[generator.Length - 1] = liczba;


        }


    }
}
