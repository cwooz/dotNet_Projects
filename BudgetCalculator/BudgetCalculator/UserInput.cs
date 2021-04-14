using System;
using System.Collections.Generic;

namespace BudgetCalculator
{
    public class UserInput
    {
        public static List<BudgetItem> UserInputBudgetItems()
        {
            List<BudgetItem> budgetItems = new List<BudgetItem>();
            budgetItems.Add(new BudgetItem { Name = "Rent", Amount = 00 });
            budgetItems.Add(new BudgetItem { Name = "Electric", Amount = 00 });
            budgetItems.Add(new BudgetItem { Name = "Internet", Amount = 00 });
            budgetItems.Add(new BudgetItem { Name = "Other Home Expenses", Amount = 00 });
            budgetItems.Add(new BudgetItem { Name = "Car Payment", Amount = 00 });
            budgetItems.Add(new BudgetItem { Name = "Car Insurance", Amount = 00 });
            budgetItems.Add(new BudgetItem { Name = "Auto Pay, Small Monthy Bills", Amount = 00 });
            budgetItems.Add(new BudgetItem { Name = "Groceries", Amount = 00 });
            budgetItems.Add(new BudgetItem { Name = "Eating Out", Amount = 00 });
            budgetItems.Add(new BudgetItem { Name = "Entertainment", Amount = 00 });
            budgetItems.Add(new BudgetItem { Name = "Consumables", Amount = 00 });

            return budgetItems;
        }


        public static string BudgetName()
        {
            const int MaxLength = 25;
            Console.WriteLine("Welcome To The Budget Creation Tool - v1.0.1");
            Console.WriteLine(" ");
            Console.WriteLine("Please enter a 'Name' for this Budget:");
            string budgetName = Console.ReadLine();
            Console.WriteLine(" ");
            string budgetNameTrimmed = budgetName.Trim();

            if (budgetNameTrimmed.Length > MaxLength)
            {
                budgetNameTrimmed.Substring(0, MaxLength);
            }

            return budgetNameTrimmed;
        }

        public static string BudgetType()
        {
            while (true)
            {
                Console.WriteLine("What type of Budget would you like to create?");
                Console.WriteLine("Enter '1' to: Save Budget To Disk");
                Console.WriteLine("Enter '2' to: Store Budget In Memory");
                string userChoice = Console.ReadLine();
                Console.WriteLine(" ");

                if (userChoice == "1" || userChoice == "2")
                {
                    return userChoice;
                }
            }
        }
    }
}
