using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>, IComparer<Book>
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public IReadOnlyList<string> Authors { get; set; }

        public Book(string Title, int Year, params string[] Authors)
        {
            this.Title = Title;
            this.Year = Year;
            this.Authors = new List<string>(Authors);
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }



        public int CompareTo(Book somebook) //IComparable related
        {
            int result = this.Year.CompareTo(somebook.Year);
            if (result == 0)
                result = this.Title.CompareTo(somebook.Title);
            return result;
        }

        public int Compare(Book x, Book y) //IComparer
        {
            int result = x.Title.CompareTo(y.Title);
            if (result == 0)
            {
                result = y.Year.CompareTo(x.Year);
            }
            return result;
        }




    }

    public class Library : IEnumerable<Book>
    {
        public List<Book> books;

        public Library()
        {
            this.books = new List<Book>();
        }
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }


      



        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }
            public void Dispose() { }
            public bool MoveNext() => ++this.currentIndex < this.books.Count;
            public void Reset() => this.currentIndex = -1;
            public Book Current => this.books[this.currentIndex];
            object IEnumerator.Current => this.Current;
        }
    }

    
}
