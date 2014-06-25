// create the module and name it
// ngRoue is no longer included in angular.js so specify it as a dependancy
//any other modules and services need to be injected here as well
var apiApp = angular.module('apiApp', ['ui.router', 'auth', 'angular-growl', 'orderTrack', 'user'], function($httpProvider) {
    // Use x-www-form-urlencoded Content-Type
    $httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';

    /**
     * The workhorse; converts an object to x-www-form-urlencoded serialization.
     * @param {Object} obj
     * @return {String}
     */
    var param = function (obj) {
        var query = '', name, value, fullSubName, subName, subValue, innerObj, i;

        for (name in obj) {
            value = obj[name];

            if (value instanceof Array) {
                for (i = 0; i < value.length; ++i) {
                    subValue = value[i];
                    fullSubName = name + '[' + i + ']';
                    innerObj = {};
                    innerObj[fullSubName] = subValue;
                    query += param(innerObj) + '&';
                }
            }
            else if (value instanceof Object) {
                for (subName in value) {
                    subValue = value[subName];
                    fullSubName = name + '[' + subName + ']';
                    innerObj = {};
                    innerObj[fullSubName] = subValue;
                    query += param(innerObj) + '&';
                }
            }
            else if (value !== undefined && value !== null)
                query += encodeURIComponent(name) + '=' + encodeURIComponent(value) + '&';
        }

        return query.length ? query.substr(0, query.length - 1) : query;
    };

    // Override $http service's default transformRequest
    $httpProvider.defaults.transformRequest = [function (data) {
        return angular.isObject(data) && String(data) !== '[object File]' ? param(data) : data;
    }];
});

////initialize user object in rootscope
//apiApp.run(function ($rootScope) {
//    $rootScope.user = null;
//});

//configure angular-growl timeout
apiApp.config(['growlProvider', function (growlProvider) {
    growlProvider.globalTimeToLive(5000);
}]);

// configure our routes
apiApp.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/index');

    $stateProvider

        //HOME STATES AND NESTED VIEWS
        .state('index', {
            url: '/index',
            views: {
                '': { templateUrl: 'Index.html' },

                'menuView': { templateUrl: 'Views/menu.html', controller: 'menuController' },

                'contentView': { templateUrl: 'Views/home.html', controller: 'homeController' },
            }
        })

         .state('dashboard', {
             url: '/dashboard',
             views: {
                 '': { templateUrl: 'Index.html', controller: 'dashboardController' },

                 'menuView': { templateUrl: 'Views/secureMenu.html', controller: 'menuController' },

                 'contentView': { templateUrl: 'Views/dashboard.html', controller: 'dashboardController' }
             }
         })

        .state('vieworder', {
            url: '/order/:orderid',
            views: {
                '': { templateUrl: 'Index.html' },
                
                'menuView': { templateUrl: 'Views/secureMenu.html', controller: 'menuController' },
               
                'contentView': { templateUrl: 'Views/order.html', controller: 'orderController' },
                
                'orderDetails@vieworder': { templateUrl: 'Views/order.view.html', controller: 'vieworderController' },
                
                'orderItems@vieworder': { templateUrl: 'Views/order.items.html', controller: 'orderitemsController' },
                
                'orderCart@vieworder': { templateUrl: 'Views/order.cart.html', controller: 'ordercartController' }
            }
        })
    
        .state('createorder', {
            url: '/order',
            views: {
                '': { templateUrl: 'Index.html' },

                'menuView': { templateUrl: 'Views/secureMenu.html', controller: 'menuController' },

                'contentView': { templateUrl: 'Views/order.html', controller: 'orderController' }
            }
        });

});


apiApp.run(function ($rootScope, $location, userService) {
    
    // Everytime the route in our app changes check auth status
    //$rootScope.$on('$routeChangeStart', function (event, toState, $scope) {
    $rootScope.$on('$locationChangeStart', function (event, toState, $scope) {
        //if user is not logged in then redirect to login page
        if ((userService.getisLogged() != 'true')) {
                //event.preventDefault();
                $location.path("/index");
            }
    });
    
});

// create the controller and inject Angular's $scope
apiApp.controller('mainController', function ($scope, $http, AuthService, $rootScope) {
   
    $scope.$on('event:loginSuccess', function (ev, user) {
        $rootScope.user = user;
    });

    $scope.setUser = function(user) {
        $scope.user = user;
    };

    $scope.getUser = function() {
        return $scope.user;
    };

    $scope.isLoggedIn = function() {
        if ($scope.user == null)
            return false;
        else
            return true;
    };
});



