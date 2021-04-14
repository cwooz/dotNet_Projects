using System;

namespace GradeBook
{
    public class EnterGradesUserInput
    {
        public static void EnterGrades(IBook book)
        {
            while (true)                                                // Loop until user enter the letter 'q'
            {
                Console.WriteLine($"Enter a grade or 'q' to quit.");
                var input = Console.ReadLine();                         // User input for each grade 'number'

                if (input == "q" || input == "Q")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)                            // (Exception ex): Can be too broard at times and detrimental
                {
                    Console.WriteLine($"An Exception has been thrown: {ex.Message}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"An Exception has been thrown: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine(" ");
                    /*  Code will run after successful 'try' or after Exception 'catch'
                        Example, good place to run clean up operations, reguarless of what has happened above  */
                }
            }
        }
    }
}
