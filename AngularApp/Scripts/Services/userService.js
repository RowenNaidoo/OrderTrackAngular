angular.module('user', [])

.factory('userService',['$window', function ($window) {

    var service = {
        //currentUser: {
        //    isLogged: false,
        //    userId: null
        //},

        setCurrentUser: function(uId) {
            //set local storage variables
            $window.sessionStorage.setItem('isLogged', true);
            $window.sessionStorage.setItem('userId', uId);
        },

        getCurrentUserID: function() {
            return $window.sessionStorage.getItem('userId');
        },

        getisLogged: function() {
            return $window.sessionStorage.getItem('isLogged');
        },
        
        logOut: function () {
            $window.sessionStorage.setItem('isLogged', false);
            $window.sessionStorage.setItem('userId', null);
        }
    };

    return service;
}]);

