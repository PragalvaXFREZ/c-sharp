using System;

namespace InterfaceDemo_1318
{
    // Lab 1, Q16: an interface is a contract — any class that implements
    // IShape must provide a Draw method.
    interface IShape
    {
        void Draw();
    }

    class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Circle.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle();
            c.Draw();
        }
    }
}
