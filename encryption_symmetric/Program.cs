using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/*
 * Symmetric encryption is the encryption in which you send the key along with the data so that the user can
 * decrypt the data with the same key. It is also called shared secret encryption.
 * 
 * Data is secure due to symmetric encryption but it should travel to an authorized person as a key also
 * travels with the data. Once the data goes to an unauthorized person, data becomes compromised as the
 * receiver could decrypt data with the received key.
 * 
 * 
 * AES (Advanced Encryption Standard) is a symmetric algorithm. It was designed for both
 * software and hardware. It has support for 128-bit data and 128,192,256-bit key.
 * 
 * DES (Data Encryption Standard) is a symmetric algorithm published by National Institute
 * of Standard and Technology (NIST).
 * 
 * RC2 (Ron’s Code or Rivest Cipher) also known as ARC2 is a symmetric algorithm designed
 * by Ron Rivest.
 * 
 * Rijndael is symmetric algorithm chosen by NSA as a Advanced Encryption Standard (AES).
 * 
 * TripleDes also known as 3DES (Triple Data Encryption Standard) applies DES algorithm
 * three times to each data block.
 */

namespace encryption_symmetric
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Secret text";

            TestCrypto<AesManaged>(text, "password", "salt");
            TestCrypto<DESCryptoServiceProvider>(text, "password", "salt");
            TestCrypto<TripleDESCryptoServiceProvider>(text, "password", "salt");
            TestCrypto<RijndaelManaged>(text, "password", "salt");

            Console.ReadKey();
        }

        static void TestCrypto<T>(string Text, string Password, string Salt)
            where T : SymmetricAlgorithm, new()
        {
            string encrypted = CipherUtility.Encrypt<T>(Text, Password, Salt);
            string decrypted = CipherUtility.Decrypt<T>(encrypted, Password, Salt);

            Console.WriteLine(typeof(T));
            Console.WriteLine("Encrypted Data is: " + encrypted);
            Console.WriteLine("Decrypted Data is: " + decrypted);
            Console.WriteLine("----------------------------------------<");
        }
    }

    public class CipherUtility
    {
        public static string Encrypt<T>(string Text, string Password, string Salt)
            where T: SymmetricAlgorithm, new()
        {
            DeriveBytes rgb = new Rfc2898DeriveBytes(Password, Encoding.Unicode.GetBytes(Salt));

            SymmetricAlgorithm symmetricAlgo = new T();

            byte[] key = rgb.GetBytes(symmetricAlgo.KeySize >> 3);
            byte[] iv = rgb.GetBytes(symmetricAlgo.BlockSize >> 3);

            ICryptoTransform encryptor = symmetricAlgo.CreateEncryptor(key, iv);

            using (MemoryStream buffer = new MemoryStream())
            {
                using (CryptoStream stream = new CryptoStream(buffer, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
                    {
                        writer.Write(Text);
                    }
                }

                return Convert.ToBase64String(buffer.ToArray());
            }

            /*
            byte[] textDataInBytes = Encoding.UTF8.GetBytes(Text);
            byte[] cipherDataInBytes = encryptor.TransformFinalBlock(textDataInBytes, 0, textDataInBytes.Length);
            return Convert.ToBase64String(cipherDataInBytes);
            */
        }

        public static string Decrypt<T>(string Text, string Password, string Salt)
            where T : SymmetricAlgorithm, new()
        {
            DeriveBytes rgb = new Rfc2898DeriveBytes(Password, Encoding.Unicode.GetBytes(Salt));

            SymmetricAlgorithm symmetricAlgo = new T();

            byte[] key = rgb.GetBytes(symmetricAlgo.KeySize >> 3);
            byte[] iv = rgb.GetBytes(symmetricAlgo.BlockSize >> 3);

            ICryptoTransform decryptor = symmetricAlgo.CreateDecryptor(key, iv);
            
            using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(Text)))
            {
                using (CryptoStream stream = new CryptoStream(buffer, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            
            /*
            byte[] cipherTextDataInBytes = Convert.FromBase64String(Text);
            byte[] plainDataInBytes = decryptor.TransformFinalBlock(cipherTextDataInBytes, 0, cipherTextDataInBytes.Length);
            return Encoding.UTF8.GetString(plainDataInBytes);
            */
        }
    }
}
