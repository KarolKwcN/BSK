using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt2
{
    public class Cezar
    {
        int key1;
        int key2;
        private char[] Alphabet { get; set; }
        List<int> primeNumbers;
        List<int> primeFactors;

        public Cezar(int key1, int key2)
        {
            Alphabet = new char[] { 'A', 'Ą', 'B', 'C', 'Ć', 'D', 'E', 'Ę', 'F', 'G', 'H', 'I', 'J', 'K',
                'L', 'Ł', 'M', 'N', 'Ń', 'O', 'Ó', 'P', 'R', 'S', 'Ś', 'T', 'U', 'W', 'Y', 'Z', 'Ź', 'Ż' };

            this.key1 = key1;
            this.key2 = key2;

            primeNumbers = getPrimeNumbers(130);
            primeFactors = getPrimeFactors(Alphabet.Length, primeNumbers);
            List<int> factorsForKey1 = getPrimeFactors(key1, primeNumbers);
            List<int> factorsForKey2 = getPrimeFactors(key2, primeNumbers);

            if (key1 == key2 || key1 > Alphabet.Length || key1 > Alphabet.Length)
            {
                MessageBox.Show("Wpisano niepoprawne dane");
            }

            foreach (var number in primeFactors)
            {
                foreach (var forKey1 in factorsForKey1)
                {
                    if (forKey1.Equals(number))
                    {
                        MessageBox.Show("Błąd z liczbami pierwszymi");
                        return;
                    }
                }
                foreach (var forKey2 in factorsForKey2)
                {
                    if (forKey2.Equals(number))
                    {
                        MessageBox.Show("Błąd z liczbami pierwszymi");
                        return;
                    }
                }
            }
        }

        private List<int> getPrimeFactors(int p, List<int> primeNumbers)
        {
            List<int> primeFactors = new List<int>();
            for (int i = 0; primeNumbers[i] <= p; i++)
            {
                if ((p % primeNumbers[i]) == 0)
                {
                    while ((p % primeNumbers[i] == 0))
                    {
                        p /= primeNumbers[i];
                    }
                    primeFactors.Add(primeNumbers[i]);
                }
            }

            return primeFactors;
        }
        private List<int> getPrimeNumbers(int n)
        {
            List<int> primeNumbers = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                primeNumbers.Add(i);
            }

            for (int i = 2; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    if ((j % i) == 0)
                    {
                        primeNumbers.Remove(j);
                    }
                }
            }

            return primeNumbers;
        }

    }
}
