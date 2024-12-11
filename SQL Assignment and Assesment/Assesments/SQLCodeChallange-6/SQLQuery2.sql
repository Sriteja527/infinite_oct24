create table CourseDetails(Course_id varchar(30), Course_Name varchar(30), Start_date Date, End_Date Date, Fee int);
insert into Coursedetails values
('DN003','DotNet','2018-02-01','2018-02-28',15000),
('DV004','DataVisualization','2018-03-01','2018-04-15',15000),
('JA002','AdvancedJava','2018-01-02','2018-01-20',10000),
('JC001','CoreJava','2018-01-02','2018-01-12',3000);
create function CalculateCourseDuration(@start_date DATE, @end_date DATE)
returns int
as
begin 
return
     DATEDIFF(day, @start_date, @end_date);
end;
 
select dbo.CalculateCourseDuration('2018-01-20', '2018-01-02') AS DurationInDays;
--2nd question

CREATE TRIGGER insert ON T_Course
AFTER INSERT 
as 
BEGIN
    INSERT INTO CourseDetails (Course_Name, Start_Date)
    SELECT Course_Name, Start_Date
    FROM INSERTED;
END;

SELECT * FROM T_Course;