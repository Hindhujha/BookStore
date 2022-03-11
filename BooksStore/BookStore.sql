create database BookStore

create Table UserRegister(
userId int primary key identity(1,1),
FullName varchar(10),
EmailId varchar(25),
phNo varchar(20),
password varchar(20))

alter procedure sp_UserRegister
@FullName varchar(10),
@EmailId varchar(25),
@phNo varchar(20),
@password varchar(20)
As
Begin
Insert into UserRegister (FullName,EmailId,phNo,password) values (@FullName,@EmailId,@phNo,@password)
End

create procedure sp_LoginUser
@EmailId varchar(25),
@password varchar(20)
As
Begin
select EmailId,password from UserRegister where EmailId=@EmailId AND password=@password
End

create procedure sp_ForgetPassword
@EmailId varchar(25)
As
Begin
select EmailId from UserRegister where EmailId=@EmailId 
End

alter procedure sp_ResetPassword

@EmailId varchar(25),
@password varchar(10)
As
Begin
update UserRegister set password=@password where EmailId=@EmailId
End

select * from UserRegister

--------------------------------------------------------------------------


