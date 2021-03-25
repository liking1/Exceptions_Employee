using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Vladislav", "Tluhovskiy");
            employee.AddSalary(1599);
            Console.WriteLine(employee);
        }
    }
}
