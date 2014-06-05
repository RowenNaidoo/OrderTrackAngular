
angular.module('auth', [])

    .service('AuthService', function ($http, $location, $q) {
        return {
            Login: function (Username, Password) {
                var dfd = $q.defer();
                // the $http API is based on the deferred/promise APIs exposed by the $q service
                // so it returns a promise for us by default
                return $http.get("http://localhost/OrderTrackAPI/api/appuser/Login", { params: { "Username": Username, "Password": Password } })
	                .then(function (response) {
	                    //if (typeof response.data === 'object') {
	                    if (response.data != "null") {
	                        user = response.data;
	                        dfd.resolve(response.data);
	                        return dfd.promise;
	                    } else {
	                        // invalid response
	                        dfd.resolve('Invalid login details.');
	                        return dfd.promise;
	                    }


	                }, function (response) {
	                    // something went wrong
	                    dfd.reject('error2');
	                    return dfd.promise;
	                });
            },

            setUser: function (User) {
                console.log('setUser function');
                user = User;
            },

            getUser: function () {
                return user;
            },

            isLoggedIn: function () {
                if (user != null)
                    return true;
                else
                    return false;
            }
        };
        
    });


