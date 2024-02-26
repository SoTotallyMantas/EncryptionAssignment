using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EncryptionAssignment.VigenereEncryptionDecryption
{
    internal class DESEncryptionDecryptionClass
    {
        
        
        public DESEncryptionDecryptionClass()
        {

        }
        public void EncryptDES(string text, string path, string normalkey, CipherMode mode)
        {
            byte[] key = Encoding.UTF8.GetBytes(normalkey);
            byte[] iv;
            try
            {
                using (DES des = DES.Create())
                {
                    des.Mode = mode;
                    //key = des.Key;
                    iv = des.IV;
                }
                EncryptTextToFile(text, path, key, iv, mode);

            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
        }
        public string DecryptDES(string path, string normalkey, byte[] iv, CipherMode mode)
        {
            byte[] key = Encoding.UTF8.GetBytes(normalkey);
            try
            {
                return DecryptTextFromFile(path, key, iv, mode);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
        }
      
        public static void EncryptTextToFile(string text, string path, byte[] key, byte[] iv, CipherMode mode)
        {
            try
            {
                using (FileStream fStream = new FileStream(path, FileMode.Create))

                using (DES des = DES.Create())
                
                    
                

                   

                using (ICryptoTransform encryptor = des.CreateEncryptor(key, iv))
                using (var cStream = new CryptoStream(fStream, encryptor, CryptoStreamMode.Write))
                {
                    des.Mode = mode;
                    byte[] toEncrypt = Encoding.UTF8.GetBytes(text);

                    cStream.Write(toEncrypt, 0, toEncrypt.Length);
                }

                
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
        }
        public static string DecryptTextFromFile(string path, byte[] key , byte[] iv, CipherMode mode)
        {
            try
            {
                using (FileStream fStream = new FileStream(path, FileMode.Open))

                using (DES des = DES.Create())

                using (ICryptoTransform decryptor = des.CreateDecryptor(key, iv))

                using (var cStream = new CryptoStream(fStream, decryptor, CryptoStreamMode.Read))

                using (var sReader = new StreamReader(cStream))
                {
                    des.Mode = mode;
                    return sReader.ReadToEnd();
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
        }

    }
    
    
}
