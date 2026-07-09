using System;

namespace WithdrawException_1318
{
    // Lab 1, Q21: read balance and withdraw amount; display the remaining
    // balance, or throw an ApplicationException when funds are insufficient
    // and handle it with try/catch.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Balance: ");
            double balance = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Withdraw Amount: ");
            double withdraw = Convert.ToDouble(Console.ReadLine());

            try
            {
                if (balance >= withdraw)
                {
                    balance -= withdraw;
                    Console.WriteLine("Remaining Balance: " + balance);
                }
                else
                {
                    throw new ApplicationException("Insufficient Balance.");
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
