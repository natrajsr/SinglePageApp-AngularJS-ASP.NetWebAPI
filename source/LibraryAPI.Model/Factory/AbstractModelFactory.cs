using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryAPI.Model.Factory
{
    /// <summary>
    /// Abstract class for Model Factory
    /// </summary>
    public abstract class AbstractModelFactory
    {
        /// <summary>
        /// Returns the Book Store instance
        /// </summary>
        /// <returns></returns>
        public abstract IBookStore GetBookStore();
    }
}