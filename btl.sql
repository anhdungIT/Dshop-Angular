use dshopfigure
select * from Products
--===========================================================
--TRANG ADMIN
-- bang cateproduct
-- GET ALL
alter Procedure GetAllcateProduct
AS
BEGIN
	Select * from ProductCategories;
END
--==========================
create Procedure GetAllcateProducttest
@page_index int,
@page_size int
AS
BEGIN
	Select * from ProductCategories
	WHERE ROWNUMBER BETWEEN(@page_index - 1) * @page_size + 1 AND(((@page_index - 1) * @page_size + 1) + @page_size) - 1
                              OR @page_index = -1;

END
--========================
create Proc Get_all_producttest
(@page_index int,@page_size int)
as
     Begin
	      DECLARE @RecordCount BIGINT;
		   SET NOCOUNT ON;
                       SELECT(ROW_NUMBER() OVER(
                              ORDER BY ID ASC)) AS RowNumber,
		    *
                        INTO #Results1
						 FROM Products                    
						SELECT @RecordCount = COUNT(*)
                        FROM #Results1
						SELECT *, 
                               @RecordCount AS RecordCount
					    FROM #Results1
                        WHERE ROWNUMBER BETWEEN(@page_index - 1) * @page_size + 1 AND(((@page_index - 1) * @page_size + 1) + @page_size) - 1
                              OR @page_index = -1;
                        DROP TABLE #Results1; 
      END;
Get_all_producttest 2,5
alter Procedure GetAllProductcate
AS
BEGIN
	Select ID,Name,Description,Image,HomeFlag,CreatedDate,CreatedBy,Status from ProductCategories;
END
exec GetAllProductcate

exec GetAllcateProduct
-- tim id cate
create proc getbyid_productcategory
@id int
as
begin
	select * from Productcategories where ID=@id
end
go
exec getbyid_productcategory @id='2'
-- tao cate pro
Create proc create_procate
@name nvarchar(256),
@des nvarchar(max),
@img nvarchar(max),
@homeflag bit,
@crdate datetime,
@creby nvarchar(256),
@status bit
as
begin
	insert into ProductCategories values(@name,@des,@img,@homeflag,@crdate,@creby,@status)
end

-- xoa cate pro
create proc delete_procate
@id int
as 
begin
	Delete  ProductCategories where id=@id
end
exec delete_procate @id='5'
--sua cate pro
Create proc update_procate
@id int,
@name nvarchar(256),
@des nvarchar(max),
@img nvarchar(max),
@homeflag bit,
@crdate datetime,
@creby nvarchar(256),
@status bit
as
begin 
	update ProductCategories set Name=@name,Description=@des,Image=@img,HomeFlag=@homeflag,CreatedDate=@crdate,CreatedBy=@creby,Status=@status where id=@id
end
select * from ProductCategories
-- bang product
-- tim theo id
-- GET ALL
Create Procedure GetAllProduct
AS
BEGIN
	Select * from Products;
END
create proc getbyid_product
@id int
as
begin
	select * from products where id = @id
end
go
exec getbyid_product @id='2'
-- xem theo loại
CREATE proc [dbo].[getmhbyloai]
@id int
as
begin
	select p.ID,p.Name,p.Image,p.Price,p.PromotionPrice,p.CategoryID from products as p join
	ProductCategories as pct on p.CategoryID=pct.ID
	where pct.ID=@id
end
GO
--=======================================
-- them  1 sp
Create proc create_product
@name nvarchar(256),
@cateId int,
@img nvarchar(256),
@price decimal(18,2),
@promotionprice decimal(18,2),
@des nvarchar(max),
@content nvarchar(max),
@homeflag bit,
@hotflag bit,
@crdate datetime,
@creby nvarchar(256),
@status bit,
@warranty int,
@quantity int,
@oriprice decimal(18,2)
as
begin
	insert into Products values(@name,@cateId,@img,@price,@promotionprice,@des,@content,@homeflag,@hotflag,@crdate,@creby,@status,@warranty,@quantity,@oriprice)
