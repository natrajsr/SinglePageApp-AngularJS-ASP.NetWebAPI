SinglePageApp-AngularJS-ASP.NetWebAPI
=====================================

This project contains a simple Library admin module for books management, developed with the help of Angular JS and ASP.Net Web API.

This demonstrates both the AngularJS and ASP.Net Web API. Bootstrap.js used as presentation framework.

This application contains three different modules

1. Library API - ASP.Net Web API
2. Library API.Model - Separate module to handle view model
3. Library Manager - Single Page Web Application built with AngularJS

How the data is stored ?
------------------------

* In Memory Store has been developed at the moment
* Designed with extensibility i.e., you could add your own model store which can pull data from RDBMS Database Server

How the Data Model can be extended ?
------------------------------------

* Create a new Model Factory by extending AbstractModelFactory
* Create and develop a new model stores which connects Database Server 
* Replace the new Model factory reference with existing InMemoryModelFactory reference in ControllerFactory of Library API project

How to run this project ?
-------------------------

Library API - ASP.Net Web API

* You could host this as separate website or application inside an existing web site
* CORS enabled

Library Manager - Website / Web Application

* This can be hosted as website or application
* In order to access the Library API, we need to confugure the URL of the Library API once it is hosted
* Change js/config.js under LibraryManager application to update the URL of the Library API
* For e.g., if the hosted API URL is 'http://localhost:8080/LibraryAPI', please update the URL property in config.js as 'URL' : 'http://localhost:8080/LibraryAPI'