apiApp.controller('menuController', function ($scope, AuthService, $location, growl, $rootScope, userService, $window) {
    // create a message to display in our view
    $scope.message = 'menu!';
    $scope.Login = function () {
        
        var Username = $("#Username").val();
        var Password = $("#Password").val();
        
        AuthService.Login(Username, Password)
            .then(function (data) {
                if (data != 'Invalid login details.') {
                    //$rootScope.$broadcast('event:loginSuccess', data);
                    //set local storage current user
                    userService.setCurrentUser(data.AppUserID);

                    //redirect to dashboard state
                    $location.path('/dashboard');
                } else {
                    //display error mesage
                    growl.addErrorMessage(data); 
                }
            }, function (error) {
                alert('error occurred:' + error);
            });

    };

    $scope.Logout = function () {
        userService.logOut();
        $location.path('/index');
    };
});

apiApp.controller('homeController', function ($scope) {
    // create a message to display in our view
    $scope.message = 'Welcome Home!';
});

apiApp.controller('dashboardController', function ($scope, orderTrackServices, userService, $window, $location) {

    //get orders for current user
    orderTrackServices.getOrdersByUser(userService.getCurrentUserID())
        .then(function(data) {
            $scope.orders = data;
        }, function(error) {
            alert(error);
        });

    $scope.viewOrder = function (orderid) {
        $location.path('/order/' + orderid);
    };
});

apiApp.controller('orderController', function ($scope, $stateParams, orderTrackServices) {
    // create a message to display in our view
    $scope.orderid = $stateParams.orderid;
});

apiApp.controller('vieworderController', function ($scope, $stateParams, orderTrackServices) {
    // create a message to display in our view
    //$scope.orderid = $stateParams.orderid;

    //get order by orderid
    orderTrackServices.getOrderByOrderID($stateParams.orderid)
        .then(function (data) {
            $scope.order = data;
            console.log($scope.order);
        }, function (error) {
            alert(error);
        });
});

apiApp.controller('orderitemsController', function ($rootScope, $scope, $stateParams, orderTrackServices, $sce, $compile, userService, growl) {
    //get data for view
    
    //categories
    orderTrackServices.getItemCategories()
        .then(function (data) {
            $scope.categories = data;
            console.log($scope.categories);
        }, function (error) {
            alert(error);
        });

    $scope.getItemsByCatyegoryId = function() {
        console.log($scope.CategoryID);
        
        //get items for category
        orderTrackServices.getItemsforCategory($scope.CategoryID)
            .then(function (data) {
                $scope.items = data;
            }, function (error) {
                alert(error);
            });

        $scope.addItemsToCart = function(itemId) {
            orderTrackServices.insertCartItem(itemId, userService.getCurrentUserID(), $stateParams.orderid)
            .then(function(data) {
                //console.log(data);
                growl.addSuccessMessage("Item added to cart");
                $rootScope.$broadcast('itemAdded');
            }, function(error) {
                growl.addErrorMessage("Error adding item to cart");
            });
        };
    };
});


apiApp.controller('ordercartController', function ($scope, $stateParams, orderTrackServices) {
    orderTrackServices.getCartItemsforOrder($stateParams.orderid)
        .then(function(data) {
            $scope.cartitems = data;
        }, function(error) {

        });

    $scope.calculatePrice = function(index) {
        $scope.cartitems[index].Price = $scope.cartitems[index].Quantity * $scope.cartitems[index].UnitPrice;
    };

    $scope.$on('itemAdded', function (event, args) {
        orderTrackServices.getCartItemsforOrder($stateParams.orderid)
        .then(function (data) {
            $scope.cartitems = data;
        }, function (error) {

        });
    });

    $scope.checkout = function() {
        //categories
        orderTrackServices.checkOut($stateParams.orderid)
            .then(function (data) {
            alert(data);
        }, function (error) {
                alert(error);
            });
    };
});

apiApp.filter('partition', function () {
    var cache = {};
    var filter = function (arr, size) {
        if (!arr) { return; }
        var newArr = [];
        for (var i = 0; i < arr.length; i += size) {
            newArr.push(arr.slice(i, i + size));
        }
        var arrString = JSON.stringify(arr);
        var fromCache = cache[arrString + size];
        if (JSON.stringify(fromCache) === JSON.stringify(newArr)) {
            return fromCache;
        }
        cache[arrString + size] = newArr;
        return newArr;
    };
    return filter;
});


