using System;

namespace DiagonalSum_1318
{
    // Lab 1, Q8: sum of the principal diagonal of a square matrix —
    // the elements where the row index equals the column index.
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine("Matrix:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nSum of Principal Diagonal = " + sum);
        }
    }
}
