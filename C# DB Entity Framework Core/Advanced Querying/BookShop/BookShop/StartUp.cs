namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));
        }


                            // 01. Age Restriction
        public static string GetBooksByAgeRestriction
            (BookShopContext context, string command)
        {

            var restriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(x => x.AgeRestriction == restriction)
                .Select(x => x.Title)
                .OrderBy(x => x).ToArray();

            return string.Join(Environment.NewLine, books);
        }

                           // 02. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {

            var goldenBooks = context.Books
                .ToList()
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .Select(x => new
                {
                    x.Title,
                    x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToList();

            return string.Join(Environment.NewLine, goldenBooks.Select(x => x.Title));
        }

                         // 03. Books by Price

        public static string GetBooksByPrice(BookShopContext context)
        {

            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Price,
                    x.Title
                })
                .OrderByDescending(x => x.Price)
                .ToArray();
              
            return string.Join(Environment.NewLine, 
                books.Select(x => $"{x.Title} - ${x.Price:f2}"));
        }
        
                        // 04. Not Released In

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {

            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    x.Title,
                    x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToArray();

            return string.Join(Environment.NewLine, books.Select(x => x.Title));
        }

        // 05. Book Titles by Category

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split().ToList();

            var books = context.Books
                .Where(x => x.BookCategories.Any(x =>
                categories.Contains(x.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x).ToArray();

            return string.Join(Environment.NewLine, books);
        }
    }
}
