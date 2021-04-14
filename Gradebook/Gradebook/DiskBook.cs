using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            Name = name;
        }


        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                using (TextWriter writer = File.AppendText($"{pathPlusFileName}.txt"))          //  Wrap an IDisposable 'object' with a 'using' statement, so that connection to file is disposed of upon leaving code block.
                {                                                                               // This pattern is a prefrable replacement to manualy adding 'writer.Dispose()'. Which invokes IDisposable 'interface'.
                    writer.WriteLine(grade);

                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new ArgumentException($"Invalid '{nameof(grade).ToString().ToUpper()}' of ({grade}). Values must be between 0 - 100 or 'A' through 'F'");
            }
        }


        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (TextReader reader = File.OpenText($"{pathPlusFileName}.txt"))
            {
                var line = reader.ReadLine();

                while (line != null)
                {
                    var number = double.Parse(line);

                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }


        public override event GradeAddedDelegate GradeAdded;

        private static readonly string path = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;
        private static readonly string date = DateTime.Now.ToString("MMddyyyy");
        //private static readonly string fileName = String.Concat(Name.Where(c => !Char.IsWhiteSpace(c)));
        private static readonly string fileName = "";
        private static readonly string pathPlusFileName = $"{path}\\data\\{fileName}_Grades_{date}";
    }
}
