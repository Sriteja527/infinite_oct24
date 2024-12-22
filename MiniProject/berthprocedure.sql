create table Bookings(user_id int Identity(1,1), username varchar(40), gender varchar(40), type_of_berth varchar(40), available_seats int, type_of_class varchar(40), train_number int, train_name varchar(40), order_status varchar(40), no_of_tickets int, price int,
name varchar(40), age int, mobile_number varchar(10), source_point varchar(40), destination_point varchar(40));


create procedure sp_Display1
@type_of_berth varchar(40),
@trainname varchar(40)
as
begin 
if @type_of_berth = 'upperberth'
select upper_berth from Addtrain where train_name = @trainname;
else if @type_of_berth = 'lowerberth'
select lower_berth from Addtrain where train_name = @trainname;
else if @type_of_berth = 'chaircar'
select chair_car from Addtrain where train_name = @trainname;
end
go


create procedure sp_registrationdisplay1
@username varchar(40)
as
begin
select username, gender from Registrationtable where username = @username;
end


create procedure sp_insertbookings
@username varchar(40),
@gender varchar(40),
@type_of_berth varchar(40),
@available_seats int,
@type_of_class varchar(40),
@train_number int,
@train_name varchar(40),
@order_status varchar(40),
@no_of_tickets int,
@price int,
@name varchar(40),
@age int,
@mobile_number varchar(10),
@source_point varchar(40),
@destination_point varchar(40)
as
begin
insert into Bookings values(@username, @gender, @type_of_berth, @available_seats, @type_of_class,
@train_number, @train_name,@order_status,@no_of_tickets, @price, @name , @age , @mobile_number, @source_point, @destination_point);
end

create procedure sp_bookingdisplay
@name varchar(40)
as
begin
select username, gender, type_of_berth, type_of_class, train_number, train_name, order_status, no_of_tickets, 
name, age, price, mobile_number, source_point, destination_point from Bookings where name = @name and order_status = 'Booked';
end
--drop procedure sp_bookingdisplay;
create procedure sp_CancelTicket 
    @username varchar(40), 
    @type_of_berth varchar(40), 
    @available_seats int, 
    @no_of_tickets int, 
    @type_of_class varchar(40), 
    @train_number int, 
    @train_name varchar(40), 
    @name varchar(40), 
    @age int, 
    @mobile_number varchar(10), 
    @source_point varchar(40), 
    @destination_point varchar(40)
as
begin
    -- Update the booking status to 'Cancelled'
    update Bookings 
    set order_status = 'Cancelled' 
    where train_number = @train_number 
      and train_name = @train_name 
      and no_of_tickets = @no_of_tickets 
      and name = @name 
      and age = @age 
      and mobile_number = @mobile_number 
      and source_point = @source_point 
      and destination_point = @destination_point;
 
    -- Optionally, update available_seats in the TrainSchedule or similar table if necessary.
    update Bookings
    set available_seats = available_seats + @no_of_tickets
    where train_number = @train_number
      and train_name = @train_name;
end
 

drop procedure sp_CancelTicket;
select * from Bookings;