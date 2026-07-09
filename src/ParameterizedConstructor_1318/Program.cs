using System;

namespace ParameterizedConstructor_1318
{
    // Lab 1, Q10: a parameterized constructor lets the caller supply
    // initial values at the moment the object is created.
    class Student
    {
        private readonly int id;
        private readonly string name;

        public Student(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public void Display()
        {
            Console.WriteLine("Student ID: " + id);
            Console.WriteLine("Student Name: " + name);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(101, "Bibek Tamang");
            s1.Display();
        }
    }
}
