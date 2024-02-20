var app = angular.module('AppBanHang', []);
app.controller("categoryCtrl", function ($scope, $http) {
    $scope.danhmuc;
    $scope.mhby
    $scope.getPriceRange = function() {
        var lowerValueElement = document.getElementById('lower-value');
      var upperValueElement = document.getElementById('upper-value');
        
      if (lowerValueElement && upperValueElement) {
     $scope.minPrice = lowerValueElement.textContent;
       $scope.maxPrice = upperValueElement.textContent;
         }
         };
        
         $scope.Loadspbyprice = function () {
        $http({
        method: 'GET',
        url: current_url + '/api/user/getproductbyprice?min=' + $scope.minPrice + '&max=' + $scope.maxPrice,
       }).then(function (response) {
         $scope.mhbydanhmuc = response.data;
       });
        };
        
      // Call getPriceRange before calling Loadspbyprice
        $scope.getPriceRange();
       $scope.Loadspbyprice();
        danhmuc;
    $scope.Loaddanhmuc = function () {		 
        $http({
           
            method: 'GET', 
            url: current_url + '/api/user/getAllcatepro',
        }).then(function (response) {	
            $scope.danhmuc = response.data;
			//makeScript('js/main.js')
        });
    }; 
    var key = 'id';
    var value = window.location.search.substring(window.location.search.indexOf(key)+key.length+1);
   $scope.LoadSanPhambycate = function () {		 
    $http({
        method: 'GET', 
        url: current_url + '/api/user/GetAllprobycate?id='+value,
    }).then(function (response) {	
        $scope.mhbydanhmuc = response.data;
        //makeScript('js/main.js')
        });
    };  
    $scope.LoadSanPhambycate();
    $scope.Loaddanhmuc();
    // lấy sp theo giá tiền

        $scope.minPrice = 0;
        $scope.maxPrice = 0;
        
        

    // /api/user/getproductbyprice?min=1&max=100
});