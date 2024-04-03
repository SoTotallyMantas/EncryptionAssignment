using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAssignment.Util
{
    internal class SmallPrimeFactorization
    {
        public  List<BigInteger> Factorize(BigInteger n)
        {
            List<BigInteger> factors = new List<BigInteger>();

            
            while (n % 2 == 0)
            {
                factors.Add(2);
                n /= 2;
            }

            
            for (BigInteger i = 3; i * i <= n; i += 2)
            {
                while (n % i == 0)
                {
                    factors.Add(i);
                    n /= i;
                }
            }

            
            if (n > 2)
                factors.Add(n);

            return factors;
        }
    }
}
