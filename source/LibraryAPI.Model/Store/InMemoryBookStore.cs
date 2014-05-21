using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Model.Store
{
    internal class InMemoryBookStore : IBookStore
    {
        /// <summary>
        /// In memory book store collection
        /// </summary>
        private List<Book> lstBooks = new List<Book>();

        /// <summary>
        /// Holds the next Book Id
        /// </summary>
        private int mNextBookId = 3;

        /// <summary>
        /// Static in memory book store reference
        /// </summary>
        private static InMemoryBookStore bookStore = null;

        /// <summary>
        /// Returns the singleton book store instance
        /// </summary>
        /// <returns>InMemoryBookStore</returns>
        public static InMemoryBookStore GetBookStore()
        {
            if (bookStore == null)
            {
                bookStore = new InMemoryBookStore();
            }
            return bookStore;
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        private InMemoryBookStore()
        {
            lstBooks.Add(new Book { Id = 1, Name = "Book 1", Author = "Author 1", Edition = "First Edition", Publisher = "XYZ Publisher", Copies = 1 });
            lstBooks.Add(new Book { Id = 2, Name = "Book 2", Author = "Author 2", Edition = "First Edition", Publisher = "ABC Publisher", Copies = 1 });
        }

        public Book Add(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("book");
            }

            book.Id = mNextBookId++;
            lstBooks.Add(book);
            return book;
        }

        public bool Remove(int bookId)
        {
            Book bookToRemove = lstBooks.Find(b => b.Id == bookId);

            if (bookToRemove == null)
            {
                return false;
            }

            lstBooks.Remove(bookToRemove);
            return true;
        }

        public bool Update(Book book)
        {
            int index = lstBooks.FindIndex(b => b.Id == book.Id);

            if (index < 0)
            {
                return false;
            }

            lstBooks.RemoveAt(index);
            lstBooks.Insert(index, book);
            return true;
        }

        public Book Get(int bookId)
        {
            return lstBooks.Find(b => b.Id == bookId);
        }

        public IEnumerable<Book> GetAll()
        {
            return lstBooks;
        }
    }
}
