using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array
{
    class Program
    {
        static void GetParams(int[] array, out int max, out int min, out int total, out double ave)
        {
            max = int.MinValue;
            min = int.MaxValue;
            total = 0;

            for (int i = 0; i < array.Length; i++)
            {
                max = (array[i] > max) ? array[i] : max;
                min = (array[i] < min) ? array[i] : min;
                total += array[i];
            }
            ave = (double)total / array.Length;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("How many integers do you want to enter?");

            int amount = 0;
            int[] array;

            try
            {
                amount = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the integers.");

                array = new int[amount];
                for (int i = 0; i < amount; i++)
                {
                    array[i] = int.Parse(Console.ReadLine());
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow input");
                return;
            }

            GetParams(array, out int maxInt, out int minInt, out int total, out double ave);
            Console.WriteLine($"max: {maxInt}, min: {minInt}, total: {total}, average: {ave}");
        }
    }
}
