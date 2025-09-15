

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
    }
}
