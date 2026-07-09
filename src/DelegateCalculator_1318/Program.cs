using System;

namespace DelegateCalculator_1318
{
    // Lab 1, Q19: a delegate is a type-safe reference to a method.
    // With += it becomes multicast: one call invokes every attached method.
    public delegate void Operation(int x, int y);

    public class Calculation
    {
        public static void Add(int a, int b)
        {
            Console.WriteLine("Add: " + (a + b));
        }

        public static void Subtract(int a, int b)
        {
            Console.WriteLine("Subtract: " + (a - b));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Operation op = Calculation.Add;
            op += Calculation.Subtract;   // multicast: both methods run

            op(10, 5);
        }
    }
}
