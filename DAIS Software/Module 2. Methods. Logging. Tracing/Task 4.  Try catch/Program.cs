namespace Task_4.__Try_catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyMethod("12", new[] { 122, 2, 4 });
            MyMethod("asd", new[] { 1, 2, 4 });
            MyMethod("0", new[] { 1, 2, 4 });
            MyMethod("122", new[] { 1, 2 });

        }

        static void MyMethod(string num, int[] nums)
        {

            int number = 0;
            try
            {
                if (!int.TryParse(num, out number))
                {
                    throw new ArgumentException(message: "invalid number");
                }

                if (number == 0)
                {
                    throw new DivideByZeroException();
                }

                for (int i = 0; i < 3; i++)
                {
                    if (i > nums.Length - 1)
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                Console.WriteLine((nums[0] / number).ToString());
            }

            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (IndexOutOfRangeException ex)
            {

                Console.WriteLine(ex.Message + " " + "my message");
            }
            finally
            {
                Console.WriteLine("good day");
            }

        }
    }
}