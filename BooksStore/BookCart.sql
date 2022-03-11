create table BookCart(
CartId int primary key identity(1,1),
Quantity int,
userId int Foreign Key References UserRegister(userId),
BookId int Foreign Key References Books(BookId))

create procedure sp_AddingBookinCart
@Quantity int,
@userId int,
@BookId int
As
Begin
Insert into BookCart (Quantity,userId,BookId) values (@Quantity,@userId,@BookId)
End


select * from BookCart

create procedure sp_UpdateCart
@Quantity int,
@CartId int
As
Begin
update BookCart set Quantity=@Quantity
where CartId=@CartId
End


create procedure sp_DeleteCart
@CartId int
As
Begin 
Delete BookCart where CartId=@CartId
End

alter procedure sp_GetAllBooksinCart
@userId int
As
Begin
--select BookCart.userId,BookCart.CartId,BookCart.BookId,BookCart.Quantity ,Books.BookName,Books.AuthorName,Books.

select BookCart.CartId,BookCart.userId,BookCart.BookId,BookCart.Quantity , Books.BookName,Books.AuthorName,
Books.BookDescription,Books.DiscountPrice,Books.OriginalPrice,Books.Rating,Books.Reviewer,
Books.Image,Books.BookCount from BookCart inner join Books on BookCart.BookId=Books.BookId
where BookCart.userId=@userId
End