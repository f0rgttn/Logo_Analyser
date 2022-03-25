--create table dbo.UserTable(
--userID int identity(1001,1) --starting at id 1001, incrementing by 1 
--, firstName varchar(50)
--, lastName varchar(50)
--, email varchar(50) unique -- prevent duplicate emails on insert
--, username varchar (20) unique
--, password binary(64) --hashed and salted password which is why it is stored as binary
--, salt uniqueidentifier --part of the salt/hash
--, createdOn datetime default getdate() --on Null insert, populate current server timestamp
--);
--select * from dbo.UserName;

--insert into dbo.Users (firstName, lastName, email, password, salt)
--values(

--);

--declare @salt uniqueidentifier = newid(); --creates a new gui on the fly
--select @salt
--declare @password binary(64) = hashbytes('sha2_512', 'Test1234');
--select @password

--select * from dbo.UserTable

--declare @password varchar(50) = 'Test1234!'
--declare @salt uniqueidentifier = newid();
--insert into dbo.UserTable (firstName, lastName, email, username, password, salt)
--values (
--'Dave'
--, 'Barry'
--, 'db@email.com'
--,'DB'
--,hashbytes('sha2_512', @password + cast(@salt as nvarchar(36)))
--,@salt 
--);
create proc dbo.usp_Login(
@username varchar(20)
, @password varchar(100)
)
as
begin
select
count(*)
from dbo.UserName
where username = @username
and password = hashbytes('sha2_512', password) + cast (salt as nvarchar(36))
end
exec dbo.usp_Login 
@username = 'DB'
, @password = 'Test1234!';