end
exec create_product @name ='HDN', @cateId='1',@img='ff',@price='10',@promotionprice='10',@des='fvfs',@content='ddd',@homeflag='1',@hotflag='1'
, @crdate='20211007',@creby='da',@status='0',@warranty='10',@quantity='10',@oriprice='100'
-- sua 1 sp
Create proc update_product
@id int,
@name nvarchar(256),
@cateId int,
@img nvarchar(256),
@price decimal(18,2),
@promotionprice decimal(18,2),
@des nvarchar(max),
@content nvarchar(max),
@homeflag bit,
@hotflag bit,
@crdate datetime,
@creby nvarchar(256),
@status bit,
@warranty int,
@quantity int,
@oriprice decimal(18,2)
as
begin 
	update Products set Name=@name,CategoryID=@cateId,Image=@img,Price=@price,PromotionPrice=@promotionprice,Description=@des
	,Content=@content,HomeFlag=@homeflag,HotFlag=@hotflag,CreatedDate=@crdate,CreatedBy=@creby,Status=@status,Warranty=@warranty,Quantity=@quantity,OriginalPrice=@oriprice where id=@id
end
-- xoa 1 sp
create proc delete_procduct
@id int
as 
begin
	Delete  Products where id=@id
end
-- tim sp theo ten
create proc search_procate
@name nvarchar(256)
as 
begin
	select * from Products where Name like '%'+@name+'%'
end

exec search_procate @name='lu'




create PROCEDURE Create_Products
@Product      NVARCHAR(MAX)
AS
    BEGIN
	 IF(@Product IS NOT NULL)
	 Begin
	   INSERT INTO Products
                (Name,  CategoryID,Image,Price,PromotionPrice,Description,Content,HomeFlag,HotFlag,CreatedDate,CreatedBy,Status,Warranty,Quantity,OriginalPrice
                )
		 SELECT 
		 JSON_VALUE(@Product, '$.name'), 
		 JSON_VALUE(@Product, '$.categoryId'),
		 JSON_VALUE(@Product, '$.img'),
		 JSON_VALUE(@Product, '$.price'),
		 JSON_VALUE(@Product, '$.promotionprice'),
		 JSON_VALUE(@Product, '$.des'),
		 JSON_VALUE(@Product, '$.content'),
		 JSON_VALUE(@Product, '$.homeFlag'), 
		 JSON_VALUE(@Product, '$.hotFlag'), 	 
		 JSON_VALUE(@Product, '$.crdate'),
		 JSON_VALUE(@Product, '$.crby'),
		 JSON_VALUE(@Product, '$.status'),
		 JSON_VALUE(@Product, '$.warranty'),
		  JSON_VALUE(@Product, '$.quantity'),
		  JSON_VALUE(@Product, '$.originalprice')
	 end;
   END;






create PROCEDURE Update_Products
@Product NVARCHAR(MAX)
AS
    BEGIN
	 IF(@Product IS NOT NULL)
	 Begin
	   update Products 
	          
	       set name=JSON_VALUE(@Product, '$.name'),
		       CategoryID=JSON_VALUE(@Product, '$.categoryId'),
			   Image=JSON_VALUE(@Product, '$.img'),
			   Price=JSON_VALUE(@Product, '$.price'),
			   PromotionPrice=JSON_VALUE(@Product, '$.promotionprice'),
		 Description=JSON_VALUE(@Product, '$.des'),
	Content=JSON_VALUE(@Product, '$.content'),
	HomeFlag= JSON_VALUE(@Product, '$.homeFlag'), 
	HotFlag=JSON_VALUE(@Product, '$.hotFlag'), 
	CreatedDate=JSON_VALUE(@Product, '$.crdate'),
	CreatedBy=JSON_VALUE(@Product, '$.crby'),
	Status=JSON_VALUE(@Product, '$.status'),
	Warranty=JSON_VALUE(@Product, '$.warranty'),
	Quantity=JSON_VALUE(@Product, '$.quantity'),
	OriginalPrice=JSON_VALUE(@Product, '$.originalprice')
	where id=	 JSON_VALUE(@Product, '$.id')
	 end;
   END;
   -- search
   alter proc search_sp(
 @key nvarchar(50))
 as
 begin
		SELECT * 
			FROM Products 
			where Name LIKE '%' + @key + '%' 
			
end
go
select * from Products
exec search_sp  N'Ệ'
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END

--- post cate
-- LAY ID
-- GET ALL
Create Procedure GetAllcatePost
AS
BEGIN
	Select * from PostCategories;
END
create proc getbyid_postcate
@id int
as
begin
	select * from PostCategories where ID=@id
end
-- ADD CATE
Create proc create_postcate
@name nvarchar(256),
@des nvarchar(max),
@img nvarchar(max),
@crdate datetime,
@creby nvarchar(256),
@status bit
as
begin
	insert into PostCategories values(@name,@des,@img,@crdate,@creby,@status)
