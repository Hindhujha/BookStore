create procedure sp_AddingBookinWishList
@userId int,
@BookId int
As
Begin
Insert Into WishList (userId,BookId) values (@userId,@BookId)
End

create procedure sp_RemoveBookinWishList
@WishListId int
As
Begin
Delete WishList where WishListId=@WishListId
End

create procedure sp_GetAllBooksinWishList
@userId int
As
Begin
select WishList.WishListId,WishList.userId,WishList.BookId,Books.BookName,Books.AuthorName,
Books.BookDescription,Books.DiscountPrice,Books.OriginalPrice,Books.Rating,Books.Reviewer,
Books.Image,Books.BookCount from WishList inner join Books on WishList.BookId=Books.BookId
where WishList.userId=@userId
End


select * from WishList 

select * from UserRegister

select * from Books

select * from BookCart

select * from Address

select * from FeedBack

select * from Admin