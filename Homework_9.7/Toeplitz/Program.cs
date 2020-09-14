using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toeplitz
{
    class Program
    {
        public static bool IsToeplitzMatrix(int[][] matrix)
        {
            for (var c = 0; c < matrix[0].Length; c++)
                if (!IsSame(matrix, 0, c))
                    return false;

            for (var r = 0; r < matrix.Length; r++)
                if (!IsSame(matrix, r, 0))
                    return false;

            return true;
        }

        private static bool IsSame(int[][] matrix, int r, int c)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;

            var curValue = matrix[r][c];
            while (r < rows && c < cols)
                if (matrix[r++][c++] != curValue)
                    return false;

            return true;
        }

        static void Main(string[] args)
        {
            int[][] matrix =
            {
                new int[] {1,2,3,4},
                new int[] {5,1,2,3},
                new int[] {9,5,1,2}
            };
            Console.WriteLine(IsToeplitzMatrix(matrix));
        }
    }
}
