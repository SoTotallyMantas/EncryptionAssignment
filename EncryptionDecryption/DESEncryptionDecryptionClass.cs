using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;

namespace EncryptionAssignment.VigenereEncryptionDecryption
{
    internal class DESEncryptionDecryptionClass
    { 
        private static byte[] returnableIV;

        public  byte[] ReturnableIV { get => returnableIV; set => returnableIV = value; }

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
                    des.Padding = PaddingMode.PKCS7;
                    if (mode == CipherMode.ECB)
                    {
                        byte[] nullIV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                        iv = nullIV;
                    }
                    else
                    {
                        iv = des.IV;
                    }
                }

                EncryptTextToFile(text, path, key, iv, mode);

            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
        }
        public byte[] EncryptDES(string text, string normalkey, CipherMode mode)
        {
            byte[] key = Encoding.UTF8.GetBytes(normalkey);
            byte[] iv;
            try
            {
                using (DES des = DES.Create())
                {
                    des.Mode = mode;
                    if (mode == CipherMode.ECB)
                    {
                        byte[] nullIV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                        iv = nullIV;
                    }
                    else
                    {
                        iv = des.IV;
                    }
                    des.Padding = PaddingMode.PKCS7;
                }
                
                return EncryptTextToMemory(text, key, iv, mode);

            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
        }

        public string DecryptDES(string path, string normalkey, CipherMode mode)
        {
            byte[] key = Encoding.UTF8.GetBytes(normalkey);
      
                    try
                    {
                        return DecryptTextFromFile(path, key, mode);
                    }
                    catch (CryptographicException e)
                    {
                        Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                        throw;
                    }    
        }
        public string DecryptDES(byte[] encryptedbytes, string normalkey, byte[] iv, CipherMode mode)
        {
            byte[] key = Encoding.UTF8.GetBytes(normalkey);
           
                    try
                    {
                        return DecryptTextFromMemory(encryptedbytes, key, iv, mode);
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
                {
                    des.Mode = mode;
                    des.Padding = PaddingMode.PKCS7;



                    using (ICryptoTransform encryptor = des.CreateEncryptor(key, iv))
                    using (var cStream = new CryptoStream(fStream, encryptor, CryptoStreamMode.Write))
                    {
                        
                        byte[] toEncrypt = Encoding.UTF8.GetBytes(text);

                        cStream.Write(toEncrypt, 0, toEncrypt.Length);
                        
                        
                    }
                }
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("." + Convert.ToBase64String(iv));
                }


            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
        }
        public static string DecryptTextFromFile(string path, byte[] key, CipherMode mode)
        {
            try
            {
                byte[] iv;
                using (StreamReader sr = new StreamReader(path))
                {
                    string ivString = sr.ReadLine();
                    iv = Convert.FromBase64String(ivString);

                }
                    using (FileStream fStream = new FileStream(path, FileMode.Open))

                    using (DES des = DES.Create())
                    {
                        des.Mode = mode;
                        des.Padding = PaddingMode.PKCS7;


                        using (ICryptoTransform decryptor = des.CreateDecryptor(key, iv))

                        using (var cStream = new CryptoStream(fStream, decryptor, CryptoStreamMode.Read))

                        using (var sReader = new StreamReader(cStream))
                        {

                            return sReader.ReadToEnd();
                        }
                    }
                
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
        }

        
        public static byte[] EncryptTextToMemory(string text, byte[] key, byte[] iv, CipherMode mode)
        {
            
            try
            {
               
                using (MemoryStream mStream = new MemoryStream())
                {

                    using (DES des = DES.Create())
                    {
                        
                            des.Mode = mode;
                       
                            des.Padding = PaddingMode.PKCS7;
                            
                        




                        using (ICryptoTransform encryptor = des.CreateEncryptor(key, iv))

                        using (var cStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
                        {

                            byte[] toEncrypt = Encoding.UTF8.GetBytes(text);


                            cStream.Write(toEncrypt, 0, toEncrypt.Length);
                            returnableIV = iv;

                        }


                        byte[] ret = mStream.ToArray();

                        return ret;
                    }

                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
        }
        

        public void Example()
        {
            try
            {
                byte[] key;
                byte[] iv;

                // Create a new DES object to generate a random key
                // and initialization vector (IV).
                using (DES des = DES.Create())
                {
                    key = des.Key;
                    iv = des.IV;
                }

                // Create a string to encrypt.
                string original = "Here is some data to encrypt.";

                // Encrypt the string to an in-memory buffer.
                byte[] encrypted = EncryptTextToMemory(original, key, iv,CipherMode.CBC);

                // Decrypt the buffer back to a string.
                string decrypted = DecryptTextFromMemory(encrypted, key, iv, CipherMode.CBC);

                // Display the decrypted string to the console.
                Console.WriteLine(decrypted);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

       
        public static string DecryptTextFromMemory(byte[] encrypted, byte[] key, byte[] iv, CipherMode mode)
        {
            try
            {
               
                byte[] decrypted = new byte[encrypted.Length];
                int offset = 0;

                using (MemoryStream mStream = new MemoryStream(encrypted))
                {

                    using (DES des = DES.Create())
                    {
                        des.Mode = mode;
                        des.Padding = PaddingMode.PKCS7;

                        using (ICryptoTransform decryptor = des.CreateDecryptor(key, iv))

                        using (var cStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Read))
                        {
                            int read = 1;

                            while (read > 0)
                            {
                                read = cStream.Read(decrypted, offset, decrypted.Length - offset);
                                offset += read;
                            }
                        }
                    }
                }

                return Encoding.UTF8.GetString(decrypted, 0, offset);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                throw;
            }
        }
    }


}
