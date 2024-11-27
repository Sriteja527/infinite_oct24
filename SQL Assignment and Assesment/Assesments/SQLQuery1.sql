--1st Question
create table books(id int Primary Key, title varchar(40), author varchar(40), isbn BIGINT unique, published_date DateTime); 
insert into books values(1, 'My First SQL Book', 'Mary Parker', 981483029127, '2012-02-22 12:08:17'),
(2, 'My Second SQL BOOK', 'John Mayer', 857300923713, '1972-07-03 09:22:45'),(3, 'My Third SQL Book', 'Cary Flint', 523120967812, '2015-10-18 14:05:44');
select * from books where author LIKE '%er';
--2nd Question.
create table reviews(id int, book_id int, reviewer_name varchar(30), content varchar(30), rating int, published_date DateTime);
insert into reviews values(1, 1, 'John Smith', 'My First review', 4, '2017-12-10 05:50:11.1'),(2, 2, 'John Smith', 'My Second Review', 5, '2017-10-13 15:05:12.6'),
(3, 2, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');
select b.title, b.author, r.reviewer_name from books as b join reviews r on b.id = r.id;
--5th question
create table customer(id int, name varchar(30), age int, address varchar(30), salary float);
insert into customer values(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00), (4, 'Chaitali', 25, 'Mumbai', 6500.00), (5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', 4500.00), (7, 'Muffy', 24, 'Indore', 10000.00);
select name from customer where address Like 'o%' or address Like '%o%' or address Like '%o';
--Orders table
create table Orders(OID int, Date datetime, customer_id int, amount int);
insert into Orders values(102, '2009-10-18 00:00:00', 3, 3000),(100, '2009-10-8 00:00:00', 3, 1500),
(101, '2009-11-20 00:00:00', 2, 1560), (103, '2008-05-20 00:00:00', 4, 2060);
select Date, Count(DISTINCT OID) from Orders group by Date; 
--Employee table
create table Employee(id int, name varchar(30), age int, address varchar(30), salary float);
insert into Employee values(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00), (4, 'Chaitali', 25, 'Mumbai', 6500.00), (5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', Null), (7, 'Muffy', 24, 'Indore', Null);
select LOWER(name) from Employee where salary is Null;
--Student Details
create table Studentdetails(RegisterNo int, Name varchar(20), Age int, Qualification varchar(20), Mobileno BIGINT, Mail_id varchar(30), Location varchar(20), Gender varchar(20));
insert into Studentdetails values(2, 'sai', 22, 'B.E', 9952836777, 'sai@gmail.com', 'Chennai', 'M'),
(3, 'Kumar', 20, 'BSC', 7890125648, 'Kumar@gmail.com', 'Madurai', 'M'), (4, 'Selvi', 22, 'B.Tech', 8904567342, 'selvi@gmail.com', 'selam', 'F'),
(5, 'Nisha', 25, 'M.E', 7834672310, 'Nisha@gmail.com', 'Theni', 'F'), (6, 'saisaran', 21, 'B.A', 7890345678, 'saran@gmail.com', 'Madurai', 'F'),
(7, 'Tom', 23, 'BCA', 8901234675, 'Tom@gmail.com', 'Pune', 'M');
select Gender, Count(*) as total_count from Studentdetails Group by Gender;