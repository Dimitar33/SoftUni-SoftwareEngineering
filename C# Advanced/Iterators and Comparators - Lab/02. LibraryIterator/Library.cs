using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> Books;
        private int index;
        public Library(params Book[] books)
        {
            Books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> Books;
            private int index;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                books = new List<Book>(books);
            }

            public void Dispose() { }
            public bool MoveNext() => ++index < Books.Count;
            public void Reset() => index = -1;
            public Book Current => Books[index];
            object IEnumerator.Current => Current;
        }
    }
}
