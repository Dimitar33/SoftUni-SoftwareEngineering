namespace Task_7.__Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3 };

            int[,] matrix = new int[3, 3];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, i] = i;
                Console.WriteLine(matrix[i, i]);
            }

            int[][] jarray = new int[3][];

            for (int i = 0; i < jarray.GetLength(0); i++)
            {
                jarray[i] = new int[i + 1];
            }
            Console.WriteLine(jarray[2][2] = 44);
        }
    }
}