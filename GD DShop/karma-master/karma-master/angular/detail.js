var app = angular.module('AppBanHang', []);
app.controller("detailCtrl", function ($scope, $http,$window) {

    $scope.length;
    var key = 'id';
	  var value = window.location.search.substring(window.location.search.indexOf(key)+key.length+1);	
    $scope.LoadSanPhambyID = function () { 	 
        $http({
            method: 'GET', 
            url: current_url + '/api/user/get-product-by-id?id='+value,
           
        }).then(function (response) { 
            $scope.sanpham = response.data;
            console.log(response)
            console.log($scope.sanpham)
           /* $scope.LoadProduct_Image(),*/
   
        });
    }; 

    var cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];
    $scope.addToCart = function(item) {
        //if ($window.sessionStorage.getItem("customer")) {
            var existingItem = findCartItem(item);
            if (existingItem) {
              existingItem.quantity +=1;
            } else {
                var cartItem = {
                    productID: item.id,
                    quantitty: 1,
                    image:item.image,
                    name:item.name,
                    price:item.promotionPrice,
    
                };
              cartItems.push(cartItem);
            }
            localStorage.setItem('cartItems', JSON.stringify(cartItems));
            alert("Đã thêm sản phẩm vào giỏ hàng !")
            $scope.cartItems = cartItems;
       //}
      //  else{
      //    $window.location.href="login.html"
      //  } 
      };

      function findCartItem(item) {
        for (var i = 0; i < cartItems.length; i++) {
          if (cartItems[i].productId === item.id) {
            return cartItems[i];
          }
        }
        return null;
      }
   /* $scope.LoadProduct_Image = function () {
        $http({
            method: 'GET', 
            url: current_url_Home + '/api/Home/GetProductImage?id='+value,
        }).then(function (response) { 
            $scope.anhsanpham = response.data;
            $scope.length=anhsanpham.length;
        });
    }*/
    
    $scope.LoadSanPhambyID()
});
