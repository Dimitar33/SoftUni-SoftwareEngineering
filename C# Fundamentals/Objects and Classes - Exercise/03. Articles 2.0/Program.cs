using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
         
            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Article art = new Article(input[0], input[1], input[2]);

                articles.Add(art);
            }
            string cmd = Console.ReadLine();

            switch (cmd)
            {
                case "title":

                    articles = articles.OrderBy(c => c.Title).ToList();

                    break;
                case "content":

                    articles = articles.OrderBy(c => c.Content).ToList();

                    break;
                case "author":

                    articles = articles.OrderBy(c => c.Author).ToList();

                    break;

                default:
                    break;
            }

            foreach (Article item in articles)
            {
                Console.WriteLine(item.ToString());
            }

            

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

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }

    }
}
