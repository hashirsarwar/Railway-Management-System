create database RailwayManagement
use RailwayManagement



create table Ticket_Type(
	ID int NOT NULL PRIMARY KEY identity(1,1),
	Titles varchar(20) NOT NULL 
)


create table [user](
	ID int NOT NULL PRIMARY KEY identity(1,1),
	username varchar(20) NOT NULL,
	"Password" varchar(20) NOT NULL,
	fname varchar(20) not null,
	lname varchar(20) not null,
	Age int NOT NULL,
	Gender char(1) NOT NULL,
	Phone_no char(11) NOT NULL,
	CNIC char(15) NOT NULL, 
	userType char(9) not null,
	check (userType='admin' or userType='passenger'),
	check (gender='m' or gender='f')
)


create table "Route"(
	ID int NOT NULL PRIMARY KEY identity(1,1),
	Pick_up varchar(30) NOT NULL ,
	Arrival varchar(30) NOT NULL
)


create table Train(
	ID int NOT NULL PRIMARY KEY identity(1,1),
	Train_Number varchar(20) NOT NULL,
	availableSeats int not null,
	Date_Pickup Date NOT NULL,
	pickup_time time not null,
	Route_ID int NOT NULL,
	FOREIGN KEY(ROUTE_ID) references "Route"(ID),
)

create table reservation(
	ID int NOT NULL PRIMARY KEY identity(1,1),
	Ticket_class int NOT NULL ,
	Train_ID int,
	Issue_by int NOT NULL,
	Seat_no int NOT NULL,
	FOREIGN KEY(Issue_by) references [user](ID) ,
	FOREIGN KEY(Train_ID) references Train(ID) on delete set null,
	FOREIGN KEY(Ticket_class) references Ticket_Type(Id) , 
)

go


--PROCEDURES:


-----------
create procedure reserveSeat
@Ticket_class int,@Train_ID int,@Issue_by int,@Seat_no int,@result int output
as
begin
if exists (select * from train where id=@Train_ID) and
exists (select * from [user] where id=@Issue_by) 
begin
declare @seats int
set @seats=(select availableseats from train where id=@Train_ID)
if @seats=0
begin

set @result=0
end
else 
begin

insert into reservation(Ticket_class,Train_ID,Issue_by,Seat_no)
values(@Ticket_class,@Train_ID,@Issue_by,@Seat_no)
update train set availableseats=@seats-1
where id=@Train_ID
set @result=1
end

end
else
begin
set @result=0
end
end
go

-------------
create procedure cancelReservation @id int,@result int output
as
begin
if exists (select * from reservation where id=@id)
begin

declare @seats int,@trainid int
set @trainID=(select train_id from reservation where id = @id)
set @seats=(select availableseats from train where id=@trainID)
delete from reservation where id=@id
update train set availableseats=@seats+1
where id=@trainID
set @result=1
end
else
begin
set @result=0
end
end
go

--------------
create procedure editReservation 
@oldId int,@Ticket_class int,@Train_ID int,@Issue_by int,@Seat_no int,@result int output
as 
begin
exec cancelReservation @oldid,@result output
if @result=1
begin
exec reserveSeat @Ticket_class,@Train_ID,@Issue_by,@Seat_no,@result output
end
end
go

--------------
create procedure editUser @oldID int,@uname varchar(20),@pass varchar(20),@fname varchar(20),@lname varchar(20),@age int,
@gender char(1),@pn char(11),@cnic char(15),@usertype char(9)
as
begin
delete from [user] where id=@oldid
set identity_insert [user] on
insert into [user](id,username,[password],fname,lname,age,gender,phone_no,cnic,usertype) values (@oldid,@uname,@pass,@fname,@lname,@age,@gender,@pn,@cnic,@usertype)
set identity_insert [user] off
end
go

-----------

--14
go
create procedure [Login] @name varchar(20) , @password varchar(50),@userTpye char(9) , @status int output
As
Begin
	if exists (select * from "user" u where u.username= @name and u."Password" =@password and u.userType=@userTpye)  
		Begin
			set @status = 1 ;
		end
		else
		begin
			set @status = 0 ;
		end
		
end

--------------------------------------------------------------

--15
go
create procedure changePass @username varchar(20) , @oldpin varchar(20) , @newpin varchar(20) 
As
Begin

	if exists (select * from "user" u where u.username = @username and u.Password =@oldpin) 
	begin
		
		Update [user] 
		set "Password" = @newpin
		where username = @username ;
		print 'Updated Pin' ;

	end

	else
	begin
		
		print 'Error';
	end

end
-------------------------------------------------------------------
