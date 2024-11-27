create table EMP(empno int primary key, ename varchar(20), job varchar(20), mgr_id int, hiredate Date, sal int, comm int, Deptno int FOREIGN KEY REFERENCES DEPT(Deptno));
--Drop table EMP;
create table DEPT(Deptno int primary key, Dname varchar(20), loc varchar(20));
insert into DEPT  values (10, 'Accounting', 'New York'),(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'), (40, 'OPERATIONS', 'BOSTON');
insert into EMP values(7369, 'SMITH', 'CLERK', 7902, '17-DEC-80', 800, NULL, 20), (7499, 'ALLEN', 'SALESMAN', 7698, '20-FEB-81', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '22-FEB-81', 1250, 500, 30), (7566, 'JONES', 'MANAGER', 7839, '02-APR-81', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '28-SEP-81', 1250, 1400, 30), (7698, 'BLAKE', 'MANAGER', 7839, '01-MAY-81', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '09-JUN-81', 2450, NULL, 10), (7788, 'SCOTT', 'ANALYST', 7566, '19-APR-87', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '17-NOV-81', 5000, NULL, 10), (7844, 'TURNER', 'SALESMAN', 7698, '08-SEP-81', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '23-MAY-87', 1100, NULL, 20), (7900, 'JAMES', 'CLERK', 7698, '03-DEC-81', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '03-DEC-81', 3000, NULL, 20), (7934, 'MILLER', 'CLERK', 7782, '23-JAN-82', 1300, NULL, 10);
select * from EMP;
-- All Employees Whose name begins with 'A'
select * from EMP where ename Like 'A%';
-- Select all those employees who don't have a manager
--select * from EMP where mgr_id is NULL;
-- 2nd Question Select all those employees who don't have a manager.
select * from EMP where mgr_id is NULL;
-- 3rd Question Salary range between 1200 to 1400.
select empno, ename, sal from EMP where sal between 1200 AND 1400;
--4th query Giving all employees from the research department Before the rise.)
select e.empno, e.ename, e.job, e.mgr_id, e.hiredate, e.sal, e.comm, e.Deptno from EMP as e join DEPT d on e.Deptno = d.Deptno where d.Dname = 'RESEARCH';
--update a 10% pay rise.
update EMP set sal = sal * 1.10 where Deptno = (select Deptno from DEPT where DNAME = 'RESEARCH');
--After raising.
select * from EMP as e join DEPT d on e.Deptno = d.Deptno where d.Dname = 'RESEARCH';
--5th Question Find the number of clerks employed Give it a descriptive heading.
select  'Present job' as job  , count(job) as 'No.of Clerks Employed' from EMP where job = 'CLERK'; 
--6th Question Find the average salary for each job type and number of people employed in job
select job, AVG(sal) as 'Average Salary', count(job) as 'Count No.of Employees' from EMP where job in ('CLERK', 'SALESMAN', 'MANAGER', 'ANALYST', 'PRESIDENT') group by job; 
--7th question List the employees with the lowest and highest salary.
select ename, sal from EMP where sal = (select MIN(sal) from EMP) union select ename, sal from EMP where sal = (select MAX(sal) from EMP);
--8th question List full details of departments that don't have any employees.
select * from DEPT left join EMP on DEPT.DEPTNO = EMP.DEPTNO where EMP.DEPTNO is null;
--9th question Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name.
select ename, sal
from EMP 
where job = 'ANALYST' and sal > 1200 and Deptno = 20
order by ename asc
--10th list its name and number together with the total salary paid to employees in that department. 
select E.ename, E.empno,E.Deptno,sum(E.sal) as total_salary
from EMP E join EMP E1 
on E.Deptno = E1.Deptno
group by E.ename,
E.empno,
E.Deptno;
--11th question Find out salary of both MILLER and Smith
select SAL from EMP 
where ENAME in ('MILLER','SMITH')
--12th Find out the names of the employees whose name begin with ‘A’ or ‘M’.
select ENAME 
from EMP 
where ENAME like ('A%') or ENAME like ('M%')
--13th Compute yearly salary of smith.
select sal, sal * 12 as 'Yearly salary' from EMP where ename = 'SMITH';
--14th List the name and salary for all employees whose salary is not in the range of 1500 and 2850.
select ename, sal from EMP where sal not between 1500 and 2850; 
--15th Find all managers who have more than 2 employees reporting to them
select mgr_id, count(*) as Employee_Count
from EMP 
group by mgr_id 
having count(*) > 2