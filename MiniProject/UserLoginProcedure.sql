create table user_login(user_id int Identity(1,1), username varchar(40), password varchar(40));

create procedure sp_userlogin
@username varchar(40),
@password varchar(40)
as
begin
insert into user_login values(@username, @password);
select * from user_login;
end


CREATE PROCEDURE sp_userlogin1
AS
BEGIN
    select * from user_login;
END;
select * from user_login;