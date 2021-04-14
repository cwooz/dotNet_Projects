using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public List<double> Grades;
        public int Count;
        public double Sum;
        public double Low;
        public double High;

        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var l when l >= 90:
                        return 'A';

                    case var l when l >= 80:
                        return 'B';

                    case var l when l >= 70:
                        return 'C';

                    case var l when l >= 60:
                        return 'D';

                    default:
                        return 'F';
                }
            }
        }

        public Statistics()
        {
            Count = 0;                      // Explicit Initializations.
            Sum = 0.0;                      // Technically unnecessary because dotNet runtime instantiates fields as "all-bits-off"
            Low = double.MaxValue;
            High = double.MinValue;
        }

        public void Add(double number)
        {
            Count++;
            Sum += number;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
    }
}
