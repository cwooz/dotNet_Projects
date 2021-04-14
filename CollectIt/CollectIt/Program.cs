using System;
using System.Collections.Generic;

namespace CollectIt
{
    public class DepartmentCollection : SortedDictionary<string, SortedSet<Employee>>
    {
        public DepartmentCollection Add(string departmentName, Employee employee)
        {
            if (!ContainsKey(departmentName))
            {
                Add(departmentName, new SortedSet<Employee>(new EmployeeComparer()));
            }
            this[departmentName].Add(employee);

            return this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var departments = new DepartmentCollection();

            departments.Add("Sales", new Employee { Name = "Joy" })
                       .Add("Sales", new Employee { Name = "Dani" })
                       .Add("Sales", new Employee { Name = "Dani" });

            departments.Add("Engineering", new Employee { Name = "Scott" })
                       .Add("Engineering", new Employee { Name = "Chris" })
                       .Add("Engineering", new Employee { Name = "Alex" });

            foreach (var department in departments)
            {
                Console.WriteLine(department.Key);
                foreach (var employee in department.Value)
                {
                    Console.WriteLine("\t" + employee.Name);
                }
            }

            Utilities.LineBreak(3);

            // GenericCollections.RunGenericCollections();                  // Generic Collections: Testing

            Utilities.HaltProgramEnd();
        }
    }
}
