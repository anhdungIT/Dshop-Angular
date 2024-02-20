var app = angular.module('AppBanHang', []);
app.controller("danhmucCtrl", function($scope, $http) {
    function loaddanhmuc () {		 
        $http({
            headers:{'Content-Type': 'application/json', 'charset': 'utf-8'},
            method: 'get', 
            url: url + '/api/ProductCate/getAllcate',
            
            
        }).then(function (response) {			 
          
            $scope.danhmuc = response.data;
        });
     };  
    loaddanhmuc();
    $scope.Edit = function (s) {
        $scope.sav = s;
    }
    $scope.Details= function (s) {
        $scope.sav = s;
    }
    // sửa loại mô hình
    $scope.SaveEdit = function (s) {
        $scope.sav.image= $scope.name2;
        
        $http
            ({
                headers:{'Content-Type': 'application/json', 'charset': 'utf-8'},
                method: 'Post',
                url:url+ '/api/ProductCate/update-productCategory',         
                data:s

            }).then(function success(d) {
                alert("Sửa loại mô hình thành công");
            
            }, function (e) {
                alert("Có lỗi trong quá trình sửa" + e);
                
            });
            $http({
                method: 'POST',
                transformRequest: angular.identity,
                headers: {
                    'Content-Type': undefined
                }, 
                url: url+'/api/ProductCate/create-productCategory',
                data: $scope.formData,
            }).then(function (res) {
            }, function (e) {
                
            });
    }
    
      // lấy dữ liệu ảnh 
      $scope.fileSelected = function (element) {
        // Lấy tệp tin được chọn bởi người dùng
        var file = element.files[0];
        // Lưu trữ tên của tệp tin được chọn vào thuộc tính name2 của đối tượng $scope
        $scope.name2 = element.files[0].name;
        // Khởi tạo một đối tượng FormData mới
        const formData = new FormData();
        // Thêm tệp tin được chọn vào đối tượng FormData với khóa là 'file'
        formData.append('file', file);
        // Lưu trữ đối tượng FormData vào thuộc tính formData của đối tượng $scope
        $scope.formData = formData;
    };
    
    // xóa loại
    $scope.DeleteProduct = function (s) {
        let result = confirm('Bạn có chắc muốn xóa không?');
        if (result) {
            $http
                ({
                    headers:{'Content-Type': 'application/json', 'charset': 'utf-8'},
                    method: 'Post',
                    url: url+'/api/ProductCate/delete-productCategory',
                    data:s,
                    
                }).then(function success(d) {
                    var vt = $scope.danhmuc.indexOf(s);//Lấy vị trí bản ghi
                    console.log($scope.danhmuc);
                    $scope.danhmuc.splice(vt, 1);//Xóa bản ghi tại vị trí đã xóa trên giao diện
                    
                }, function (error) {
                    alert("lỗi");
                    console.log(error)
                });
        }
    }
    // thêm loại
    $scope.addData = function (s) {
        $scope.add.image= $scope.name2;
        $http({
            headers:{'Content-Type': 'application/json', 'charset': 'utf-8'},
            method: 'POST',
            url: url+'/api/ProductCate/create-productCategory',
            data:s,
        }).then(function (res) {

            alert("Thêm loại mô hình thành công!");
            console.log(s);
            $scope.loadSanPham();
        }, function (e) {
                alert("Lỗi thêm loại mô hình ");
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
});