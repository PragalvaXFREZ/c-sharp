using System;

namespace AutoProperties_1318
{
    // Lab 1, Q11: auto-implemented properties — the compiler generates
    // the hidden backing field, so `{ get; set; }` is all we write.
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student
            {
                Id = 104,
                Name = "Anisha Shrestha",
                Age = 21
            };

            Console.WriteLine("ID: " + s.Id);
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Age: " + s.Age);
        }
    }
}
