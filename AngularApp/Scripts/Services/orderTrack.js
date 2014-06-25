angular.module('orderTrack', [])

    .service('orderTrackServices', function ($http, $location, $q) {
        return {
            getOrdersByUser: function(userId) {
                var dfd = $q.defer();
                
                return $http.get("http://localhost/OrderTrackAPI/api/order/GetByAppUserID", { params: { AppUserId: userId } })
	                .then(function (response) {
	                    //if (typeof response.data === 'object') {
	                        //console.log(response.data);
	                        dfd.resolve(response.data);
	                        return dfd.promise;

	                }, function (response) {
	                    // something went wrong
	                    dfd.reject('error');
	                    return dfd.promise;
	                });
            },
            
            getOrderByOrderID: function (orderId) {
                var dfd = $q.defer();

                return $http.get("http://localhost/OrderTrackAPI/api/order/GetById", { params: { id: orderId } })
	                .then(function (response) {
	                    //if (typeof response.data === 'object') {
	                    //console.log(response.data);
	                    dfd.resolve(response.data);
	                    return dfd.promise;

	                }, function (response) {
	                    // something went wrong
	                    dfd.reject('error');
	                    return dfd.promise;
	                });
            },
            
            getItemCategories: function () {
                var dfd = $q.defer();

                return $http.get("http://localhost/OrderTrackAPI/api/category/Get", { params: { } })
	                .then(function (response) {
	                    //if (typeof response.data === 'object') {
	                    //console.log(response.data);
	                    dfd.resolve(response.data);
	                    return dfd.promise;

	                }, function (response) {
	                    // something went wrong
	                    dfd.reject('error');
	                    return dfd.promise;
	                });
            },

            getItemsforCategory: function (categoryId) {
                var dfd = $q.defer();

                return $http.get("http://localhost/OrderTrackAPI/api/item/GetByCategoryId", { params: { categoryId: categoryId } })
	                .then(function (response) {
	                    //if (typeof response.data === 'object') {
	                    //console.log(response.data);
	                    dfd.resolve(response.data);
	                    return dfd.promise;

	                }, function (response) {
	                    // something went wrong
	                    dfd.reject('error');
	                    return dfd.promise;
	                });
            },
            
            insertCartItem: function (itemId, userId, orderId) {
                var dfd = $q.defer();
                
                var cartitem = {};
                cartitem.ItemID = itemId;
                cartitem.AppUserID = userId;
                cartitem.OrderID = orderId;

                console.log(cartitem);

                return $http.put("http://localhost/OrderTrackAPI/api/CartItem/Insert", JSON.stringify(cartitem), {headers: {'Content-Type': 'application/json'}})
	                .then(function (response) {
	                    //if (typeof response.data === 'object') {
	                    console.log(response.data);
	                    dfd.resolve(response.data);
	                    return dfd.promise;

	                }, function (response) {
	                    // something went wrong
	                    dfd.reject('error');
	                    return dfd.promise;
	                });
            },
            
            getCartItemsforOrder: function (orderId) {
                var dfd = $q.defer();

                return $http.get("http://localhost/OrderTrackAPI/api/cartitem/GetByOrderID", { params: { orderId: orderId } })
	                .then(function (response) {
	                    //if (typeof response.data === 'object') {
	                    //console.log(response.data);
	                    dfd.resolve(response.data);
	                    return dfd.promise;

	                }, function (response) {
	                    // something went wrong
	                    dfd.reject('error');
	                    return dfd.promise;
	                });
            },

            checkOut: function(orderId) {
                var dfd = $q.defer();

                return $http.post("http://localhost/OrderTrackAPI/api/CartItem/Checkout", { orderId: orderId })
                //$http({
                //    method: "POST",
                //    url: "http://localhost/OrderTrackAPI/api/CartItem/Checkout",
                //    headers: { "Content-Type": "application/x-www-form-urlencoded" },
                //    data: { orderId: orderId }
                //})
	                .then(function (response) {
	                    //if (typeof response.data === 'object') {
	                    //console.log(response.data);
	                    dfd.resolve(response.data);
	                    return dfd.promise;

	                }, function (response) {
	                    // something went wrong
	                    dfd.reject('error');
	                    console.log(response);
	                    return dfd.promise;
	                });
            }
        };
    });
