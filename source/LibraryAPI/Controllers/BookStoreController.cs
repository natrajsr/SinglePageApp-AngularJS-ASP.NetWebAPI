using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using LibraryAPI.Model;

namespace LibraryAPI.Controllers
{
    /// <summary>
    /// The responsibility of this controller is to handle the CRUD operation requests of a book store
    /// </summary>
    public class BookStoreController : ApiController
    {
        /// <summary>
        /// In memory book store reference
        /// </summary>
        private IBookStore mBookStore = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bookStore">Singleton instance of the Book Store </param>
        public BookStoreController(IBookStore bookStore)
        {
            this.mBookStore = bookStore;
        }
         
        /// <summary>
        /// Returns all the books available in store
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> GetAllBooks()
        {
            return this.mBookStore.GetAll();
        }

        /// <summary>
        /// Returns the book with the given book id
        /// </summary>
        /// <param name="bookId">Book ID of which the book details to send</param>
        /// <returns>Book Information</returns>
        /// <exception cref="HttpResponseException">If the book id not found in the store, throws NOT FOUND exception which intern return HTTP Status code 404</exception>
        public Book GetBook(int bookId)
        {
            Book book = this.mBookStore.Get(bookId);

            if (book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return book;
        }

        /// <summary>
        /// Adds a new book in the store
        /// </summary>
        /// <param name="book">Book to be added</param>
        /// <returns>HTTP Response - 200 if book is added, 400 if the request is bad</returns>
        public HttpResponseMessage PostBook([FromBody]Book book)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            book = this.mBookStore.Add(book);
            var resp = Request.CreateResponse<Book>(HttpStatusCode.Created, book);
            resp.Headers.Location = new Uri(Url.Link("DefaultApi", new { bookId = book.Id }));
            return resp;
        }

        /// <summary>
        /// Updates the given book information
        /// </summary>
        /// <param name="book">Book to be updated</param>
        /// <returns>HTTP Response - 200 if book is added, 400 if the request is bad, 404 if the book information are invalid</returns>
        public HttpResponseMessage PutBook([FromBody]Book book)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (!this.mBookStore.Update(book))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var resp = Request.CreateResponse<Book>(HttpStatusCode.OK, book);
            resp.Headers.Location = new Uri(Url.Link("DefaultApi", new { bookId = book.Id }));
            return resp;
        }

        /// <summary>
        /// Deletes a book from the store
        /// </summary>
        /// <param name="bookId">Book Id of the book to be deleted</param>
        /// <returns>HTTP Response - 200 if book is added, 404 if the book id is invalid</returns>
        public HttpResponseMessage DeleteBook(int bookId)
        {
            if (!this.mBookStore.Remove(bookId))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
