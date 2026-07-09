using System;

namespace StructDemo_1318
{
    // Lab 1, Q18: a struct is a value type — it lives on the stack and is
    // copied on assignment, unlike a class (reference type).
    struct Student
    {
        public int Id;
        public string Name;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student s;
            s.Id = 107;
            s.Name = "Prakash Thapa";

            Console.WriteLine("ID: " + s.Id);
            Console.WriteLine("Name: " + s.Name);
        }
    }
}
