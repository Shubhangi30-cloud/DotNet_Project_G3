create database E_Trading
 use E_Trading
create table Admin
(AdminName varchar(100),
Password varchar(max) not null)
insert into admin values('ETSAdmin','Admin@123')
 
create table Customer
(CustomerId int identity(1,1),
CustomerName varchar(50),
EmailId nvarchar(max) not null,
PhoneNo bigint not null unique,
Address nvarchar(max),
AccountBalance float not null,
Password varchar(max))
insert into Customer values('Vatsa','vatsa@gmail.com',7548903456,'5,Balanagar,Hyderabad',25000,'Vatsa@123')
 
select * from vendor
 
create table Vendor
(VendorId int primary key identity(1,1),
VendorName varchar(50),
EmailId varchar(max) not null,
PhoneNo bigint not null unique,
Address varchar(max),Password varchar(max))
insert into Vendor values('Shreya','shreya@gmail.com',8520513451,'10,Banglore','Shreya@123')
 
create table Product
(ProductId int primary key identity(1,1),
BrandName varchar(100) not null,
Category varchar(100) not null,
Price float not null,
Quantity int not null)
insert into Product values('Nike','Shoes',5000,30)
 
select * from Product
 
create table VendorProduct
(VendorId int foreign key references vendor(vendorid),
ProductId int foreign key references Product(productid))