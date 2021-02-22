using System;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            var employee = new Employee("Employee");
            var manager = new Manager("Manager", new[] { "Doc 1", "Doc 2", "Doc 3" });
            var robot = new Robot("T100", 123);
            var detailsPrinter = new DetailsPrinter (new[] { employee, manager, robot });
            Console.WriteLine(detailsPrinter.PrintDetails());
        }
    }
}
