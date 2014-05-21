/** 
 * Library App Module 
 */
var libraryApp = angular.module('libraryApp', []);

/**
 * This controller is responsible to handle the user operations such as 
 * Create/Edit/Delete/List on book store of Library system.
 * 
 * This module interacts with the Library API Server module and updates the data accordingly.
 * Also updates the UI back when it receives the response from the server
 */
libraryApp.controller('BookCtrl', function ($scope, $http) {

    /* This object is in bind with the Add and Edit form */
    $scope.book = {};

    /* This object holds the complete book store data set*/
    $scope.books = [];

    /* Refreshes the book list */
    $scope.refreshBookList = function () {
        $('#loading td').text("Loading...");
        $http.get(APIConfig.URL + 'api/bookstore/getall')
            .success(function (data) {
                $scope.books = angular.copy(data);
                $('#loading').addClass('hide');
            })
            .error(function(data) {
                $('#loading td').text("Problem while retrieving the book list!");
            });
    };   
    $scope.refreshBookList();

    /* The following logic is written to approve the form data before submitting. i.e., only updates 
     * the data to the server when there is a change
     */
    $scope.master = {};

    $scope.update = function (user) {
        $scope.master = angular.copy(user);
    };

    $scope.isUnchanged = function (user) {
        return angular.equals(user, $scope.master);
    };

    $scope.reset = function () {
        $scope.user = angular.copy($scope.master);
    };

    $scope.reset();

    /* Resets the form data */
    $scope.resetForm = function (form) {
        angular.copy({}, form);
    }

    /* Updates the book data to the server */
    $scope.updateBook = function (valid) {

        if (!valid) {
            return false;
        }

        var type = $('#editType').val();
        var method = (type == "Add" ? "post" : "put");

        $('#loading').removeClass('hide');
        $('#loading td').text("Loading...");

        var request = $http({
                method: (type == "Add" ? "post" : "put"),
                url: APIConfig.URL + "api/bookstore",
                data: JSON.stringify($scope.book)
            })
            .success(function (book) {
                if (method == "put") {
                    $scope.refreshBookList();
                } else {
                    $scope.books.push(book);
                }            
                $('#loading').addClass('hide');
            })
            .error(function (data) {
                $('#loading td').text("Problem while updating the book details!");
            });

        $('#editPopup').modal('hide');
    };

    /* Resets the form to get ready to add a new book*/
    $scope.addBook = function () {
        $('#addEditHeader').text('Add New Book');
        $('#editType').val("Add");

        $scope.resetForm($scope.book);
        $scope.form.$setPristine();
    };

    /* Readies the form to edit a selected book*/
    $scope.editBook = function (id) {
        $('#addEditHeader').text('Edit Book');
        $('#editType').val("Edit");

        $($scope.books).each(function (index, book) {
            if (book.Id == parseInt(id)) {
                $scope.book = angular.copy(book);
                return false;
            }
        });
    };

    /* Handles the deletion of a book */
    $scope.deleteBook = function (id) {
        $('#loading').addClass('hide');
        if (confirm("Are you sure that you want to delete this book?")) {
            var request = $http({
                method: "delete",
                url: APIConfig.URL + "api/bookstore?bookId=" + id
            })
            .success(function () {
                $scope.refreshBookList();
            })
            .error(function (data) {
                $('#loading').removeClass('hide');
                $('#loading td').text("Problem while deleting the book!");
            });
        }
    };
});
