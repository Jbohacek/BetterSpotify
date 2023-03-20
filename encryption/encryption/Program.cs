using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace encryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bitos = new byte[] { 176, 36, 88, 139, 78, 237, 42, 255 };
            var has = "0C1B790311E5038A";

            var vys = Encryption.VerifyPassword("123", has, bitos);

            Console.WriteLine(vys);
            Console.WriteLine();
            //Funguje to



            var hash = Encryption.HashPasword("123", out var x);
            Console.WriteLine(hash);
            foreach (var VARIABLE in x)
            {
                Console.WriteLine(VARIABLE);
            }

            // Je potreba ulozit hash a byte[] v databazi

            /*
             * Pro otestovani musis vysledek hash zkopírovat do "has" a do "bitos" ty čisla
             */
        }

    }
}