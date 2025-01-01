create table Addtrain(train_id int Identity(1,1), train_number int, source_point varchar(40), destination_point varchar(40),  train_name varchar(40), 
source_time time, source_date date,  type_of_class varchar(40), total_berth int, upper_berth int, lower_berth int,  chair_car int, status varchar(40), price int );
CREATE PROCEDURE sp_addtrain
    @train_number INT,
    @source_point VARCHAR(40),
    @destination_point VARCHAR(40),
    @train_name VARCHAR(40),
    @source_time TIME,
    @source_date DATE,
    @type_of_class VARCHAR(40),
    @total_berth INT,
    @upper_berth INT,
    @lower_berth INT,
    @chair_car INT,
	@status varchar(40),
    @price Float,
    @action VARCHAR(20)
AS
BEGIN
    IF @action = 'Add'
    BEGIN
        IF @type_of_class = 'FirstClassA/C'
        BEGIN
            INSERT INTO Addtrain (train_number, source_point, destination_point, train_name, source_time,  source_date,  type_of_class, total_berth, upper_berth, lower_berth, chair_car,status, price)
            VALUES (@train_number, @source_point, @destination_point, @train_name, @source_time,  @source_date,  @type_of_class, @total_berth, @upper_berth, @lower_berth, @chair_car, @status, @price);
        END
        ELSE IF @type_of_class = 'SecondClassA/C'
        BEGIN
            INSERT INTO Addtrain (train_number, source_point, destination_point, train_name, source_time,  source_date,  type_of_class, total_berth, upper_berth, lower_berth, chair_car, status, price)
            VALUES (@train_number, @source_point, @destination_point, @train_name, @source_time, @source_date, @type_of_class, @total_berth, @upper_berth, @lower_berth, @chair_car, @status, @price);
        END
        ELSE IF @type_of_class = 'ThirdClassA/C'
        BEGIN
            INSERT INTO Addtrain (train_number, source_point, destination_point, train_name, source_time,  source_date,  type_of_class, total_berth, upper_berth, lower_berth, chair_car, status, price)
            VALUES (@train_number, @source_point, @destination_point, @train_name, @source_time,  @source_date, @type_of_class, @total_berth, @upper_berth, @lower_berth, @chair_car, @status, @price);
        END
        ELSE IF @type_of_class = 'Sleeper'
        BEGIN
            INSERT INTO Addtrain (train_number, source_point, destination_point, train_name, source_time,  source_date,  type_of_class, total_berth, upper_berth, lower_berth, chair_car, status, price)
            VALUES (@train_number, @source_point, @destination_point, @train_name, @source_time,  @source_date, @type_of_class, @total_berth, @upper_berth, @lower_berth, @chair_car, @status, @price);
        END
        ELSE IF @type_of_class = 'ChairCar'
        BEGIN
            INSERT INTO Addtrain (train_number, source_point, destination_point, train_name, source_time,  source_date,  type_of_class, total_berth, upper_berth, lower_berth, chair_car, status, price)
            VALUES (@train_number, @source_point, @destination_point, @train_name, @source_time, @source_date,  @type_of_class, @total_berth, @upper_berth, @lower_berth, @chair_car, @status, @price);
        END
    END
    ELSE IF @action = 'Modify'
    BEGIN
        UPDATE Addtrain
        SET train_number = @train_number,
            source_point = @source_point,
            destination_point = @destination_point,
            source_time = @source_time,
            source_date = @source_date,
            type_of_class = @type_of_class,
            total_berth = @total_berth,
            upper_berth = @upper_berth,
            lower_berth = @lower_berth,
            chair_car = @chair_car,
			status = @status,
            price = CASE
                        WHEN @type_of_class = 'FirstClassA/C' THEN @price
                        WHEN @type_of_class = 'SecondClassA/C' THEN @price
                        WHEN @type_of_class = 'ThirdClassA/C' THEN @price
                        WHEN @type_of_class = 'Sleeper' THEN @price
                        WHEN @type_of_class = 'ChairCar' THEN @price
                        ELSE 0
                    END
        WHERE train_name = @train_name
          AND type_of_class = @type_of_class;
    END
    ELSE IF @action = 'Delete'
    BEGIN
        -- Soft delete: Mark the record as deleted by setting train_name to NULL
		

        UPDATE Addtrain
        SET status = 'InActive'
        WHERE train_name = @train_name and source_point = @source_point and destination_point = @destination_point and type_of_class = @type_of_class and train_number = @train_number;
    END
END
select * from Addtrain;
drop procedure sp_addtrain;
drop table Addtrain;