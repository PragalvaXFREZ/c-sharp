using System;

namespace BitwiseShift_1318
{
    // Lab 1, Q3: bitwise left shift (<<) and right shift (>>).
    // Shifting left by 1 doubles the number; shifting right by 1 halves it
    // (integer division), because every bit moves one position.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Original Number: " + num);
            Console.WriteLine("Left Shift by 1 (num << 1): " + (num << 1));
            Console.WriteLine("Right Shift by 1 (num >> 1): " + (num >> 1));
        }
    }
}
