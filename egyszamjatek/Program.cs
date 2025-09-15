
namespace egyszamjatek
{
    internal class Program
    {

        static List<Jatek> lista = new List<Jatek>();

        static void Main(string[] args)
        {

            Feladat_2();

        }

        private static void Feladat_2()
        { 
            
            StreamReader sr = new StreamReader("egyszamjatek.txt");

            while (!sr.EndOfStream)
            {

                lista.Add(new Jatek(sr.ReadLine()));

            }

            sr.Close();
        }
    }
}
