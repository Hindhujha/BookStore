create Table Admin(
AdminId int primary key identity(1,1),
AdminName varchar(15),
MailId varchar(20),
Password varchar(10)
--userId int Foreign Key References UserRegister(userId)
)

create procedure sp_AddAdmin
@AdminName varchar(15),
@MailId varchar(20),
@Password varchar(10)
As
Begin
Insert into Admin (AdminName,MailId,Password) values (@AdminName,@MailId,@Password)
End

select * from Admin

create procedure sp_UpdateAdmin
@AdminId int,
@AdminName varchar(15),
@MailId varchar(20),
@Password varchar(10)
As
Begin
update Admin set AdminName=@AdminName,MailId=@MailId,Password=@Password where AdminId=@AdminId
End


create procedure sp_GetAdminDetails
As
Begin 
select * from Admin
End