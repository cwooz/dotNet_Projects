using System;

namespace DataStructures
{
    public static class Utilities
    {
        public static void LineBreak(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(" ");
            }
        }

        public static void ConsoleWriteItem(double data)
        {
            Console.WriteLine($"Item: \t {data}");
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
