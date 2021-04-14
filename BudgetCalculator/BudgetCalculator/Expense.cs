using System;

namespace BudgetCalculator
{
    public class Expense
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }

        public int Target { get; set; }

        public double Percentage { get; set; }
    }
}
