using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please put in an integer:");

            int testInt = 0;
            try
            {
                testInt = int.Parse(Console.ReadLine());
            }
            catch (OverflowException)
            {
                Console.WriteLine("Integer overflow");
                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("Integer invalid");
                return;
            }

            Console.Write("All prime factors of the integer are: ");
            for (int i = 2; i <= testInt; i++)
            {
                if (testInt % i == 0)
                {
                    testInt /= i;
                    Console.Write(i + " ");
                    i = 1;
                }
            }
            Console.Write("\n");
        }
    }
}
