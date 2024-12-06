create table employee(id int, name varchar(20), salary int);
insert into employee values(1, 'Sriram', 100000), (2, 'rishi', 23000), (3, 'rahul', 5000), (4, 'pooja',3000); 
--Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition
select * from employee;
create procedure payslips(@id int)
as
begin
declare @name varchar(20), @sal int
declare @HRA float
declare @DA float
declare @PF float
declare @IT float
declare @Deduction float
declare @Gross_Salary float
declare @Net_Salary float
select @name=name,@sal=salary from Employee where id=@id
set @HRA=@sal*0.10
set @DA=@sal*0.20
set @PF=@sal*0.08
set @IT=@sal*0.05
set @Deduction=@PF+@IT
set @Gross_Salary=@sal+@HRA+@DA
set @Net_Salary=@Gross_Salary-@Deduction
print 'Payslip for Employee : ' +@name
print 'Basic Salary : '+cast(@Sal as varchar(10))
print 'HRA : ' +cast(@HRA as varchar(10))
print 'DA : ' +cast(@DA as varchar(10))
print 'PF : ' +cast(@PF as varchar(10))
print 'IT : ' +cast(@IT as varchar(10))
print 'Deduction : ' +cast(@Deduction as varchar(10))
print 'Gross salary : ' +cast(@Gross_Salary as varchar(10))
print 'Net salary : ' +cast(@Net_Salary as varchar(10))
end
exec payslips 1

--2nd question
CREATE TABLE Holidays (
    holiday_date DATE PRIMARY KEY,
    holiday_name VARCHAR(20) NOT NULL
);
INSERT INTO Holidays (holiday_date, holiday_name) VALUES
('2024-01-26', 'Republic Day'),
('2024-03-29', 'Holi'),
('2024-08-15', 'Independence Day'),
('2024-11-12', 'Diwali');
insert into holidays values('2024-12-06','Holiday');
CREATE or alter TRIGGER RestrictManipulationOnHolidays
ON Employee
for insert,update,delete
as
BEGIN
    DECLARE @holiday_name VARCHAR(20);
	declare @current_date date = cast(getdate() as date)
    SELECT @holiday_name =holiday_name
    FROM Holidays
    WHERE holiday_date = @current_date;
    IF @holiday_name IS NOT NULL
	begin
        raiserror('Data manipulation is restricted due to %s',16,1, @holiday_name)
		rollback transaction
    END 
END
update employee set Salary=1000 where id=3
select * from employee
