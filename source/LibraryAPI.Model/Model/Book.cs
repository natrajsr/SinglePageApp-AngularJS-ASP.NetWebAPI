using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Model
{
    /// <summary>
    /// Book Information holder
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Book Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Book Name
        /// </summary>
        [Required]
        public String Name { get; set; }

        /// <summary>
        /// Author of the book
        /// </summary>
        [Required]
        public String Author { get; set; }

        /// <summary>
        /// Edition of the book
        /// </summary>
        public String Edition { get; set; }

        /// <summary>
        /// Publisher of the book
        /// </summary>
        [Required]
        public String Publisher { get; set; }

        /// <summary>
        /// Number of copies available
        /// </summary>
        [Range(0, 10)]
        public int Copies { get; set; }
    }
}
