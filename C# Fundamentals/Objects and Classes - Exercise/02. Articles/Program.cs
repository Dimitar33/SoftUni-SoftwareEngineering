using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int n = int.Parse(Console.ReadLine());

            Article art = new Article(input[0], input[1], input[2]);

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(": ");

                switch (cmd[0])
                {

                    case "Edit":

                        art.Edit(cmd[1]);

                        break;
                    case "ChangeAuthor":

                        art.ChangeAuthor(cmd[1]);

                        break;
                    case "Rename":

                        art.Rename(cmd[1]);
                            
                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine(art.ToString());

        }
        class Article
        {
            public Article(string title, string content, string author)

            {
                Title = title;
                Content = content;
                Author = author;

            }
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public void Edit(string content)
            {
                Content = content;
            }
            public void ChangeAuthor(string author)
            {
                Author = author;
            }
            public void Rename(string title)
            {
                Title = title;
            }
            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }

    }
}
