using System;

namespace AbstractClassDemo_1318
{
    // Lab 1, Q15: an abstract class cannot be instantiated; it forces
    // derived classes to implement its abstract members.
    abstract class Animal
    {
        public abstract void Sound();
    }

    class Dog : Animal
    {
        public override void Sound()
        {
            Console.WriteLine("Dog barks.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dog d = new Dog();
            d.Sound();
        }
    }
}