end
-- EDIT CATE
Create proc update_postcate
@id int,
@name nvarchar(256),
@des nvarchar(max),
@img nvarchar(max),
@crdate datetime,
@creby nvarchar(256),
@status bit
as
begin 
	update PostCategories set Name=@name,Description=@des,Image=@img,CreatedDate=@crdate,CreatedBy=@creby,Status=@status where id=@id
end
--DELETE CATE
create proc delete_postcate
@id int
as 
begin
	Delete PostCategories where id=@id
end
-- POST
-- GET ALL
Create Procedure GetAllpost
AS
BEGIN
	Select * from Posts;
END
-- GET ID POST
create proc getbyid_post
@id int
as
begin
	select * from Posts where ID=@id
end
-- ADD POST
Create proc create_post
@name nvarchar(256),
@categoryid int,
@img nvarchar(256),
@des nvarchar(max),
@content nvarchar(max),
@homeflag bit,
@hotflag bit,
@view int,
@crdate datetime,
@creby nvarchar(256),
@status bit
as
begin
	insert into Posts values(@name,@categoryid,@img,@des,@content,@homeflag,@hotflag,@view,@crdate,@creby,@status)
end
-- EDIT POST
Create proc update_post
@id int,
@name nvarchar(256),
@categoryid int,
@img nvarchar(256),
@des nvarchar(max),
@content nvarchar(max),
@homeflag bit,
@hotflag bit,
@view int,
@crdate datetime,
@creby nvarchar(256),
@status bit
as
begin 
	update Posts set Name=@name,CategoryID=@categoryid,Image=@img,Description=@des,Content=@content,HomeFlag=@homeflag,HotFlag=@hotflag,ViewCount=@view,CreatedDate=@crdate,CreatedBy=@creby,Status=@status where id=@id
end
-- DELETE POST
create proc delete_post
@id int
as 
begin
	Delete Posts where id=@id
end

select * from postcategories
--========================================================================================
-- TRANG NGƯỜI DÙNG
-- lấy các post hot
create proc getposthot
@hotflag bit
as
begin
	select * from Posts where HotFlag = @hotflag
end
-- lấy các sản phẩm theo mã loại
alter proc getmhbyloai
@id int
as
begin
	select p.ID,p.Name,p.Image,p.Price,p.PromotionPrice,p.CategoryID from products as p join
	ProductCategories as pct on p.CategoryID=pct.ID
	where pct.ID=@id
end

exec getmhbyloai 1
-- lấy blog theo mã loại
alter proc getblogbyloai
@id int
as
begin
	select p.ID,p.Name,p.Image,p.Description,p.CreatedDate,p.CategoryID,p.CreatedBy,p.ViewCount from Posts as p join
	PostCategories as pct on p.CategoryID=pct.ID
	where pct.ID=@id
end

exec getblogbyloai 1


-- chọn sản phẩm theo giá tiền từ 1-500$
alter proc getspbyprice500
@min decimal(18,2),
@max decimal(18,2)
as
begin
		select * from Products where PromotionPrice >= 1 and PromotionPrice <= 500
end
-- chọn sản phẩm theo giá tiền từ 501-2000$
create proc getspbyprice2000
@min decimal(18,2),
@max decimal(18,2)
as
begin
		select * from Products where PromotionPrice >= 501 and PromotionPrice <= 2000
end
go
-- chọn sản phẩm theo giá tiền từ 2001-10000$
create proc getspbyprice10000 
@min decimal(18,2),
@max decimal(18,2)
as
begin
		select * from Products where PromotionPrice >= 2001 and PromotionPrice <= 10000
end
go
-- chọn sản phẩm theo giá tiền từ 10001-20000$
create proc getspbyprice20000
@min decimal(18,2),
@max decimal(18,2)
as
begin
		select * from Products where PromotionPrice >= 10001 and PromotionPrice <= 20000
end
--====================================================
-- TRANG NGƯỜI DÙNG
-- chọn 8 sp hot
create proc producthot8
as
begin
		select top(8) * from Products where HotFlag=1
end
-- lấy các sp theo giá tiền
alter proc getproductbyprice  
@min decimal(18,2),
@max decimal(18,2)
as
begin
		select * from Products where PromotionPrice >= @min and PromotionPrice <= @max
