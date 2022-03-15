create Table FeedBack(
FeedBackId int primary key identity(1,1),
FeedBackFromUserName varchar(15),
Comments varchar(50),
Ratings int,
userId int Foreign Key References UserRegister(userId),
BookId int Foreign Key References Books(BookId))

create procedure sp_AddFeedBack
@FeedBackFromUserName varchar(15),
@Comments varchar(50),
@Ratings int,
@userId int,
@BookId int
As
Begin
Insert into FeedBack (FeedBackFromUserName,Comments,Ratings,userId,BookId) values 
 (@FeedBackFromUserName,@Comments,@Ratings,@userId,@BookId)
 End

 select * from FeedBack

 create procedure sp_GetAllFeedBacks
 @BookId int
 As
 Begin
 select * from FeedBack where BookId=@BookId
 End