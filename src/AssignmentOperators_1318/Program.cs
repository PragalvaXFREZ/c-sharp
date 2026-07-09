using System;

namespace AssignmentOperators_1318
{
    // Lab 1, Q4: compound assignment operators (+=, -=, *=, /=, %=).
    // Each one is shorthand: a += 5 means a = a + 5.
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            Console.WriteLine("Initial Value of a = " + a);

            a += 5;
            Console.WriteLine("After a += 5 : " + a);

            a -= 3;
            Console.WriteLine("After a -= 3 : " + a);

            a *= 2;
            Console.WriteLine("After a *= 2 : " + a);

            a /= 4;
            Console.WriteLine("After a /= 4 : " + a);

            a %= 3;
            Console.WriteLine("After a %= 3 : " + a);
        }
    }
}
