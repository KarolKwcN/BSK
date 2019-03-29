using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            string output;
            int N = int.Parse(textBox2.Text);
            output = Szyfrowanie(N, input);

            textBox3.Text = output;
        }

        private string Szyfrowanie(int N, string input)
        {
            input = input.Replace(" ", "");
            if (N == 1) return input;
            List<string> plotek = new List<string>();
            int n = 0;
            int inc = 1;
            for (int i = 0; i < N; i++)
            {
                plotek.Add("");
            }

            foreach (char c in input)
            {
                if (n + inc == N)
                {
                    inc = -1;
                }
                else if (n + inc == -1)
                {
                    inc = 1;
                }
                plotek[n] += c;
                n += inc;
            }

            string output = "";
            foreach (string s in plotek)
            {
                output += s;
            }
            return output;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int klucz;
            if (int.TryParse(textBox5.Text, out klucz))
            {
                if (String.IsNullOrEmpty(textBox4.Text) || klucz == 1)
                    textBox6.Text = textBox4.Text;
                else textBox6.Text = Deszyfrowanie(textBox4.Text, klucz);
            }
            else MessageBox.Show("Niepoprawny klucz");

        }

        private string Deszyfrowanie(string input, int key)
        {
            input = input.Replace(" ", "");

            List<List<int>> railFence = new List<List<int>>();
            for (int i = 0; i < key; i++) railFence.Add(new List<int>());

            int factor = 1;
            int index = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (index + factor == key)
                    factor = -1;
                else if (index + factor == -1)
                    factor = 1;

                railFence[index].Add(i);
                index += factor;
            }

            char[] result = new char[input.Length];
            int position = 0;
            foreach (var row in railFence)
            {
                foreach (var i in row)
                {
                    result[i] = input[position];
                    position++;
                }
            }

            return new string(result);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string input = textBox9.Text.Replace(" ", "");
                string output = "";
                string[] sKey = textBox8.Text.Split('-');
                int[] iKey = new int[sKey.Length];
                for (int i = 0; i < sKey.Length; i++)
                {
                    iKey[i] = int.Parse(sKey[i]);
                }
                double derivation = Convert.ToDouble(input.Length) / Convert.ToDouble(iKey.Length);
                int itemsLength = Convert.ToInt32(Math.Ceiling(derivation));
                string[] items = new string[itemsLength];

                int position = 0;
                for (int i = 0; i < itemsLength; i++)
                {
                    if (position + iKey.Length <= input.Length - 1)
                    {
                        items[i] = input.Substring(position, iKey.Length);
                    }
                    else
                    {
                        items[i] = input.Substring(position);
                    }
                    position += iKey.Length;
                }

                foreach (var item in items)
                {
                    for (int i = 0; i < iKey.Length; i++)
                    {
                        if (iKey[i] <= item.Length)
                            output += item[iKey[i] - 1];
                    }
                }

                textBox7.Text = output;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string input = textBox12.Text.Replace(" ", "");
            string output = "";
            string[] sKey = textBox11.Text.Split('-');
            int[] iKey = new int[sKey.Length];
            for (int i = 0; i < sKey.Length; i++)
            {
                iKey[i] = int.Parse(sKey[i]);
            }

            double derivation = Convert.ToDouble(input.Length) / Convert.ToDouble(iKey.Length);
            int itemsLength = Convert.ToInt32(Math.Ceiling(derivation));
            string[] items = new string[itemsLength];

            int position = 0;
            for (int i = 0; i < itemsLength; i++)
            {
                if (position + iKey.Length <= input.Length - 1)
                {
                    items[i] = input.Substring(position, iKey.Length);
                }
                else
                {
                    items[i] = input.Substring(position);
                }
                position += iKey.Length;
            }

            foreach (var item in items)
            {
                int index = 0;
                char[] chars = new char[item.Length];
                for (int i = 0; i < iKey.Length; i++)
                {
                    if (iKey[i] - 1 >= chars.Length) continue;
                    chars[iKey[i] - 1] = item[index];
                    index++;
                }
                output += new string(chars);
            }

            textBox10.Text = output;
        }
    }
}
