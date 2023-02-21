using System.Security.Cryptography;
using System.Text;

namespace BetterSpotify.Models
{
    public class Encription
    {
        public static string Encrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            byte[] data = UTF8Encoding.UTF8.GetBytes(password);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("0l1w@r"));
                using (TripleDESCryptoServiceProvider triDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = triDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        public static string Decrypt(string EncriptedPassword)
        {
            if (string.IsNullOrEmpty(EncriptedPassword)) return "";
            byte[] data = Convert.FromBase64String(EncriptedPassword);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("0l1w@r"));
                using (TripleDESCryptoServiceProvider triDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = triDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }

        public static bool Compare(string encrypted, string nonEncrypted)
        {
            return encrypted.Equals(Encrypt(nonEncrypted));
        }
    }
}
