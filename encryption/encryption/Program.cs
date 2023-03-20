using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace encryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string plainText = "Hello, world!";
            //string password = "myPassword123";

            //string encryptedText = Encryption.Encrypt(plainText, password);
            //Console.WriteLine("Encrypted text: " + encryptedText);

            //string decryptedText = Encryption.Decrypt(encryptedText, password);
            //Console.WriteLine("Decrypted text: " + decryptedText);

            const int keySize = 64;
            const int iterations = 350000;
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
            string HashPasword(string password, out byte[] salt)
            {
                salt = RandomNumberGenerator.GetBytes(keySize);
                var hash = Rfc2898DeriveBytes.Pbkdf2(
                    Encoding.UTF8.GetBytes(password),
                    salt,
                    iterations,
                    hashAlgorithm,
                    keySize);
                return Convert.ToHexString(hash);
            }
            bool VerifyPassword(string password, string hash, byte[] salt)
            {
                var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);
                return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
            }

            var h = (HashPasword("Dobry den", out var x));

            encryption.NoSet.Default.Hash = h;
            encryption.NoSet.Default.Sol = x.ToString();
            encryption.NoSet.Default.Save();
           // (VerifyPassword("Dobry den", h, x));
            Console.WriteLine(verify);
        }

    }
}