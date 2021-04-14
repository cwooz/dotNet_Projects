using System;

namespace CollectIt
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

        public static void HaltProgramEnd()
        {
            LineBreak(3);
            Console.WriteLine("Push Enter To Continue...");
            Console.ReadLine();
        }
    }
}
