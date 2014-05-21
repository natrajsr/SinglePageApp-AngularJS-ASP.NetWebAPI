using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace LibraryAPI
{
    /// <summary>
    /// This custom service activator becomes responsible in creating the controller for each HTTP request
    /// </summary>
    public class ServiceActivator : IHttpControllerActivator
    {
        public ServiceActivator(HttpConfiguration configuration) { }

        /// <summary>
        /// Creates and returns the respective HTTP controller for the incoming HTTP request of the given HTTP Controller type
        /// </summary>
        /// <param name="request"></param>
        /// <param name="controllerDescriptor"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        public IHttpController Create(HttpRequestMessage request
            , HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = new ControllerFactory().GetInstance(controllerType) as IHttpController;
            return controller;
        }
    }
}