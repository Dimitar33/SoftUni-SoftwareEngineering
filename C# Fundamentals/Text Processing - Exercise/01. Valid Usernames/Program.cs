using System;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < usernames.Length; i++)
            {
                if (usernames[i].Length > 16 || usernames[i].Length < 3)
                {
                    continue;
                }
                string word = usernames[i];
                bool isTrue = true;

                for (int j = 0; j < word.Length; j++)
                {
                    if (!(char.IsLetterOrDigit(word[j]) || word[j] == '-' || word[j] == '_'))
                    {
                        isTrue = false;
                    }

                }
                if (isTrue)
                {

                    Console.WriteLine(word);
                }

            }
        }
    }
}
