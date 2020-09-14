using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sieve
{
    class Program
    {
        static void getPrimes(int floor, int ceil, out int[] result)
        {
            result = new int[ceil - floor + 1];

            bool[] isPrime = new bool[ceil + 1];
            for (int i = floor; i < ceil + 1; i++)
            {
                isPrime[i] = true;
            }

            int temp = 0;
            for (int i = floor; i < ceil + 1; i++)
            {
                if (isPrime[i])
                {
                    result[temp] = i;
                    for (int j = i; j < ceil + 1; j += i)
                    {
                        isPrime[j] = false;
                    }
                    temp++;
                }
            }
        }
        static void Main(string[] args)
        {
            getPrimes(2, 100, out int[] result);

            Console.Write("Prime numbers between 2 and 100: ");
            for (int i = 0; result[i] != 0; i++)
            {
                Console.Write(result[i] + " ");
            }
            Console.Write("\n");
        }
    }
}
