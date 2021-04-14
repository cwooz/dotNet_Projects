using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book;

            string bookName = InitialUserInput.BookName();              // User enter the 'name' for created book object

            string bookType = InitialUserInput.BookType();              // User selects 'type' of book object to be created

            if (bookType == "1")
            {
                book = new DiskBook(bookName);                          // Create new DiskBook object and provide a Name value
            }
            else
            {
                book = new InMemoryBook(bookName);                      // Create new InMemoryBook object and provide a Name value
            }

            book.GradeAdded += OnGradeAdded;                            // Subscribe to Event Delegate, adding onto book.GradeAdded Method Call

            EnterGradesUserInput.EnterGrades(book);                     // User input for enter 'grades' data

            var stats = book.GetStatistics();                           // Run 'All' Calculations for the Book


            /* --- PRINT OUTPUT AFTER CREATING NEW BOOK OBJECT --- */
            Console.WriteLine($"This is: {book.Name}'s - Grade Book");
            Console.WriteLine("--------------------");
            Console.WriteLine($"The lowest grade is: {stats.Low:N2}");
            Console.WriteLine($"The highest grade is: {stats.High:N2}");
            Console.WriteLine($"The average grade is: {stats.Average:N2}");
            Console.WriteLine($"The letter grade is: {stats.Letter}");
            Console.WriteLine("--------------------");
            Console.WriteLine(stats.Grades);
        }


        static void OnGradeAdded(object sender, EventArgs eventArgs)
        {
            Console.WriteLine($"A grade was added by SENDER: {sender} [and] EVENTARGS: {eventArgs}");
        }
    }
}
