using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Model
{
    /// <summary>
    /// Book Store interface
    /// </summary>
    public interface IBookStore
    {
        /// <summary>
        /// Adds a new book to the store
        /// </summary>
        /// <param name="book">Book Information</param>
        /// <returns>Updated book information</returns>
        Book Add(Book book);
        /// <summary>
        /// Removes the book from store of the given book id
        /// </summary>
        /// <param name="bookId">Book Id of the book to removed</param>
        /// <returns>true if removed, else false</returns>
        bool Remove(int bookId);
        /// <summary>
        /// Updates the book of a given book id
        /// </summary>
        /// <param name="book">Book Details to be updated</param>
        /// <returns>true if updated, else false</returns>
        bool Update(Book book);
        /// <summary>
        /// Returns the book reference of the given book id
        /// </summary>
        /// <param name="bookId">Book Id of the book to be given</param>
        /// <returns>Book Refernce</returns>
        Book Get(int bookId);
        /// <summary>
        /// Returns all the book references
        /// </summary>
        /// <returns>Enumerable Collection of Books</returns>
        IEnumerable<Book> GetAll();
    }    
}