namespace Task_1._Using_Task_T
{
    internal class Program
    {
        static void Main(string[] args)
        {

            long count = 0;
            int logicalProcesors = 16;

            List<Task> tasks = new List<Task>();

            //for (int i = 0; i < logicalProcesors; i++)       // without lock
            //{
            //    tasks.Add(Task.Run(() =>
            //    {
            //        for (int j = 0; j < 1000_000; j++)       
            //        {
            //            count++;
            //        }
            //    }));
            //}
            //Task.WaitAll(tasks.ToArray());
            //Console.WriteLine(count);

            var lockObj = new object();

            for (int i = 0; i < logicalProcesors; i++)           //with lock
            {
                tasks.Add(Task.Run(() =>
                {
                    for (int j = 0; j < 1000_000; j++)
                    {
                        lock (lockObj)                     
                        {
                            count++;
                        }
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine(count);

        }
    }
}