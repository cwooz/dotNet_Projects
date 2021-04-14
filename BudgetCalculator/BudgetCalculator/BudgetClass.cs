using System;

namespace BudgetCalculator
{
    class BudgetClass
    {
        public void Budget()
        {
            var budgetName = UserInput.BudgetName();
            var budgetDate = DateTime.Now.ToString("MMddyyyy");

            Console.WriteLine("What is your monthly income?");
            int newBudget = int.Parse(Console.ReadLine());
            income = budget = newBudget;
            Utilities.LineBreak(1);

            Prompt();
            string overOrUnder = OverOrUnder(budget);

            Utilities.LineBreak(1);
            Console.WriteLine($"Your total spending this month was: ${totalExpenses:N2}");
            Console.WriteLine($"Your total spending this month was: ${totalExpenses:N2}");
            Console.WriteLine($"Your spending is: ${budget:N2} {overOrUnder} your budget of ${income}.");
            Utilities.LineBreak(1);
        }

        public void Prompt()
        {
            var budgetItems = UserInput.UserInputBudgetItems();

            foreach (var budgetItem in budgetItems)
            {
                Console.WriteLine($"How much do you spend on: {budgetItem.Name}? \t (${budgetItem.Amount})");
                spent = int.Parse(Console.ReadLine());

                Expense expense = CreateExpense(spent, budgetItem);
                (totalExpenses, budget) = Calculate(spent);
                PercentOfIncome(spent);

                Console.WriteLine("----");
                Console.WriteLine($"${expense.Amount} is: {expense.Percentage:N2}% of your total income.");
                Utilities.LineBreak(2);
            }
        }

        public double PercentOfIncome(int amount)
        {
            percent = ((double)amount / income) * 100;
            return percent;
        }

        public (int totalExpenses, int budget) Calculate(int spent)
        {
            totalExpenses += spent;
            budget -= spent;
            return (totalExpenses, budget);
        }

        public string OverOrUnder(int budget)
        {
            if (budget >= 0) return "under";
            return "over";
        }

        // CalculateVarianceFromBudgetTargetAmount()        // -- TODO --

        public Expense CreateExpense(int spent, BudgetItem budgetItem)
        {
            Expense newExpense = new Expense();
            newExpense.Id = idGenerator += 1;
            newExpense.Date = DateTime.Now.ToString("MMddyyyy");
            newExpense.Name = budgetItem.Name;
            newExpense.Amount = Convert.ToDouble(spent);
            newExpense.Target = budgetItem.Amount;
            newExpense.Percentage = PercentOfIncome(spent);

            return newExpense;
        }


        private int budget;                        // Sum of subtracting all money spent, against monthly income.
        private int spent;                         // An individual amount of money spent at one time.
        private int income;                        // Total amount coming in monthly.
        private int totalExpenses;                 // Total amount spent this month.
        private int idGenerator = 0000;            // Increment to create the next new ID.
        private double percent;                    // The amount or portion of the total.
    }
}
