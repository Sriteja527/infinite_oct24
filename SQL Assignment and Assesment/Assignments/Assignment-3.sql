create table emp(empno int primary key, ename varchar(20), job varchar(20), mgr_id int, hiredate Date, sal int, comm int, Deptno int);
insert into EMP values(7369, 'SMITH', 'CLERK', 7902, '17-DEC-80', 800, NULL, 20), (7499, 'ALLEN', 'SALESMAN', 7698, '20-FEB-81', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '22-FEB-81', 1250, 500, 30), (7566, 'JONES', 'MANAGER', 7839, '02-APR-81', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '28-SEP-81', 1250, 1400, 30), (7698, 'BLAKE', 'MANAGER', 7839, '01-MAY-81', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '09-JUN-81', 2450, NULL, 10), (7788, 'SCOTT', 'ANALYST', 7566, '19-APR-87', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '17-NOV-81', 5000, NULL, 10), (7844, 'TURNER', 'SALESMAN', 7698, '08-SEP-81', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '23-MAY-87', 1100, NULL, 20), (7900, 'JAMES', 'CLERK', 7698, '03-DEC-81', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '03-DEC-81', 3000, NULL, 20), (7934, 'MILLER', 'CLERK', 7782, '23-JAN-82', 1300, NULL, 10);
select * from EMP;
create table DEPT(Deptno int primary key, Dname varchar(20), loc varchar(20));
insert into DEPT  values (10, 'Accounting', 'New York'),(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'), (40, 'OPERATIONS', 'BOSTON');
--Retrieve a list of MANAGERS.
select ename from emp where job = 'Manager';
--Find out the names and salaries of all employees earning more than 1000 per month.
select ename , sal from emp where sal > 1000;
--Display the names and salaries of all employees except JAMES
select ename, sal from emp where ename <> 'james';
--Find out the details of employees whose names begin with ‘S’
select * from emp where ename LIKE 'S%';
--Find out the names of all employees that have ‘A’ anywhere in their name.
select ename from emp where ename LIKE 'A%' or ename LIKE '%A%' or ename LIKE '%A';
--Find out the names of all employees that have ‘L’ as their third character in their name.
select ename from emp where ename LIKE '__L%';
--Compute daily salary of JONES. 
select sal, sal/30 as 'Daily Salary' from emp where ename = 'jones';
--Calculate the total monthly salary of all employees. 
select sum(sal) as 'total salary' from emp;
--Print the average annual salary .
select AVG(sal * 12) as 'Annual Salary' from emp;
--Select the name, job, salary, department number of all employees except SALESMAN from department number 30.
select ename, job, sal, deptno from emp where Deptno = 30 and job <> 'salesman';
--List unique departments of the EMP table.
select distinct(deptno) from emp;
--List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ename as 'Employee', sal as 'Monthly Salary' from emp where sal > 1500 and (Deptno = 10 or Deptno = 30);
--Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000.
select ename, job, sal from emp where (job = 'Manager' or job = 'Analyst') and (sal <> 1000 and sal <> 3000 and sal <> 5000); 
--Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%.
select ename, sal, comm from emp where comm > (sal * 0.10);
--Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782.
select ename from emp where (ename Like 'll%' or ename Like '%ll%' or ename = '%ll') and (Deptno = 30) or (mgr_id = 7782);
--Display the names of employees with experience of over 30 years and under 40 yrs.Count the total number of employees. 
select
count(empno) as total_number_employess,
ename
from emp 
where datediff (year,hiredate,getdate()) Between 30 and 40
group by ename
--Retrieve the names of departments in ascending order and their employees in descending order.
select d.Dname, e.ename from DEPT as d join EMP e on d.Deptno = e.Deptno order by d.Dname ASC, e.ename DESC;
--Find out Exoerience of miller
select datediff (year,hiredate,getdate()) from emp where ename = 'MILLER'; 