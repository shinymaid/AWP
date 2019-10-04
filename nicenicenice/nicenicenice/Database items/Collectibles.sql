Create Database Collectibles

create table Products(
Product_ID int primary key,
Product_Name varchar (50),
Product_Description varchar (8000),
Product_Category varchar (50)
)
drop table Products
select * from Products
insert into Products values (1,'Orbit 1.0','Orbit 1.0 is an exclusive album by South Korean girl group LOOΠΔ for fan cafe members who purchased the first official Orbit Kit. It was shipped on October 31, 2018. The album contains three alternate versions of previously released songs.','Kpop Album')
insert into Products values (2,'Atago: Heavy Armament Ver','From the browser game Kantai Collection -KanColle-. This is the wonder selection from goodsmile company!','Figurines')
delete from Products

create table Collected_DB(
UserId nvarchar(256) not null,
ProductId int not null,
Constraint Fk_usertoken foreign key (UserId) References AspNetUsers(UserName),
Constraint Fk_productid foreign key (Productid) References  Products(Product_ID),
)
alter table Collected_DB add primary key (UserId,ProductId)

insert into Collected_DB values ('onda',1)
delete from Collected_DB where UserId = 'smt'
select * from Collected_DB
select * from WishListed_DB


create table WishListed_DB(
UserIdw nvarchar(256) not null,
ProductIdw int not null,
Constraint Fk_usertokenw foreign key (UserIdw) References AspNetUsers(UserName),
Constraint Fk_productidw foreign key (ProductIdw) References  Products(Product_ID),
)


alter table WishListed_DB add primary key (UserIdw,ProductIdw)

insert dbo.AspNetRoles values ('A','Admin')
insert dbo.AspNetUserRoles values ('7bcee621-5988-49f4-8abc-513eef9b679c','A')