namespace Task_6._Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 1, 2, 3, 4, 5 };

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    Console.WriteLine(array[i]);
                }
            }
            Console.WriteLine();

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            int count = array.Length - 1;

            while (count >= 0)
            {
                Console.WriteLine(array[count]);
                count--;
            }
            Console.WriteLine();

            count = array.Length - 1;

            do
            {
                Console.WriteLine(array[count]);
                count--;

            } while (count >= 0);
        }
    }
}