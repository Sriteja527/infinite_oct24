create table Registrationtable(user_id int Identity(1,1), username varchar(40), password varchar(40), re_enterpassword varchar(40), firstname varchar(40), lastname varchar(40), gender varchar(40));

create procedure sp_Registrationtable
@username varchar(40),
@password varchar(40),
@re_enterpassword varchar(40),
@firstname varchar(40),
@lastname varchar(40),
@gender varchar(40)
as
begin
insert into Registrationtable values(@username, @password, @re_enterpassword, @firstname, @lastname, @gender);
end

create procedure sp_registrationtable1
as
begin
select * from Registrationtable;
end;

select * from Registrationtable;


