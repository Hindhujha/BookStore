create Table Admin(
AdminId int primary key identity(1,1),
AdminName varchar(15),
MailId varchar(20),
Password varchar(10),
)

create Table AdminsBook(
AdminsBookId int primary key identity(1,1),
AdminId int Foreign Key References Admin(AdminId),
BookName varchar(50),
 AuthorName varchar(50),
 DiscountPrice money,
  OriginalPrice money,
  BookDescription varchar(50),
  Image varchar(50),
  Rating float,
  Reviewer int,
  BookCount int)

 alter procedure sp_AdminsBook
 @AdminId int,
  @BookName varchar(50),
 @AuthorName varchar(50),
 @DiscountPrice money,
  @OriginalPrice money,
  @BookDescription varchar(50),
  @Rating float,
  @Image varchar(50),
  @Reviewer int,
  @BookCount int
  As 
  Begin
  Insert into AdminsBook (AdminId,BookName,AuthorName,DiscountPrice,OriginalPrice,BookDescription,
  Rating,Image,Reviewer,BookCount) values (@AdminId,@BookName,@AuthorName,@DiscountPrice,@OriginalPrice,@BookDescription,
  @Rating,@Image,@Reviewer,@BookCount)
  End

Alter procedure sp_AddAdmin
@AdminName varchar(15),
@MailId varchar(30),
@Password varchar(10)
As
Begin
Insert into Admin (AdminName,MailId,Password) values (@AdminName,@MailId,@Password)
End

select * from Books

alter procedure sp_UpdateAdmin
@AdminId int,
@AdminName varchar(15),
@MailId varchar(20),
@Password varchar(10)
As
Begin
update Admin set AdminName=@AdminName,MailId=@MailId,Password=@Password where AdminId=@AdminId
End


alter procedure sp_GetAdminDetails
As
Begin 
select * from Admin
End

create procedure sp_LoginAdmin
@MailId varchar(25),
@Password varchar(20)
As
Begin
select MailId,Password from Admin where MailId=@MailId AND Password=@Password
End

alter procedure sp_UpdateAdminsBooks
@AdminsBookId int,
@AdminId int,
  @BookName varchar(50),
 @AuthorName varchar(50),
 @DiscountPrice money,
  @OriginalPrice money,
  @BookDescription varchar(50),
  @Rating float,
   @Image varchar(50),
  @Reviewer int,
  @BookCount int
  As 
  Begin
  update AdminsBook set AdminId=@AdminId,BookName=@BookName,AuthorName=@AuthorName,DiscountPrice=@DiscountPrice,
  OriginalPrice=@OriginalPrice,BookDescription=@BookDescription,Rating=@Rating,Reviewer=@Reviewer,
  BookCount=@BookCount,Image=@Image where AdminsBookId=@AdminsBookId
  End

  create procedure sp_GetAllAdminsBooks
  As
  Begin
  select * from AdminsBook
  End


  create procedure sp_DeleteAdminsBook
  @AdminBookId int
  As
  Begin
  delete AdminsBook where AdminsBookId=@AdminBookId
  End

  select * from AdminsBook

select * from Admin