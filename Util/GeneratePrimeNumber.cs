using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAssignment.Util
{
    internal class GeneratePrimeNumber
    {
        private static Random random = new Random();
        public static BigInteger GeneratePrimeNumbers(int bits)
        {
            BigInteger prime;
            do
            {
                prime = GenerateRandomBigInteger(bits);
            } while (!IsPrime(prime));
            return prime;
        }

        
        private static BigInteger GenerateRandomBigInteger(int bits)
        {
            byte[] bytes = new byte[bits / 8];
            random.NextBytes(bytes);
            bytes[bytes.Length - 1] &= (byte)0x7F; 
            return new BigInteger(bytes);
        }

       
        private static bool IsPrime(BigInteger number)
        {
            if (number <= 1)
                return false;
            if (number == 2 || number == 3)
                return true;
            if (number % 2 == 0)
                return false;

            BigInteger d = number - 1;
            int s = 0;
            while (d % 2 == 0)
            {
                d /= 2;
                s++;
            }

            for (int i = 0; i < 10; i++) 
            {
                BigInteger a = GenerateRandomBigInteger(512); 
                BigInteger x = BigInteger.ModPow(a, d, number);
                if (x == 1 || x == number - 1)
                    continue;
                for (int j = 0; j < s - 1; j++)
                {
                    x = BigInteger.ModPow(x, 2, number);
                    if (x == 1)
                        return false;
                    if (x == number - 1)
                        break;
                }
                if (x != number - 1)
                    return false;
            }

            return true;
        }
    }
}
