using System;
using System.Collections.Generic;

namespace CollectIt
{
    public class GenericCollections
    {
        public static void RunGenericCollections()
        {
            Employee[] array = new Employee[]                                   // Array:    Created with a fixed size
            {
                new Employee { Name = "Alex" },
                new Employee { Name = "Scott" }
            };
            Console.WriteLine("---- Array Example ----");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Employee #{i} with Name: {array[i].Name}");
            }
            Utilities.LineBreak(2);




            List<Employee> list = new List<Employee>                            // List:    An array that can grow in size
            {
                new Employee { Name = "Alex" },
                new Employee { Name = "Scott" }
            };
            list.Add(new Employee { Name = "Chris" });
            Console.WriteLine("---- List Example ----");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"Employee #{i} with Name: {list[i].Name}");
            }
            Utilities.LineBreak(2);




            Queue<Employee> queue = new Queue<Employee>();                      // Queue:   FIFO Strategy (First-In-First-Out)
            queue.Enqueue(new Employee { Name = "Alex" });
            queue.Enqueue(new Employee { Name = "Scott" });
            queue.Enqueue(new Employee { Name = "Chris" });
            Console.WriteLine("---- Queue Example ----");
            while (queue.Count > 0)
            {
                var employee = queue.Dequeue();
                Console.WriteLine($"Employee #{queue.Count} with Name: {employee.Name}");
            }
            Utilities.LineBreak(2);




            Stack<Employee> stack = new Stack<Employee>();                      // Stack:   LIFO Strategy (Last-In-First-Out)
            stack.Push(new Employee { Name = "Alex" });
            stack.Push(new Employee { Name = "Scott" });
            stack.Push(new Employee { Name = "Chris" });
            Console.WriteLine("---- Stack Example ----");
            while (stack.Count > 0)
            {
                var employee = stack.Pop();
                Console.WriteLine($"Employee #{stack.Count} with Name: {employee.Name}");
            }
            Utilities.LineBreak(2);




            HashSet<int> hashSet = new HashSet<int>();                          // HashSet:     Unique items only. Works well with "value" types, needs help with "reference" types
            hashSet.Add(1);
            hashSet.Add(2);
            hashSet.Add(2);
            Console.WriteLine("---- HashSet Example ----");
            foreach (var item in hashSet)
            {
                Console.WriteLine($"HashSet Item: {item}");
            }
            Utilities.LineBreak(3);




            LinkedList<int> linkedList = new LinkedList<int>();                 // LinkedList:      Flexible inserts    
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            var first = linkedList.First;
            linkedList.AddAfter(first, 5);
            linkedList.AddBefore(first, 10);
            Console.WriteLine("---- LinkedList Example ----");
            var node = linkedList.First;
            while (node != null)
            {
                Console.WriteLine($"LinkedList Item: {node.Value}");
                node = node.Next;
            }
            Utilities.LineBreak(3);




            Dictionary<string, List<Employee>> employeesByDepartment = new Dictionary<string, List<Employee>>();            // Dictionary:      Great for searching and locating items by a key/value
            employeesByDepartment.Add("Engineering", new List<Employee> { new Employee { Name = "Scott" } });
            employeesByDepartment["Engineering"].Add(new Employee { Name = "Alex" });
            employeesByDepartment["Engineering"].Add(new Employee { Name = "Joy" });
            Console.WriteLine("---- Dictionary Example ----");
            foreach (var item in employeesByDepartment)
            {
                foreach (var employee in item.Value)
                {
                    Console.WriteLine($"Key: {employee.DepartmentId} and Name: {employee.Name}");
                }
            }
            Utilities.LineBreak(3);




            SortedDictionary<string, List<Employee>> employeesByNameDict = new SortedDictionary<string, List<Employee>>();                  // SortedDictionary:        Sorted, fast inserts and removals
            employeesByNameDict.Add("Sales", new List<Employee> { new Employee(), new Employee(), new Employee() });
            employeesByNameDict.Add("Engineering", new List<Employee> { new Employee(), new Employee() });
            Console.WriteLine("---- SortedDictionary Example ----");
            foreach (var item in employeesByNameDict)
            {
                Console.WriteLine("The count of employees for {0} is {1}", item.Key, item.Value.Count);
            }
            Utilities.LineBreak(3);




            SortedList<string, List<Employee>> employeesByNameList = new SortedList<string, List<Employee>>();                          // SortedList:          Sorted, memory efficient
            employeesByNameList.Add("Sales", new List<Employee> { new Employee(), new Employee(), new Employee() });
            employeesByNameList.Add("Engineering", new List<Employee> { new Employee(), new Employee() });
            Console.WriteLine("---- SortedList Example ----");
            foreach (var item in employeesByNameList)
            {
                Console.WriteLine("The count of employees for {0} is {1}", item.Key, item.Value.Count);
            }
            Utilities.LineBreak(3);




            SortedSet<int> sortedSet = new SortedSet<int>();                        // SortedSet:       Sorted, unique items only
            sortedSet.Add(3);
            sortedSet.Add(1);
            sortedSet.Add(2);
            Console.WriteLine("---- SortedSet Example ----");
            foreach (var item in sortedSet)
            {
                Console.WriteLine($"SortedSet Item: {item}");
            }
            Utilities.LineBreak(3);
        }
    }
}
