create table BooksOrder(
OrderId int primary key identity(1,1),
TotalPrice Money,
BookQuantity int,
OrderDate Date,
userId int Foreign Key References UserRegister(userId),
BookId int Foreign Key References Books(BookId),
AddressId int Foreign Key References Address(AddressId)
)

Alter procedure sp_BooksOrder
@TotalPrice Money,
@BookQuantity int,
@OrderDate Date,
@userId int,
@BookId int,
@AddressId int
As
Begin
Insert into BooksOrder (TotalPrice,BookQuantity,OrderDate,userId,BookId,AddressId)
values (@TotalPrice,@BookQuantity,@OrderDate,@userId,@BookId,@AddressId)
End


select * from BooksOrder

create procedure sp_GetAllOrders
@userId int
As
Begin
select BooksOrder.OrderId,BooksOrder.userId,BooksOrder.BookId,BooksOrder.AddressId,BooksOrder.BookQuantity,BooksOrder.TotalPrice,BooksOrder.OrderDate,Books.BookName,Books.AuthorName,
Books.BookDescription,Books.DiscountPrice,Books.OriginalPrice,Books.Rating,Books.Reviewer,
Books.Image,Books.BookCount from BooksOrder inner join Books on BooksOrder.BookId=Books.BookId
where BooksOrder.userId=@userId
End

select * from UserRegister