var app = angular.module('AppBanHang', []);
app.controller('cartCtrl', function($scope , $http , $window) {

    var cartItems = JSON.parse(localStorage.getItem('cartItems')) || [];
    $scope.total=0;
    angular.forEach(cartItems, function(item) {
      $scope.total += item.price * item.quantitty;
    });


    $scope.cartItems = cartItems;
    $scope.Customer;
    $scope.order={
      total:$scope.total,
      paymentMethod: 'COD'
    
    };
    $scope.orderDetail=$scope.cartItems;
   
    
    
    $scope.Payment = function () {		 
      $http({
          headers:{ 'Content-Type': 'application/json', 'charset': 'utf-8'},
          method: 'POST', 
          url: current_url + '/api/user/create_order',
          data:{
            order:$scope.order,
            listOrderDetail : $scope.orderDetail,
          }

      }).then(function (response) {	
            alert("Đặt mua thành công !")
            $scope.clearCart();
            $scope.order={}
            console.log(listOrderDetail)

      }, function (error) {
        alert("lỗi");
        console.log(error)
      });
      console.log(listOrderDetail)

    };  

    $scope.clearCart = function() {
      cartItems = [];
      localStorage.removeItem('cartItems');
      $scope.cartItems = cartItems;
      $scope.total = null;
    };

    $scope.updateCart = function(){
        localStorage.setItem('cartItems', JSON.stringify($scope.cartItems));
        $scope.total=0;
        angular.forEach(cartItems, function(item) {
          $scope.total += item.price * item.quantitty;
    });
   
    }

    $scope.removeFromCart = function(item) {
        var index = cartItems.indexOf(item);
        if (index !== -1) {
          cartItems.splice(index, 1);
          localStorage.setItem('cartItems', JSON.stringify(cartItems));
          $scope.cartItems = cartItems;
          $scope.updateCart();
        }
      };
    
    $scope.check = function(x){
      $scope.checkedItems.push(x);
      console.log($scope.checkedItems);

    }



  });
  