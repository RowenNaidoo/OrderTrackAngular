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
                
                var cartItem = {};
                cartItem.ItemID = itemId;
                cartItem.AppUserID = userId;
                cartItem.OrderID = orderId;

                console.log(cartItem);

                return $http.put("http://localhost/OrderTrackAPI/api/CartItem/Insert", cartItem )
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
            }
        };
    });
