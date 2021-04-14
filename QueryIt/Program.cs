using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using QueryIt.Models;

namespace QueryIt
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDb>());

            using (IRepository<Employee> employeeRepository = new SqlRepository<Employee>(new EmployeeDb()))
            {
                AddEmployees(employeeRepository);

                CountEmployees(employeeRepository);

                QueryEmployees(employeeRepository);

                DumpPeople(employeeRepository);
            }
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { Name = "Scott" });
            employeeRepository.Add(new Employee { Name = "Chris" });
            employeeRepository.Commit();
        }

        private static void CountEmployees(IRepository<Employee> employeeRepository)
        {
            var count = employeeRepository.FindAll().Count();
            Console.WriteLine(count);
        }

        private static void QueryEmployees(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.FindById(2);
            Console.WriteLine(employee.Name);
        }

        private static void DumpPeople(IRepository<Employee> employeeRepository)
        {
            throw new NotImplementedException();
        }
    }
}
