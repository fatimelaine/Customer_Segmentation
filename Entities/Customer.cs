using System;

namespace CustomerSegmentation.Entities
{
    class Customer : IComparable<Customer>
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double MonthlyAmountSpent { get; set; }
        public bool GrowthPotential { get; set; }
        public double MonthlyGoal { get; set; }

        public Customer()
        {
        }

        public Customer(int iD, string name, string email, double monthlyAmountSpent, bool growthPotential, double monthlyGoal)
        {
            ID = iD;
            Name = name;
            Email = email;
            MonthlyAmountSpent = monthlyAmountSpent;
            GrowthPotential = growthPotential;
            MonthlyGoal = monthlyGoal;
        }

        public string Tier(double monthlyGoal, double monthlyAmountSpent, bool growthPotential)
        {

            if (monthlyAmountSpent < monthlyGoal && growthPotential == false)
            {
                return "Bronze Customer";
            }
            else if (monthlyAmountSpent < monthlyGoal && growthPotential == true)
            {
                return "Silver Customer";
            }
            else if (monthlyAmountSpent >= monthlyGoal && growthPotential == false)
            {
                return "Gold Customer";
            }
            else
            {
                return "Diamond Customer";
            }
        }

        public override string ToString()
        {
            return "ID: "
                + ID
                + ", Customer: "
                + Name
                + ", Email: "
                + Email
                + ", Tier: "
                + Tier(MonthlyGoal, MonthlyAmountSpent, GrowthPotential);
        }

        public int CompareTo(Customer other)
        {
            return MonthlyAmountSpent.CompareTo(other.MonthlyAmountSpent);
        }
    }
}