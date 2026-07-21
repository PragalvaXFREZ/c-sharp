using System;

namespace MethodHiding_1318
{
    // Lab 1, Q14: method hiding — the derived class declares a method with
    // the same name using `new`. Unlike overriding, the call is resolved
    // from the variable's compile-time type.
    class Parent
    {
        public void Display()
        {
            Console.WriteLine("This is Parent class.");
        }
    }

    class Child : Parent
    {
        public new void Display()
        {
            Console.WriteLine("This is Child class.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Child obj = new Child();
            obj.Display();          // Child's method — variable type is Child

            Parent p = obj;
            p.Display();            // Parent's method — hiding is not polymorphic
        }
    }
}
