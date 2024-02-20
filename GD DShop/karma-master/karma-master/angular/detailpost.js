var app = angular.module('AppBanHang', []);
app.controller("postdetailCtrl", function ($scope, $http){
    $scope.length;
    var key = 'id';
	  var value = window.location.search.substring(window.location.search.indexOf(key)+key.length+1);	
    $scope.LoadpostbyID = function () { 	 
        $http({
            method: 'GET', 
            url: current_url + '/api/user/get-post-by-id?id='+value,
           
        }).then(function (response) { 
            $scope.post = response.data;
            console.log(response)
            console.log($scope.post)
           /* $scope.LoadProduct_Image(),*/
   
        });
    }; 
    $scope.LoadpostbyID();
});