namespace Task_2._Controlling_Task_Execution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(() =>
            {
                int count = 0;
                for (int i = 0; i < 1000000000; i++)
                {
                    count++;
                }
                Console.WriteLine($"Task1 TaskId {Task.CurrentId} {count}");
            });

            Task task2 = new Task(() => Console.WriteLine($"Task2 TaskId {Task.CurrentId}"));
            Task task3 = new Task(() => Console.WriteLine($"Task3 TaskId {Task.CurrentId}"));

            task1.Start();
            Task.WaitAny(task1, task2, task3); //continue after task1 i complete
            //Task.WaitAll(task1, task2, task3); //block's the thread
            task2.Start();
            //task1.Wait(); // task2 finishes, task3 waits task1 to finish
            task3.Start();



            Task.Factory.StartNew(() => Console.WriteLine($"Factory.StartNew {Task.CurrentId}"));

            Task.Run(() => Console.WriteLine($"Task.Run {Task.CurrentId}"));

            Thread.Sleep(3000);


            //Task.Start - instance method, 2 overloads

            //Task.Factory.StartNew - instance method, 16 overloads

            //Task.Run - static method, 8 overloads

            //Task.Wait - instance method, 5 overloads

            //Task.WaitAll - static method, 5 overloads

            //Task.WaitAny - static method, 5 overloads

            //Task.Run is the lighter version of Task.Factory.StartNew, we can use Task.Factory.StartNew for more complicated cases becos it have more oprions(overloads)
        }
    }
}