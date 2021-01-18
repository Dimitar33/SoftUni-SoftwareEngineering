using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
   public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors;
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public IReadOnlyList<string> Authors { get; set; }

        public int CompareTo(Book other)
        {
            int result = Title.CompareTo(other.Title) ;

            if (result == 0)
            {
                result = Year.CompareTo(other.Year) * -1;
            }

            return result ;
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
