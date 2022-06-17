namespace Task_3.Convert_Parse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "false";
            int number = Convert.ToInt32("123");
            bool buleva = Convert.ToBoolean(word);
            word = buleva.ToString();
            buleva = Convert.ToBoolean(123); // => true, with 0 => false

            float flo = 12.32f;
            word = flo.ToString();
            flo = (float)Convert.ToDouble(word);
            flo = float.Parse(word);

            DateTime time = DateTime.UtcNow;

            word = time.ToString();
            time = Convert.ToDateTime(word);
            time = DateTime.Parse(word);

            Console.WriteLine(time);
        }
    }
}