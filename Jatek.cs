using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszamjatek
{
    internal class Jatek
    {
        public string Nev { get; set; }

        public List<int> Tippek { get; set; }

        public Jatek(string sor)
        {
            string[] temp = sor.Split(' ');

            Nev = temp[temp.Length - 1];
            Tippek = new List<int>();

            for (int i = 0; i < temp.Length - 1; i++)
            {
                Tippek.Add(int.Parse(temp[i]));
            }
        }
    }
}
