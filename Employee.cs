using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Employee
    {
        private readonly uint Id;
        private static uint counter;

        private string name;
        private string lastName;
        private int salary;
        public uint ID
        {
            get => Id;
        }
        public string Name
        {
            get => name;
            set
            {
                this.name = value;
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                this.lastName = value;
            }
        }
        public int Salary
        {
            get => salary;
            set
            {
                this.salary = value;
            }
        }
        public Employee(string name = "NoName", string lastName = "NoLastName")
        {
            this.Name = name;
            this.LastName = lastName;
            Id = ++counter;
        }
        public void WriteName()
        {
            try
            {
                Console.WriteLine("Enter Name...");
                string tmpName = Console.ReadLine();
                this.Name = tmpName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void WriteLastName()
        {
            try
            {
                Console.WriteLine("Enter LastName...");
                string tmpLastName = Console.ReadLine();
                this.LastName = tmpLastName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddSalary(int money)
        {
            checked
            {
                this.Salary += money;
            }
        }
        public void IncreaseSalary()
        {
            try
            {
                Console.WriteLine("Enter Salary...");
                string tmpSalary = Console.ReadLine();
                AddSalary(Int32.Parse(Console.ReadLine()));
            }
            catch (Exception ex)
            {
                Console.WriteLine($" 1:  {ex.Message} need correct");
            }
        }
        public override string ToString()
        {
            return $"Employee:\nName: {name}\n" +
                $"Lastname: {lastName}\n" +
                $"Salary: {salary}";
        }
    }
    class Department
    {
        List<Employee> overcrowd = new List<Employee>();
        uint Count_Employees = 0;
        public uint CountEmployees
        {
            get => Count_Employees;
            set
            {
                Count_Employees = value;
            }
        }
        public void AddStaff(Employee employee)
        {
            if (employee == null)
            {
                throw new Exception("Staff are null");
            }
            if (overcrowd.Count + 1 > Count_Employees)
            {
                throw new Exception("Overcrowded Staff");
            }
            overcrowd.Add(employee);
        }
        public void DeleteStaff(Employee employee)
        {
            if (employee == null)
            {
                throw new Exception("Staff are null");
            }
            if (overcrowd.Count - 1 > Count_Employees)
            {
                throw new Exception("No Staff");
            }
            overcrowd.Remove(employee);
        }
        public void AddNewStaff()
        {
            if (overcrowd.Count + 1 > Count_Employees)
            {
                throw new Exception("Too many Employeers");
            }
            Employee employee = new Employee();
            employee.WriteName();
            employee.WriteLastName();
            employee.IncreaseSalary();
            AddStaff(employee);
            Console.WriteLine("Employee has been added");
        }
        public Department(Employee overcrowd, uint Count_Employees)
        {
            CountEmployees = Count_Employees;
            AddStaff(overcrowd);
        }
        public override string ToString()
        {
            return $"Departament: {String.Join('\n', overcrowd)}";
        }
    }
}
