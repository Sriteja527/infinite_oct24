create table ProductsDetails(ProductId int, ProductName varchar(30), Price Float, DiscountedPrice Float);
create procedure sp_productdetails
@ProductId int,
@ProductName varchar(30),
@Price Float,
@DiscountedPrice Float
as
Begin

insert into ProductsDetails(ProductId, ProductName, Price, DiscountedPrice) values(@ProductId, @ProductName, @Price, @DiscountedPrice);

end
go
create procedure sp_productdetails2
@ProductId int,
@ProductName varchar(30),
@Price Float,
@DiscountedPrice Float
as
Begin

select * from ProductsDetails;

end
go

select * from ProductsDetails;
