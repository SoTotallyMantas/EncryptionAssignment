using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace EncryptionAssignment.EncryptionDecryption
{
    internal class RSAEncryptionDecryption
    {
        public BigInteger Exponent{ get; set; }
        public  BigInteger Modulus { get; set; }
        public  BigInteger PrivateKey { get; set; }
        
            
        
        public RSAEncryptionDecryption()
        {
        }
        public byte[] EncryptRSA(string X , string Y,string Input)
            {
              BigInteger p = BigInteger.Parse(X);
              BigInteger q = BigInteger.Parse(Y);
                 BigInteger n = N(p, q);
                 BigInteger phi = Phi(p, q);
            
                 BigInteger e = genE(phi);
                   BigInteger d = genD(e, phi);
              
            Exponent = e;
            Modulus = n;
            PrivateKey = d;

            byte[] inputBytes = Encoding.UTF8.GetBytes(Input);
            BigInteger inputBigInteger = new BigInteger(inputBytes);
            return encrypt(inputBigInteger, e, n).ToByteArray();

        }
        public void calcprivate(string X, string Y)
        {
            BigInteger p = BigInteger.Parse(X);
            BigInteger q = BigInteger.Parse(Y);
            BigInteger n = N(p, q);
            BigInteger phi = Phi(p, q);

            BigInteger e = genE(phi);
            BigInteger d = genD(e, phi);

            Exponent = e;
            Modulus = n;
            PrivateKey = d;

            

        }
        
        public string DecryptRSA(byte[] Input,BigInteger modulus,BigInteger privateKey)
        {
            BigInteger encryptedBigInteger = new BigInteger(Input);
            byte[] decryptedBytes = decrypt(encryptedBigInteger, privateKey, modulus).ToByteArray();
            return Encoding.UTF8.GetString(decryptedBytes);
            
        }
        public static BigInteger StringToBigInteger(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);

            return new BigInteger(bytes);
        }
       

        public static string BigIntegerToString(BigInteger bigInteger)
        {
            byte[] bytes = bigInteger.ToByteArray();
            return Encoding.UTF8.GetString(bytes);
        }
        public static bool IsPrime(BigInteger n)
        {
            int k = 10;
            if (n <= 1)
                return false;
            if (n <= 3)
                return true;
            if (n % 2 == 0)
                return false;

            BigInteger d = n - 1;
            int s = 0;
            while (d % 2 == 0)
            {
                d /= 2;
                s++;
            }

            Random random = new Random();
            for (int i = 0; i < k; i++)
            {
                BigInteger a = 0;
                do
                {
                    byte[] bytes = new byte[n.ToByteArray().Length];
                    random.NextBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= n - 2);

                BigInteger x = BigInteger.ModPow(a, d, n);

                if (x == 1 || x == n - 1)
                    continue;

                for (int j = 0; j < s - 1; j++)
                {
                    x = BigInteger.ModPow(x, 2, n);
                    if (x == 1)
                        return false;
                    if (x == n - 1)
                        break;
                }

                if (x != n - 1)
                    return false;
            }

            return true;
        }
        private static BigInteger genD(BigInteger e, BigInteger phi)
        {
            BigInteger d = extendedEuclid(e, phi);
            return d;
        }
        
        private static BigInteger extendedEuclid(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m;
            BigInteger y = 0, x = 1;

            while (a > 1)
            {
                BigInteger q = a / m;
                BigInteger t = m;

                m = a % m;
                a = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if (x < 0)
                x += m0;

            return x;
        }

                                                     
        private BigInteger N(BigInteger p, BigInteger q)
        {
            return p * q;
        }
                                            
        private BigInteger Phi(BigInteger p, BigInteger q)
        {
            return (p - 1) * (q - 1);
        }
      
        private BigInteger genE(BigInteger Phi)
        {
            BigInteger e = 65537; // Commonly used public exponent
            while (gcd(e,Phi) != 1)
            {
                e++;
            }
            return e;
        }
        private static BigInteger gcd(BigInteger a, BigInteger b)
        {
            if (a == 0)
            {
                return b;
            }
            else
            {
                return gcd(b % a, a);
            }
        }

        //private BigInteger[] extEuclid(BigInteger a, BigInteger b)
        //{
        //    if(b == 0)
        //    {
        //        return new BigInteger[] { a, 1, 0 };
        //    }
        //    else
        //    {
        //        BigInteger[] values = extEuclid(b, a % b);
        //        BigInteger d = values[0];
        //        BigInteger p = values[2];
        //        BigInteger q = values[1] - (a / b) * values[2];
        //        return new BigInteger[] { d, p, q };
        //    }
        //}
        //private BigInteger CalculatePositiveD(BigInteger a, BigInteger b)
        //{
        //    BigInteger[] values = extEuclid(a, b);
        //    BigInteger d = values[1];
        //    if (d < 0)
        //    {
        //        d = (d % b + b) % b; 
        //    }
        //    return d;
        //}
        //                      */

        public static BigInteger encrypt(BigInteger input, BigInteger e, BigInteger n)
        {
            return BigInteger.ModPow(input, e, n);
        }
        public static BigInteger decrypt(BigInteger encrypted, BigInteger d, BigInteger n)
        {
            return BigInteger.ModPow(encrypted, d, n);
            

        }
    }
}