end
-- chọn 8 sp phụ kiện
create proc accessoryproduct
as
begin
		select * from Products where CategoryID=15
end
--================================================
-- Đăng ký
CREATE proc [dbo].[register]
(@name nvarchar(256),@address nvarchar(256),@birthday datetime,@email nvarchar(max),@phone nvarchar(max),@username nvarchar(max),@password nvarchar(max))
as
   insert into [ApplicationUsers](FullName,Address,BirthDay,Email,PhoneNumber,UserName,Password) values(@name,@address,@birthday,@email,@phone,@username,@password )
 --  register @name=N'Tiến Đạt',@address=N'Hưng Yên',@birthday='20020710',@email=N'dat123@gmail.com',@phone=N'0123456789',@username=N'admin',@password=N'admin'
-- sửa tài khoản
CREATE proc [dbo].[sp_user_update]
(@userId int,@name nvarchar(256),@address nvarchar(256),@birthday datetime,@email nvarchar(max),@phone nvarchar(max),@username nvarchar(max),@password nvarchar(max))
as
update [ApplicationUsers] 
set FullName=@name,[Address]=@address,BirthDay=@birthday,Email=@email,PhoneNumber=@phone,UserName=@username,[PassWord]=@password
where CustomerId=@userId
-- xóa tài khoản
create proc [dbo].[sp_user_delete]
(@id int)
as
delete [ApplicationUsers] where CustomerId=@id
-- get all
create proc [dbo].[sp_user_getAll]
as
select*from [ApplicationUsers]
GO
-- check đăng nhập
CREATE proc [dbo].[sp_Accounts_User_CheckLogin]
(@username nvarchar(max),@password nvarchar(max))
as
select * from [ApplicationUsers] where UserName=@username and [PassWord]=@password
GO
-- order
alter proc [dbo].[Create_Order]
(@order nvarchar(max),
@List_order_detail nvarchar(max)
)
as
begin
   begin
      insert into Orders
	  (CustomerName,
	  CustomerAddress,
	  CustomerEmail,
	  CustomerMobile,
	  CustomerMessage,
	  PaymentMethod,
	  CreatedDate,
	  [Status])
	 Values( 		
	      JSON_VALUE(@order, '$.customerName'),
		  JSON_VALUE(@order, '$.customerAddress'),
		  JSON_VALUE(@order, '$.customerEmail'),
		  JSON_VALUE(@order, '$.customerMobile'),
		  JSON_VALUE(@order, '$.customerMessage'),
		  JSON_VALUE(@order, '$.paymentMethod'),
		  getdate(),
		  1
		  )
	end
	 IF(@List_order_detail IS NOT NULL)
	 Begin
		INSERT INTO OrderDetails
        (OrderID, 
           ProductID,
		   Price,
		   Quantitty
        )
	           SELECT 
			IDENT_CURRENT('Orders'),		
			JSON_VALUE(p.value, '$.productID'),
			JSON_VALUE(p.value, '$.price'),
			JSON_VALUE(p.value, '$.quantitty')
        FROM OPENJSON(@List_order_detail) AS p;
	end;
end;
select * from OrderDetails
select * from Orders


alter proc [dbo].[allorders]
as
select * from Orderdetails
GO
select * from orders 
allorders 
create proc [dbo].[getorderbyorderdetail] 
(@id int)
as
select o.customername,o.CustomerAddress,o.CustomerEmail,o.CustomerMobile,o.PaymentMethod,o.CreatedDate,o.[Status]
,os.productID,os.quantitty,os.price,p.name,p.image,p.promotionprice
from Orders o join OrderDetails os on o.IDorder=os.OrderID
join Products p on p.ID = os.ProductID where o.IDorder = @id
go
getorderbyorderdetail 12
create proc [dbo].[getorderbyorderdetail2] 
(@id int)
as
select*from OrderDetails where OrderID=@id
GO
select * from Products p join ProductCategories pc on p.CategoryID = pc.ID where pc.Name=N'One Piece' order by p.ID desc
select * from Products p join ProductCategories pc on p.CategoryID = pc.ID where pc.Name like '%One%' order by p.ID desc
	select * from Products where Name like '%'+@name+'%'
	create proc searchbycate
	@key nvarchar(250)
	as
	begin
select * from Products p join ProductCategories pc on p.CategoryID = pc.ID where pc.Name like '%'+@key+'%' order by p.ID desc
end
go
