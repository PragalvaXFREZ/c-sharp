using System;

namespace EmployeeDetails_1318
{
    // Lab 1, Q2: read id, name, address and salary from the user and display them.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter Address: ");
            string address = Console.ReadLine() ?? "";

            Console.Write("Enter Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nEmployee Details");
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Salary: " + salary);
        }
    }
}
