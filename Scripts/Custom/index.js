var app = angular.module("app", ["ngRoute", "ui.utils.masks"]); //ui.utils.masks is used to add mask to phone form field

//url mapping for single page web app
app.config(function ($routeProvider) {
    $routeProvider
		.when("/home", {
		    templateUrl: "./html/home.html"
		})
		.when("/cart", {
		    templateUrl: "./html/cart.html"
		})
		.when("/success", {
		    templateUrl: "./html/order_success.html"
		})
        .when("/error", {
            templateUrl: "./html/order_error.html"
        })
        .otherwise({
		    redirectTo: "/home"
		});
});
app.directive("ngStepper", function(CartFactory) { //custom directive to handle an particular items of one pizza
    return {
        restrict: "A", //match attribute
        link: function(scope, element, attrs) { //link function manipulates with DOM
            $(element).inputStepper({
                initialValue: scope.value
            });
            $(element).on("increase", function(e, amount, plugin) {
                scope.value += amount;
                CartFactory.getCart()[scope.key] = scope.value;
                scope.$apply();
            });
            $(element).on("decrease", function(e, amount, plugin) {
                scope.value -= amount;
                CartFactory.getCart()[scope.key] = scope.value;
                scope.$apply();
            });
        }
    }
});
/*
 * service factories used to store and manipulate with some data structures. 
 * Here factories also used to pass data from one controller to another.
 */
