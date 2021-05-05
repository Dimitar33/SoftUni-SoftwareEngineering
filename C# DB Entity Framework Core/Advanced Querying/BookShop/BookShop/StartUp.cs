namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetMostRecentBooks(db));
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

        // 06. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime datee = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .ToArray()
                .Where(x => x.ReleaseDate < datee)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price,
                    x.ReleaseDate
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToArray();

            return string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}"));
        }

        // 07. Author Search

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {

            var authors = context.Authors
                .Where(x => EF.Functions.Like(x.FirstName, $"%{input}"))
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName
                })
                .OrderBy(x => x.FullName)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(x => x.FullName));
        }

        // 08. Book Search

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => EF.Functions.Like(x.Title, $"%{input}%"))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();


            return string.Join(Environment.NewLine, books);
        }

        // 09. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {

            var books = context.Books
                .Where(x => EF.Functions.Like(x.Author.LastName, $"{input}%"))
                .Select(x => new
                {
                    x.Title,
                    AuthorName = x.Author.FirstName + " " + x.Author.LastName,
                    x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToArray();

            return string.Join(Environment.NewLine, books.Select(x => $"{x.Title} ({x.AuthorName})"));
        }

        // 10. Count Books

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(x => x.Title.Length > lengthCheck).ToArray();

            return books.Length;
        }

        // 11. Total Book Copies

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    copies = x.Books.Sum(x => x.Copies),
                    FullName = x.FirstName + " " + x.LastName
                })
                .OrderByDescending(x => x.copies)
                .ToArray();

            return string.Join(Environment.NewLine, authors.Select(x => $"{x.FullName} - {x.copies}"));
        }

        // 12. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var books = context.Categories
                .Select(x => new
                {
                    x.Name,
                    profit = x.CategoryBooks.Select(x => x.Book.Price * x.Book.Copies).Sum()
                })
                .OrderByDescending(x => x.profit)
                .ThenBy(x => x.Name)
                .ToArray();

            return string.Join(Environment.NewLine, books.Select(x => $"{x.Name} ${x.profit:f2}"));
        }

        // 13. Most Recent Books

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var books = context.Categories

                .Select(x => new
                {
                    x.Name,
                    book = x.CategoryBooks.Select(x => new 
                    {
                        x.Book.Title,
                        x.Book.ReleaseDate
                    }).OrderByDescending(x => x.ReleaseDate).Take(3)
                })
                .OrderBy(x => x.Name)
                .ToList();
               

            StringBuilder sb = new StringBuilder();

            foreach (var item in books)
            {
                sb.AppendLine($"--{item.Name}");

                foreach (var book in item.book)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        // 14. Increase Prices

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var item in books)
            {
                item.Price += 5;
            }

            context.SaveChanges();
        }

        // 15. Remove Books

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.RemoveRange(books);

            context.SaveChanges();

            return books.Count;
        }
    }
}
