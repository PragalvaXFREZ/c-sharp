using System;

namespace MethodOverloading_1318
{
    // Lab 1, Q12: method overloading — same method name, different
    // parameter lists. The compiler picks the right one at compile time.
    class Calculate
    {
        public void Sum(int a, int b)
        {
            Console.WriteLine("Sum of two numbers: " + (a + b));
        }

        public void Sum(int a, int b, int c)
        {
            Console.WriteLine("Sum of three numbers: " + (a + b + c));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculate obj = new Calculate();
            obj.Sum(10, 20);
            obj.Sum(10, 20, 30);
        }
    }
}
