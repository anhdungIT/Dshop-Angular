var app = angular.module('AppBanHang', []);
app.controller("OrderCtrl", function($scope, $http) {
    $scope.page=1;
    
    $scope.pageSize=5;
    function getOrder() {
        $http({
            url: url+"/api/Orders/allorder",
            headers:{  'Content-Type': 'application/json', 'charset': 'utf-8'},
            method: "get",
            data:{
                page:$scope.page,
                pageSize :$scope.pageSize,
                
            }
           
        }).then(function (response) {
            $scope.allOrders = response.data;
            
        })
    };
    getOrder();

});