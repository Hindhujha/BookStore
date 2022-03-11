create table TypeofAddress(
IdType int primary key identity(1,1),
TypeofAddress varchar(50),
)
select * from TypeofAddress

Insert into TypeofAddress values ('Other')



create Table Address(
AddressId int primary key identity(1,1),
Address varchar(50),
City varchar(50),
State varchar(50),
userId int Foreign Key References UserRegister(userId),
IdType int Foreign Key References TypeofAddress(IdType)
)

create procedure sp_AddAddress
@Address varchar(50),
@City varchar(50),
@State varchar(50),
@userId int ,
@IdType int 
As
Begin
Insert into Address (Address,City,State,IdType,userId) values (@Address,@City,@State,@IdType,@userId) 
End

select * from Address

create procedure sp_UpdateAddress
@AddressId int,
@Address varchar(50),
@City varchar(50),
@State varchar(50),
@IdType int 

As
Begin
update Address set Address=@Address,City=@City,State=@State,IdType=@IdType where AddressId=@AddressId
End

create procedure sp_DeleteAddress
@AddressId int
As
Begin
Delete Address where AddressId=@AddressId
End

create procedure sp_GetAll_Address
As
Begin
select * from Address
End

create procedure sp_GetAddressByUserId
@userId int
As
Begin
select * from Address where userId=@userId
End