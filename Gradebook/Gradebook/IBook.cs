using System;

namespace GradeBook
{
    public interface IBook
    {
        string Name { get; }

        Statistics GetStatistics();

        void AddGrade(double grade);

        event GradeAddedDelegate GradeAdded;
    }
}
