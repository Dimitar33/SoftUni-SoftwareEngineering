namespace Task_1._Create_enumeration_Day_with_7_values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string day = "";

            switch (num)
            {
                case 1:
                    Console.WriteLine("Monday");
                    day = "Modany";
                    break;

                case 2:
                    Console.WriteLine("Tuesday");
                    day = "Tuesday";
                    break;

                case 3:
                    Console.WriteLine("Wednesday");
                    day = "Wednesday";
                    break;

                case 4:
                    Console.WriteLine("Thursday");
                    day = "Thursday";
                    break;

                case 5:
                    Console.WriteLine("Friday");
                    day = "Friday";
                    break;

                case 6:
                    Console.WriteLine("Saturday");
                    day = "Saturday";
                    break;

                case 7:
                    Console.WriteLine("Sunday");
                    day = "Sunday";
                    break;

                default:
                    Console.WriteLine("Incorrect weekday");
                    break;
            }
            if (Weekdays.Monday.ToString() == day)
            {
                Console.WriteLine((int)Weekdays.Sunday);
            }

            else if (Weekdays.Tuesday.ToString() == day)
            {
                Console.WriteLine((int)Weekdays.Tuesday);
            }

            else if (Weekdays.Wednesday.ToString() == day)
            {
                Console.WriteLine((int)Weekdays.Wednesday);
            }

            else if (Weekdays.Thursday.ToString() == day)
            {
                Console.WriteLine((int)Weekdays.Thursday);
            }

            else if (Weekdays.Friday.ToString() == day)
            {
                Console.WriteLine((int)Weekdays.Friday);
            }

            else if (Weekdays.Saturday.ToString() == day)
            {
                Console.WriteLine((int)Weekdays.Saturday);
            }

            else if (Weekdays.Sunday.ToString() == day)
            {
                Console.WriteLine((int)Weekdays.Sunday);
            }

            else
            {
                Console.WriteLine("Incorrect day");
            }
        }
    }
}