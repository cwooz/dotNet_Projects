using System;

namespace GradeBook
{
    public class InitialUserInput
    {
        public static string BookName()
        {
            const int MaxLength = 25;

            Console.WriteLine("Welcome To The Gradebook Creation Tool - v1.0.1");
            Console.WriteLine(" ");
            Console.WriteLine("Please enter a 'Name' for this Gradebook:");
            string userName = Console.ReadLine();
            Console.WriteLine(" ");

            string userNameTrimmed = userName.Trim();

            if (userNameTrimmed.Length > MaxLength)
            {
                userNameTrimmed.Substring(0, MaxLength);
            }

            return userNameTrimmed;
        }
        
        public static string BookType()
        {
            while (true)
            {
                Console.WriteLine("What type of Gradebook would you like to create?");
                Console.WriteLine("Enter '1' to: Save Gradebook To Disk");
                Console.WriteLine("Enter '2' to: Store Gradebook In Memory");
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
