using System;

namespace ArrayAsParameter_1318
{
    // Lab 1, Q9: pass an array to a method. Arrays are reference types,
    // so the method receives a reference to the same array (no copy is made).
    internal class Program
    {
        static void DisplayArray(int[] arr)
        {
            Console.WriteLine("Array Elements:");
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] numbers = { 10, 20, 30, 40, 50 };
            DisplayArray(numbers);
        }
    }
}
