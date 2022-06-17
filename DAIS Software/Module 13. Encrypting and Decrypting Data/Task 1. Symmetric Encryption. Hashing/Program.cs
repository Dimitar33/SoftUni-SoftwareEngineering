using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Task_1._Symmetric_Encryption._Hashing
{
    internal class Program
    {
        public static void Main()
        {

            string pass = "secret";
            byte[] salt = Encoding.ASCII.GetBytes("asdas12dsad");

            Rfc2898DeriveBytes hashedPass = new Rfc2898DeriveBytes(pass, salt);

            using (AesManaged aes = new AesManaged())
            {
                aes.Key = hashedPass.GetBytes(aes.KeySize / 8);
                aes.IV = hashedPass.GetBytes(aes.BlockSize / 8);


                byte[] encrypted = Encription(pass, aes);

                string decripted = Decription(encrypted, aes);

                Console.WriteLine(decripted);
            }
        }
        public static byte[] Encription(string pass, Aes aes)
        {
            byte[] bytes;

            ICryptoTransform transformer = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memStream = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(memStream, transformer, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(pass);
                    }

                    bytes = memStream.ToArray();
                }
            }
            return bytes;

        }
        public static string Decription(byte[] cypher, Aes aes)
        {
            string pass = null;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(cypher))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        pass = sr.ReadToEnd();
                    }
                }
            }

            return pass;
        }
    }
}