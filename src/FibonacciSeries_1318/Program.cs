using System;

namespace FibonacciSeries_1318
{
    // Lab 1, Q5: print the first n Fibonacci numbers.
    // Each term is the sum of the previous two: 0 1 1 2 3 5 8 ...
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of terms: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int first = 0, second = 1;

            Console.WriteLine("Fibonacci Series:");
            for (int i = 1; i <= n; i++)
            {
                Console.Write(first + " ");

                int next = first + second;
                first = second;
                second = next;
            }
            Console.WriteLine();
        }
    }
}
