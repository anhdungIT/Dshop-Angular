
var app = angular.module('AppBanHang', []);
app.controller("SanPhamCtrl", function($scope, $http) {
    
    $scope.listsanpham=[];
    $scope.page=1;
    $scope.search="";
    $scope.pageSize=5;
    $scope.danhmuc;

        $scope.Loaddanhmuc = function () {		 
                $http({
                   
                    method: 'GET', 
                    url: url + '/api/ProductCate/getAllcate',
                }).then(function (response) {	
                    $scope.danhmuc = response.data;
                    //makeScript('js/main.js')
                });
            }; 
            $scope.Loaddanhmuc();
    function loadsanpham () {		 
                $http({
                    headers:{'Content-Type': 'application/json', 'charset': 'utf-8'},
                    method: 'Post', 
                    url: url + '/api/Product/search-pro',
                    data:{
                        page:$scope.page,
                        pageSize :$scope.pageSize,
                        Search: $scope.search
                    }
                    
                }).then(function (response) {			 
                  
                    $scope.listsanpham = response.data.data;
                    $scope.total = response.data.totalItem;
                    $scope.totalpage=Math.ceil($scope.total/$scope.pageSize)
                });
             };  
            loadsanpham();

         
            $scope.DeleteProduct = function (s) {
                let result = confirm('Bạn có chắc muốn xóa không?');
                if (result) {
                    $http
                        ({
                            headers:{'Content-Type': 'application/json', 'charset': 'utf-8'},
                            method: 'Post',
                            url: url+'/api/Product/delete-Product',
                            data:s,
                            
                        }).then(function success(d) {
                            var vt = $scope.listsanpham.indexOf(s);//Lấy vị trí bản ghi
                            console.log($scope.listsanpham);
                            $scope.listsanpham.splice(vt, 1);//Xóa bản ghi tại vị trí đã xóa trên giao diện
                            
                        }, function (error) {
                            alert("lỗi");
                            console.log(error)
                        });
                }
            }




//Details
        $scope.Details= function (s) {
            $scope.sav = s;
        }
     //Sửa
        $scope.Edit = function (s) {
            $scope.sav = s;
        }
        $scope.SaveEdit = function (s) {
            $scope.sav.image= $scope.name2;
            
            $http
                ({
                    headers:{'Content-Type': 'application/json', 'charset': 'utf-8'},
                    method: 'Post',
                    url:url+ '/api/Product/update-Product',         
                    data:s

                }).then(function success(d) {
                    alert("ok");
                
                }, function (e) {
                    alert("lỗi" + e);
                    
                });
                $http({
                    method: 'POST',
                    transformRequest: angular.identity,
                    headers: {
                        'Content-Type': undefined
                    }, 
                    url: url+'/api/Product/upload',
                    data: $scope.formData,
                }).then(function (res) {
                }, function (e) {
                    
                });
        }


        //Thêm
       
        $scope.fileSelected = function (element) {
            var file = element.files[0];
            $scope.name2= element.files[0].name;
            const formData = new FormData();
            formData.append('file', file);
            $scope.formData=formData;
        };
        $scope.addData = function (s) {
            $scope.add.image= $scope.name2;
            $http({
                headers:{'Content-Type': 'application/json', 'charset': 'utf-8'},
                method: 'POST',
                url: url+'/api/Product/create-Product',
                data:s,
            }).then(function (res) {
    
                alert("Thêm bản ghi thành công!");
                console.log(s);
                $scope.loadSanPham();
            }, function (e) {
                    alert("Lỗi thêm bản ghi");
                    console.log(e);
            });
            $http({
                method: 'POST',
                transformRequest: angular.identity,
                headers: {
                    'Content-Type': undefined
                }, 
                url: url+'/api/Product/upload',
                
                data: $scope.formData,
            }).then(function (res) {
            }, function (e) {
                    alert("Loi upload");
            console.log(e)

            });
        };



        $scope.searchmethod = function() {
            $scope.page=1;
            loadsanpham();
        }
    
        $scope.pageSizeChange = function(){
            $scope.page=1;
            loadsanpham();
        
        };
    
        $scope.prevPage = function() {
            $scope.page--;
            loadsanpham();
            };
        $scope.nextPage = function() {
            $scope.page++;
            loadsanpham();
            };
       
});