app.factory("ProductListFactory", function ($http) {
    var lstProduct = [];   

    function requestLstProduct(callback) {
        var request = {
            method: "GET",
            url: "/api/product"
        }
        $http(request) //send async ajax repuest to webapi service
            .success(function (data, status, headers, config) {
                if (callback && typeof (callback) === "function") {
                    callback(data);
                }
                lstProduct = data ? data : [];
            })
            .error(function(error) {
                console.log(error);
                lstProduct = [];
        });
    }

    return {
        requestLstProduct: function(callback) {
            requestLstProduct(callback);
        },
        getLstProduct: function () {
            requestLstProduct();
            return lstProduct;
        },
        getProductById: function (id) {
            //+id means call valueOf the id object. Basically this will convert id to an object of type Number
            return +id !== 0 ? lstProduct.filter(function (product) {
                return product.id === +id;
            })[0] : {};
        }
    }
})
app.factory("CartFactory", function ($http, ProductListFactory) {
    var cart = {};

    //Internal factory function.
    //Properly map data about the order before sending to the server
    function mapOrder(cartInfo) {
        var order = {
            id: 0,
            name: cartInfo.name,
            address: cartInfo.address,
            phone: cartInfo.phone,
            orderItems: []
        }

        for (var key in cart) {
            order.orderItems.push({ productId: key, quantity: cart[key] });
        }

        return order;
    }

    //define methods of the factory
    return {
        getCart: function () {
            return cart;
        },
        addToCart: function (id) {
            /*
             * if there is such kind of pizza in the cart, increase quantity by one
             * otherwise add a new  kind of pizza and set it's quantity to 1 
             */
            cart[id] ? cart[id]++ : cart[id] = 1; 
            return true;
        },
        clearCart: function() {
            cart = {};
        },
        delFromCart: function (id) {
            delete cart[id];
            return true;
        },
        setItemQuantity: function (id, quantity) {
            cart[id] = quantity;
            return true;
        },
        getTotalItems: function () {
            return Object.keys(cart).length;
        },
        getItemPrice: function (id) {
            return cart[id] ? cart[id] * ProductListFactory.getProductById(id).price : 0;
        },
        getTotalPrice: function () {
            var totalPrice = 0,
				self = this;
            Object.keys(cart).forEach(function (id) {
                totalPrice += self.getItemPrice(id);
            });
            return totalPrice;
        },
        getTotalQuantity: function () {
            var totalQuantity = 0;
            Object.keys(cart).forEach(function (id) {
                totalQuantity += cart[id];
            });
            return totalQuantity;
        },
        getTotalWeight: function () {
            var totalWeight = 0;
            Object.keys(cart).forEach(function (id) {
                totalWeight += cart[id] * ProductListFactory.getProductById(id).weight;
            });
            return totalWeight;
        },
        sendOrder: function (cartInfo, callback, callbackError) {
            var request = {
                method: "POST",
                url: "/api/order",
                data: JSON.stringify(mapOrder(cartInfo))
            }
            $http(request) //another ajax request
                .success(function (data, status, headers, config) {
                    if (callback && typeof (callback) === "function") {
                        callback(data);
                    }
                })
                .error(function (data, status, headers, config) {
                    if (callbackError && typeof (callbackError) === "function") {
                        callbackError(data);
                    }
                });
        }
    }
});
app.factory("OrderFactory", function () {
    return {
        getLstOrder: function () {
            return lstOrder;
        },
        getOrderById: function (id) {
            return lstOrder.filter(function (order) {
                return order.id === +id;
            })[0];
        },
        getOrderPending: function () {
            return lstOrder.filter(function (order) {
                return order.isCompleted = false;
            });
        },
        getOrderCompleted: function () {
            return lstOrder.filter(function (order) {
                return order.isCompleted = true;
            });
        }
    }
})
app.controller("HeaderController", function ($scope, CartFactory) {
    $scope.getCartTotalQuantity = function () {
        return CartFactory.getTotalQuantity();
    }
});
app.controller("IndexController", function ($scope, ProductListFactory, CartFactory) {
    $scope.lstProduct = [];
    $scope.cartTotal = CartFactory.getTotalItems();
    $scope.cart = CartFactory.getCart();

    ProductListFactory.requestLstProduct(function(data) {
        $scope.lstProduct = data ? data : [];
    });

    $scope.addToCart = function (id) {
        CartFactory.addToCart(id);
        $scope.cartTotal = CartFactory.getTotalItems();
        return true;
    }
});
app.controller("CartController", function ($scope, ProductListFactory, CartFactory) {
    $scope.lstProduct = ProductListFactory.getLstProduct();
    $scope.cartTotal = CartFactory.getTotalItems();
    $scope.cart = CartFactory.getCart();
    $scope.cartTotalWeight = 0;
    $scope.cartTotalPrice = 0;
    $scope.address = "";
    $scope.name = "";
    $scope.phone = "";
    $scope.success = false;
    $scope.error = false;
    $scope.disabled = false;
    
    $scope.resetAll = function () {
        CartFactory.clearCart();
    }
    $scope.delFromCart = function (id) {
        CartFactory.delFromCart(id);
        return true;
    }
    $scope.getProductById = function (id) {
        return ProductListFactory.getProductById(id);
    }
    $scope.getCartItemPrice = function (id) {
        return Math.round(CartFactory.getItemPrice(id) * 100) / 100;
    }
    $scope.getTotalCartQuantity = function () {
        return CartFactory.getTotalQuantity();
    }
    $scope.getTotalCartPrice = function () {
        return Math.round(CartFactory.getTotalPrice() * 100) / 100;
    }
    $scope.getTotalCartWeight = function () {
        return CartFactory.getTotalWeight();
    }
    $scope.sendOrder = function () {
        $scope.isDisabled = true;

        CartFactory.sendOrder({
            address: $scope.address,
            name: $scope.name,
            phone: $scope.phone
        },
        function () {
            CartFactory.clearCart();
            $scope.isDisabled = false;
            $scope.success = true;
        },
        function () {
            CartFactory.clearCart();
            $scope.isDisabled = false;
            $scope.error = true;
        });
    }
});
app.controller("OrderController", function ($scope, $routeParams, OrderFactory, ProductListFactory) {
    $scope.orderFilter = "";
    $scope.orderId = $routeParams.orderId;

    $scope.getOrderById = function (id) {
        return OrderFactory.getOrderById(id);
    }
    $scope.getLstOrder = function () {
        return OrderFactory.getLstOrder();
    }
    $scope.updateOrderStatus = function (id, bool) {
        OrderFactory.getOrderById(id).isCompleted = bool;
        return true;
    }
    $scope.resetFilter = function () {
        $scope.orderFilter = "";
        return true;
    }
    $scope.formatDate = function (date) {
        return date.getUTCFullYear() + "." + date.getUTCMonth() + "." + date.getUTCDay() + " " + date.getUTCHours() + ":" + date.getUTCMinutes() + ":" + date.getUTCSeconds();
    }
    $scope.getProductById = function (id) {
        return ProductListFactory.getProductById(id);
    }
});
app.controller("ProductViewController", function ($scope, ProductListFactory) {
    $scope.orderFilter = "";

    $scope.getLstProduct = function () {
        return ProductListFactory.getLstProduct();
    }
    $scope.resetFilter = function () {
        $scope.orderFilter = "";
        return true;
    }
});
app.controller("ProductManageController", function ($scope, $routeParams, ProductListFactory) {
    $scope.productId = $routeParams.productId ? $routeParams.productId : null;
    $scope.product = ProductListFactory.getProductById($scope.productId);
    $scope.updatedProduct = $scope.product;

    $scope.resetProduct = function () {
        $scope.updatedProduct = $scope.product;
        return true;
    }
    $scope.saveProduct = function () {
        +productId !== 0 ? ProductListFactory.getProductById(productId) = $scope.updatedProduct : ProductListFactory.getLstProduct().push($scope.updateProduct);
        return true;
    }
})