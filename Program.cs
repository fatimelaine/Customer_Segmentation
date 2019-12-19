using System;
using System.Globalization;
using CustomerSegmentation.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CustomerSegmentation
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }

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

            var r1 = list.Where(c => c.GrowthPotential == true && c.MonthlyAmountSpent >= MonthlyGoal).OrderBy(c => c.MonthlyAmountSpent).ThenBy(c => c.Name); 
            Print("Diamond Customers:", r1);

            var r2 = list.Where(c => c.GrowthPotential == false && c.MonthlyAmountSpent >= MonthlyGoal).OrderBy(c => c.MonthlyAmountSpent).ThenBy(c => c.Name);
            Print("Gold Customers:", r2);

            var r3 = list.Where(c => c.GrowthPotential == true && c.MonthlyAmountSpent < MonthlyGoal).OrderBy(c => c.MonthlyAmountSpent).ThenBy(c => c.Name);
            Print("Silver Customers:", r3);

            var r4 = list.Where(c => c.GrowthPotential == false && c.MonthlyAmountSpent < MonthlyGoal).OrderBy(c => c.MonthlyAmountSpent).ThenBy(c => c.Name);
            Print("Bronze Customers:", r4);
        }
    }
}
