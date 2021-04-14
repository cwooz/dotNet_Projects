using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetCalculator
{
    public class Utilities
    {
        public static void LineBreak(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(" ");
            }
        }

        public static void NewSectionHeading(string input, int num)
        {
            LineBreak(num);
            Console.WriteLine(input);
            Console.WriteLine("-----");
        }

        public static void HaltProgramEnd()
        {
            LineBreak(3);
            Console.WriteLine("Press Enter To Continue...");
            Console.ReadLine();
        }
    }
}
