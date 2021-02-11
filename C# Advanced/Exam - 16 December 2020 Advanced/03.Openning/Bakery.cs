using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Employees = new List<Employee>();
        }

        public List<Employee> Employees { get; set; }

        public string Name { get; }
        public int Capacity { get; }

        public int Count { get => Employees.Count;  }

        public void Add(Employee employee)
        {
            if (Employees.Count < Capacity)
            {
                Employees.Add(employee);
            }
        }
        public bool Remove(string employe)
        {
            Employee curentEmp = Employees.FirstOrDefault(c => c.Name == employe);

            if (curentEmp == null)
            {
                return false;
            }
            Employees.Remove(curentEmp);
            return true;
        }

        public Employee GetOldestEmployee()
        {
            

            return Employees.OrderByDescending(c => c.Age).First();
        }

        public Employee GetEmployee(string name)
        {
            return Employees.First(c => c.Name == name);
        }
        

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var item in Employees)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
