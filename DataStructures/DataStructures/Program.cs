using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var standardBuffer = new Buffer<double>();                                  // Create new 'Standard' Buffer
            var circularBuffer = new CircularBuffer<double>(capacity: 3);               // Create new Circular Buffer with a maximum capacity of: 3

            circularBuffer.ItemDiscarded += Buffer_ItemDiscarded;                       // Subscribe to Event, capturing all 'discarded items'

            ProcessInput(circularBuffer);                                               // Enter Buffer values

            Utilities.NewSectionHeading("Items - Not Converted", 2);
            Action<double> consoleOutput = Utilities.ConsoleWriteItem;                  // Pass Event Delegate, using built-in 'Action' type            // var consoleOutput = new Printer<double>(Utilities.ConsoleWriteItem);
            circularBuffer.DumpBuffer(consoleOutput);                                   // Loop through 'raw' Buffer and Print each item to Console

            Utilities.NewSectionHeading("Items - Converted To Integer", 2);
            var bufferConvertToInt = circularBuffer.AsEnumerableOf<double, int>();      // Use converter to, conert typeof(T) to an 'integer'
            foreach (var item in bufferConvertToInt)                                    // Loop through Buffer and Print each converted item
            {
                Console.WriteLine($"Item: \t {item}");                                  // Print 'converted' Buffer to Console
            }

            Utilities.NewSectionHeading("Items - Converted To Date", 2);
            Converter<double, DateTime> converter = daysToAdd => new DateTime(2021, 1, 1).AddDays(daysToAdd);
            var bufferConvertToDates = circularBuffer.Map(converter);
            foreach (var item in bufferConvertToDates)
            {
                Console.WriteLine($"Item: \t {item}");
            }

            ProcessBuffer(circularBuffer);                                              // Calculate Buffer 'sum' and Print to Console

            Utilities.HaltProgramEnd();                                                 // HALT PROGRAM END
        }


        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                Utilities.NewSectionHeading("Enter a numeric value or enter 'q' to quit: ", 1);
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            Utilities.NewSectionHeading("Buffer Total Equals: ", 2);
            var sum = 0.0;

            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void Buffer_ItemDiscarded(object sender, ItemDiscarded_EventArgs<double> eventArgs)
        {
            Utilities.NewSectionHeading("BUFFER FULL - AN ITEM WAS DISCARDED", 2);
            Console.WriteLine($"SENDER: \t {sender} \nEVENTARGS: \t Discarding Item: {eventArgs.ItemDiscarded} \t Adding Item: {eventArgs.NewItemAdded}");
        }
    }
}
