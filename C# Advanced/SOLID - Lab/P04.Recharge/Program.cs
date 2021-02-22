namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            Employee employee = new Employee("Pesho");
            Robot robot = new Robot("T100", 1000);

            robot.Work(212);
            employee.Sleep();
        }
    }
}
