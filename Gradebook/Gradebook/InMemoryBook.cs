using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)               // base(name) Explicit reference to 'base' Class
        {
            grades = new List<double>();
            // Name = name;
        }


        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid '{nameof(grade).ToString().ToUpper()}' of ({grade}). Values must be between 0 - 100 or 'A' through 'F'");
            }
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (int index = 0; index < grades.Count; index++)
            {
                result.Add(grades[index]);
            }

            return result;
        }


        public override event GradeAddedDelegate GradeAdded;

        private List<double> grades;                    // Type Member: Field


     // public string Name { get; set; }                // Type Member: Property            // REPLACED w/ NamedObject.cs Class

     // public const string CATEGORY = "Science";       // Can't 'Write' to field in Constructor, like: readonly !!!        // By 'Value' not 'Reference', works similar to 'static field'

     // readonly string Category = "Science";           // Type Member: (readonly) Field
    }
}
