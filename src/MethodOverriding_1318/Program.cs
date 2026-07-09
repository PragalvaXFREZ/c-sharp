using System;

namespace MethodOverriding_1318
{
    // Lab 1, Q13: method overriding — a derived class replaces a base
    // class method marked `virtual` using `override`. The call is resolved
    // at run time from the object's actual type, not the variable's type.
    class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("The animal makes a sound.");
        }
    }

    class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("The dog barks.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // The variable is typed Animal, but the Dog override runs.
            Animal a = new Dog();
            a.Speak();
        }
    }
}
