console.log("index.js");

var app = angular.module("app", ["ngRoute"]);
app.config(function ($routeProvider) {
    $routeProvider
		.when("/home", {
		    templateUrl: "./html/home.html"
		})
		.when("/cart", {
		    templateUrl: "./html/cart.html"
		})
		.when("/login", {
		    templateUrl: "./html/login.html"
		})
		.when("/signup", {
		    templateUrl: "./html/registration.html"
		})
		.when("/orders", {
		    templateUrl: "./html/orders.html"
		})
		.when("/orders/:orderId", {
		    controller: "OrderController",
		    templateUrl: "./html/order.html",
		})
		.when("/admin_products", {
		    templateUrl: "./html/admin_products_view.html"
		})
		.when("/admin_product_manage/", {
		    templateUrl: "./html/admin_product_manage.html"
		})
		.when("/admin_product_manage/:productId", {
		    templateUrl: "./html/admin_product_manage.html"
		})
		.otherwise({
		    redirectTo: "/home"
		});
});
app.directive("ngStepper", function (CartFactory) {
    return {
        restrict: "A",
        link: function (scope, element, attrs) {
            $(element).inputStepper({
                initialValue: scope.value
            });
            $(element).on("increase", function (e, amount, plugin) {
                scope.value += amount;
                CartFactory.getCart()[scope.key] = scope.value;
                scope.$apply();
            });
            $(element).on("decrease", function (e, amount, plugin) {
                scope.value -= amount;
                CartFactory.getCart()[scope.key] = scope.value;
                scope.$apply();
            });
        }
    }
})
app.factory("ProductListFactory", function ($http) {
    var lstProduct = [];   

    function requestLstProduct(callback) {
        var request = {
            method: "GET",
            url: "/api/product"
        }
        $http(request)
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
            return +id !== 0 ? lstProduct.filter(function (product) {
                return product.id === +id;
            })[0] : {};
        }
    }
})
app.factory("CartFactory", function (ProductListFactory) {
    var cart = {};

    return {
        getCart: function () {
            return cart;
        },
        addToCart: function (id) {
            cart[id] ? cart[id]++ : cart[id] = 1;
            return true;
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
        }
    }
});
app.factory("OrderFactory", function (ProductListFactory) {
    var lstOrder = [
		{
		    id: 0, name: "John Doe", address: "Address01", phone: "+380968112301", date: new Date(), isCompleted: false, arrOrderItem: {
		        0: 2,
		        1: 1
		    }
		},
		{
		    id: 1, name: "John Doe 02", address: "Address02", phone: "+380968112302", date: new Date(), isCompleted: false, arrOrderItem: {
		        2: 1,
		        1: 1
		    }
		},
		{
		    id: 2, name: "John Doe 03", address: "Address03", phone: "+380968112303", date: new Date(), isCompleted: false, arrOrderItem: {
		        3: 2
		    }
		},
		{
		    id: 3, name: "John Doe 04", address: "Address04", phone: "+380968112304", date: new Date(), isCompleted: false, arrOrderItem: {
		        1: 1,
		        2: 1,
		        3: 3
		    }
		}
    ];
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
        console.log($scope.cart, CartFactory.getTotalItems());
        console.log(ProductListFactory.getProductById(id));
        return true;
    }
});
app.controller("CartController", function ($scope, ProductListFactory, CartFactory) {
    $scope.lstProduct = ProductListFactory.getLstProduct();
    $scope.cartTotal = CartFactory.getTotalItems();
    $scope.cart = CartFactory.getCart();
    $scope.cartTotalWeight = 0;
    $scope.cartTotalPrice = 0;

    $scope.delFromCart = function (id) {
        console.log("del " + id);
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