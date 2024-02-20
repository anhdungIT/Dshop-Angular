var app = angular.module('AppBanHang', []);
app.controller("HomeCtrl", function ($scope, $http) {
    $scope.Producthot;
    $scope.accessoryproduct;  
    $scope.key=" ";
    $scope.keysearch
    function search(){
        $http({
            method: 'GET', 
            url: current_url + '/api/user/search?key='+$scope.key,
        }).then(function (response) {	
            $scope.keysearch = response.data;
            console.log( $scope.keysearch)

        });
    }
    $scope.searchMethod=function(){
        search();
    }
    

 
    $scope.LoadproHot = function () {		 
        $http({
           
            method: 'GET', 
            url: current_url + '/api/user/Get8ptohot',
        }).then(function (response) {	
            $scope.Producthot = response.data;
			//makeScript('js/main.js')
        });
    }; 
    $scope.Loadaccessoryproduct = function () {		 
        $http({
           
            method: 'GET', 
            url: current_url + '/api/user/accessoryproduct',
        }).then(function (response) {	
            $scope.accessoryproduct = response.data;
			//makeScript('js/main.js')
        });
    };     
    

	
	$scope.LoadproHot(); 
	$scope.Loadaccessoryproduct(); 
    

});