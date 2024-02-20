var app = angular.module('AppBanHang', []);
app.controller("postcateCtrl", function ($scope, $http){
    $scope.listpostcate;
    $scope.Loadlistpostcate = function () {		 
        $http({
           
            method: 'GET', 
            url: current_url + '/api/user/getAllPostcate',
        }).then(function (response) {	
            $scope.listpostcate = response.data;
			//makeScript('js/main.js')
        });
    }; 
    $scope.Loadlistpostcate();
    $scope.postbycate;
    var key = 'id';
    var value = window.location.search.substring(window.location.search.indexOf(key)+key.length+1);
   $scope.Loadpostbycate = function () {		 
    $http({
        method: 'GET', 
        url: current_url + '/api/user/GetAllPostbycate?id= '+ value,
    }).then(function (response) {	
        $scope.postbycate = response.data;
        //makeScript('js/main.js')
        });
    };  
    $scope.Loadpostbycate();
});