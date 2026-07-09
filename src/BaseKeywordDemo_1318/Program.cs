using System;

namespace BaseKeywordDemo_1318
{
    // Lab 1, Q17: the `base` keyword — a derived class uses it to call
    // the parent's constructor (or members). The parent constructor
    // always runs before the child's body.
    class Parent
    {
        public Parent()
        {
            Console.WriteLine("Parent Constructor");
        }
    }

    class Child : Parent
    {
        public Child() : base()
        {
            Console.WriteLine("Child Constructor");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Child obj = new Child();
        }
    }
}
