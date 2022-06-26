namespace Task_4._Reverse_file_lines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\programs\no pass.txt";

            ReadAndReverse(path);

        }

        public static void ReadAndReverse(string path)
        {
            var data = File.ReadAllLines(path);

            for (int i = 0; i < data.Length / 2; i++)
            {
                var temp = data[i];
                data[i] = data[data.Length - 1 - i];
                data[data.Length - 1 - i] = temp;
            }

            File.WriteAllLines("E:\\reversed.txt", data);
            Console.WriteLine(string.Join(Environment.NewLine, data));
        }
    }
}