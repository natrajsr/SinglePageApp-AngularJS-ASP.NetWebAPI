using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LibraryAPI.Model.Store;

namespace LibraryAPI.Model.Factory
{
    /// <summary>
    /// In memory version of model factory
    /// </summary>
    public class InMemoryModelFactory : AbstractModelFactory
    {
        /// <summary>
        /// Returns the in memory book store instance
        /// </summary>
        /// <returns></returns>
        public override IBookStore GetBookStore()
        {            
            return InMemoryBookStore.GetBookStore();
        }
    }
}