using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> company = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                Employee employee = new Employee();              

                employee.Name = data[0];
                employee.Salary = double.Parse( data[1]);
                employee.Department = data[2];

                company.Add(employee);
              
            }

            var departments = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string newDep = company[i].Department;
                double newSalary = company[i].Salary;

                if (!departments.ContainsKey(newDep))
                {
                    departments[newDep] = new List<double>();
                }
                departments[newDep].Add(newSalary);
            }

            string averageValue = departments.OrderByDescending(c => c.Value.Average()).First().Key;

            company = company.Where(c => c.Department == averageValue).OrderByDescending(c => c.Salary).ToList();

            Console.WriteLine($"Highest Average Salary: {averageValue}");

            foreach (Employee item in company)
            {
                Console.WriteLine($"{item.Name} {item.Salary:f2}");
            }
        }

        class Employee
        {
            public string Name { get; set; }
            public double Salary { get; set; }
            public string Department { get; set; }

        }
    }
}
