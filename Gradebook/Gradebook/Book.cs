using System;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
            Name = name;
        }

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

        public abstract event GradeAddedDelegate GradeAdded;               // 'abstract' - Allows definition here, but implimentation to be done later         // 'abstract' - Keyword is implicitly 'Virtual'

     // public virtual event GradeAddedDelegate GradeAdded;                // 'virtual' - This method will allow an override later
    }
}
