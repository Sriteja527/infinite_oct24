--1)Write a query to display your birthday( day of week)
Declare @Birthday Date = '2001-01-29';
select DATENAME(WEEKDAY, @Birthday) AS DAY;
--2)Write a query to display your age in days
Declare @Birthday1 Date = '2001-01-29'
select DATEDIFF(DAY, @Birthday1, GETDATE()) As Age;
--3)Write a query to display all employees information those who joined before 5 years in the current month
create table DEPT(Deptno int primary key, Dname varchar(20), loc varchar(20));
create table EMP(empno int primary key, ename varchar(20), job varchar(20), mgr_id int, hiredate Date, sal int, comm int, Deptno int FOREIGN KEY REFERENCES DEPT(Deptno));
SELECT * FROM EMP WHERE hiredate < DATEADD(YEAR, -5, GETDATE()) AND MONTH(hiredate) = MONTH(GETDATE());
--4)Question
create table Employee(EmpNo int, EName varchar(255), Sal DECIMAL(10, 2), doj date);

Begin transaction                                                                                     
insert into Employee(EmpNo, EName, Sal, doj)values(1, 'Sriteja', 50000.11, '2001-01-29'),
(2, 'Ramana', 50000.00, '2001-04-28'),(3, 'Vinod', 50000.10, '2000-03-24'),(4, 'Pooja', 50000.11, '2004-03-14');
 
update Employee 
set Sal=Sal+(Sal*0.15)
where empno=2
 
delete from Employee  where Empno=1
 
rollback
 
commit
 
select * from Employee;


--5th question
create Function calculateBonus(@deptno int, @sal decimal(12,3))
  returns decimal(12,3)
  as 
  begin
  declare @calBonus float;
  if  @deptno=10
     set  @calbonus=@sal*0.15;
  else if @deptno=20
     set @calbonus=@sal*0.20;
  else
       set @calbonus=@sal*0.05;
  return @calbonus;
  end;
SELECT dbo.calculateBonus(5, 5000.00) AS Bonus;
--6th question
create procedure  salupdate as
  begin
    update emp
    set sal=sal+500
	where Deptno=(select Deptno from DEPT where Dname='SALES') and sal<1500
  end
 
  Exec salupdate
  select *from emp
 
 
