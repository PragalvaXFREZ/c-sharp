using System;

namespace JaggedArraySum_1318
{
    // Lab 1, Q6: jagged array — an "array of arrays" where each row
    // can have a different length. Display each row with its sum.
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[3][];
            arr[0] = new int[] { 1, 2, 3 };
            arr[1] = new int[] { 4, 5 };
            arr[2] = new int[] { 6, 7, 8, 9 };

            for (int i = 0; i < arr.Length; i++)
            {
                int sum = 0;

                Console.Write("Row " + (i + 1) + ": ");
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                    sum += arr[i][j];
                }

                Console.WriteLine("\nSum of Row " + (i + 1) + " = " + sum);
                Console.WriteLine();
            }
        }
    }
}
