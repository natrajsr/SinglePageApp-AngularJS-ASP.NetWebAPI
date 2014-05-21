
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

using LibraryAPI.Controllers;

using LibraryAPI.Model;
using LibraryAPI.Model.Factory;

namespace LibraryAPI
{
    /// <summary>
    /// This controller factory is responsible to create API controllers 
    /// </summary>
    public class ControllerFactory
    {
        /// <summary>
        /// Reference to the model factory
        /// </summary>
        private AbstractModelFactory modelFactory = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public ControllerFactory()
        {
            modelFactory = new InMemoryModelFactory();
        }

        /// <summary>
        /// Returns the instance of the controller of the given controller type
        /// </summary>
        /// <param name="controllerType"></param>
        /// <returns>HttpController</returns>
        public IHttpController GetInstance(Type controllerType)
        {
            if (controllerType == typeof(BookStoreController))
            {
                return new BookStoreController(modelFactory.GetBookStore());
            }

            return null;
        }
    }
}