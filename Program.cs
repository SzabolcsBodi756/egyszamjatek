

using System.Globalization;

namespace egyszamjatek
{
    internal class Program
    {

        static List<Jatek> jatekosok = new List<Jatek>();

        static void Main(string[] args)
        {

            Feladat_2();

            Feladat_3();

            Feladat_4();

            Feladat_5();

            Feladat_6();

            int bekertSzam = Feladat_7();

            Feladat_8(bekertSzam);

            Feladat_9(bekertSzam);

            Feladat_10(bekertSzam);

        }

        private static void Feladat_2()
        { 
            
            StreamReader sr = new StreamReader("egyszamjatek.txt");

            while (!sr.EndOfStream)
            {

                jatekosok.Add(new Jatek(sr.ReadLine()));

            }

            sr.Close();
        }

        private static void Feladat_3()
        {
            Console.WriteLine($"3. feladat: Játékosok száma: {jatekosok.Count}");
        }

        private static void Feladat_4()
        {
            Console.WriteLine($"4. feladat: Játékosok száma: {jatekosok[0].Tippek.Count}");
        }

        private static void Feladat_5()
        {
            int i = 0;

            while ( i < jatekosok.Count && jatekosok[i].Tippek[0] != 1)
            {
                i++;
            }
            if (i < jatekosok.Count)
            {
                Console.WriteLine($"5. feladat: Az első fordulóban volt egyes tipp");
            }
            else
            {
                Console.WriteLine($"5. feladat: Az első fordulóban nem volt egyes tipp");
            }
        }

        private static void Feladat_6()
        {

            int max = 0;

            foreach (var item in jatekosok)
            {
                for (int i = 0; i < item.Tippek.Count; i++)
                {
                    if (item.Tippek[i] > max)
                    {
                        max = item.Tippek[i];
                    }
                }
            }

            Console.WriteLine($"6. feladat: A legnagyobb tipp a fordulók során: {max}");

        }

        private static int Feladat_7()
        {

            Console.WriteLine("7. feladat: Kérem a forduló sorszámát [1-10]:");

            int bekertSzam = Convert.ToInt32(Console.ReadLine());

            if (1 !> bekertSzam || bekertSzam !> 10)
            {
                bekertSzam = 1;
            }

            return bekertSzam;

        }

       private static void Feladat_8(int bekertSzam)
       {

            int min = 100;

            Dictionary<int, int> tippekSzama = new Dictionary<int, int>();

            for (int i = 0; i < jatekosok.Count; i++)
            {

                if (!tippekSzama.ContainsKey(jatekosok[i].Tippek[bekertSzam - 1]))
                {
                    tippekSzama.Add(jatekosok[i].Tippek[bekertSzam - 1], 1);
                }
                else
                {
                    tippekSzama[jatekosok[i].Tippek[bekertSzam - 1]]++;
                }
            }

            foreach (var item in tippekSzama)
            {

                if (item.Value < 2)
                {

                    if (item.Key < min)
                    {
                        min = item.Key;
                    }

                }
            }

            if (min == 100)
            {
                min = -1;
                Console.WriteLine("Nem volt egyedi tipp a megadott fordulóban!");
            }
            else
            {
                Console.WriteLine($"A nyertes tipp a megadott fordulóban: {min}");
            }
        }

        private static void Feladat_9(int bekertSzam)
        {

            string nyertes = "";

            int min = 100;

            Dictionary<int, int> tippekSzama = new Dictionary<int, int>();

            for (int i = 0; i < jatekosok.Count; i++)
            {

                if (!tippekSzama.ContainsKey(jatekosok[i].Tippek[bekertSzam - 1]))
                {
                    tippekSzama.Add(jatekosok[i].Tippek[bekertSzam - 1], 1);
                }
                else
                {
                    tippekSzama[jatekosok[i].Tippek[bekertSzam - 1]]++;
                }
            }

            foreach (var item in tippekSzama)
            {

                if (item.Value < 2)
                {
                    if (item.Key < min)
                    {
                        min = item.Key;
                    }

                }
            }

            if (min == 100)
            {
                min = -1;
                Console.WriteLine("Nem volt nyertes a megadott fordulóban!");
            }
            else
            {
                for (int i = 0; i < jatekosok.Count; i++)
                {
                    if (min == jatekosok[i].Tippek[bekertSzam - 1])
                    {
                        nyertes = jatekosok[i].Nev;
                    }
                }

                Console.WriteLine($"A megadott forduló nyertese: {nyertes}");
            }
        }

        private static void Feladat_10(int bekertSzam)
        {

            StreamWriter sw = new StreamWriter("C:\\Users\\szabo\\source\\repos\\egyszamjatek\\egyszamjatek\\nyertes.txt");

            string nyertes = "";

            int min = 100;

            Dictionary<int, int> tippekSzama = new Dictionary<int, int>();

            for (int i = 0; i < jatekosok.Count; i++)
            {

                if (!tippekSzama.ContainsKey(jatekosok[i].Tippek[bekertSzam - 1]))
                {
                    tippekSzama.Add(jatekosok[i].Tippek[bekertSzam - 1], 1);
                }
                else
                {
                    tippekSzama[jatekosok[i].Tippek[bekertSzam - 1]]++;
                }
            }

            foreach (var item in tippekSzama)
            {

                if (item.Value < 2)
                {

                    if (item.Key < min)
                    {
                        min = item.Key;
                    }

                }
            }

            if (min == 100)
            {
                min = -1;
                //Nem volt nyertes
            }
            else
            {
                for (int i = 0; i < jatekosok.Count; i++)
                {
                    if (min == jatekosok[i].Tippek[bekertSzam - 1])
                    {
                        nyertes = jatekosok[i].Nev;
                    }
                }

                sw.WriteLine($"Forduló sorszáma: {bekertSzam}");
                sw.WriteLine($"Nyertes Tipp: {min}");
                sw.WriteLine($"Nyertes Játékos: {nyertes}");

                sw.Close();
            }
        }
    }
}
