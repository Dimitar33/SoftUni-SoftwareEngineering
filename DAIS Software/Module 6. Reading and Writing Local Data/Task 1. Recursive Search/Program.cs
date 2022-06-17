namespace Task_1._Recursive_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            GetAllExes("C:");
        }

        static void GetAllExes(string path)
        {
            try
            {
                var dir = Directory.GetDirectories(path);

                if (dir.Length == 0)
                {
                    return;
                }

                var files = Directory.GetFiles(path)
                    .Where(x => Path.GetExtension(x) == ".dll" ||
                                Path.GetExtension(x) == ".exe");

                foreach (var filePath in files)
                {
                    FileInfo asd = new FileInfo(filePath);
                    Console.WriteLine(
                        $"Name: {Path.GetFileNameWithoutExtension(filePath)} \n" +
                        $"Extension: {Path.GetExtension(filePath)} \n" +
                        $"Size: {filePath.Length} Bytes \n" +
                        $"Creation date: {asd.CreationTime.ToShortDateString()} \n" +
                        $"Last modified: {asd.LastWriteTime.ToShortDateString()}\n");

                    Console.WriteLine();
                }

                foreach (var name in dir)
                {
                    GetAllExes(name);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
    }
}