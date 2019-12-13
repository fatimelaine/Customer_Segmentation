using System;
using System.Globalization;
using CustomerSegmentation.Entities;
using System.Collections.Generic;

namespace CustomerSegmentation
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("How many customers will be registered? ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            List<Customer> list = new List<Customer>();

            Console.Write("Monthly goal per customer: ");
            double MonthlyGoal = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Customer #{i}: ");
                Console.Write("ID: ");
                int Id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string Name = Console.ReadLine();
                Console.Write("Email: ");
                string Email = Console.ReadLine();
                Console.Write("Monthly Amount Spent: ");
                double MonthlyAmountSpent = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Growth Potential (True/False): ");
                bool GrowthPotential = bool.Parse(Console.ReadLine());
                Console.WriteLine();

                list.Add(new Customer(Id, Name, Email, MonthlyAmountSpent, GrowthPotential, MonthlyGoal));
            }

            list.Sort(CompareCustomers);

            Console.WriteLine("REPORT:");

            foreach (Customer cr in list)
            {
                Console.WriteLine(cr);
            }
        }

        static int CompareCustomers(Customer c1, Customer c2)
        {
            return c1.MonthlyAmountSpent.CompareTo(c2.MonthlyAmountSpent);
        }
    }
}
