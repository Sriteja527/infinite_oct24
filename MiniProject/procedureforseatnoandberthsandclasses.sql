create table seatnumber(train_number int, seat_number int,  type_of_class varchar(40), upper_berth int, lower_berth int, chair_car int, price float);
CREATE PROCEDURE sp_seatnumber
    @train_number INT,
    @seat_number INT,
    @type_of_class VARCHAR(40),
    @upper_berth INT,
    @lower_berth INT,
    @chair_car INT,
    @price1 FLOAT,
    @price2 FLOAT,
    @price3 FLOAT,
    @price4 FLOAT,
    @price5 FLOAT
AS
BEGIN
    -- Insert values into the seatnumber table
    IF @type_of_class = 'FirstClassA/C'
    BEGIN
        INSERT INTO seatnumber (train_number, seat_number, type_of_class, upper_berth, lower_berth, chair_car, price)
        VALUES (@train_number, @seat_number, @type_of_class, @upper_berth, @lower_berth, @chair_car, @price1);
    END
    ELSE IF @type_of_class = 'SecondClassA/C'
    BEGIN
        INSERT INTO seatnumber (train_number, seat_number, type_of_class, upper_berth, lower_berth, chair_car, price)
        VALUES (@train_number, @seat_number, @type_of_class, @upper_berth, @lower_berth, @chair_car, @price2);
    END
    ELSE IF @type_of_class = 'ThirdClassA/C'
    BEGIN
        INSERT INTO seatnumber (train_number, seat_number, type_of_class, upper_berth, lower_berth, chair_car, price)
        VALUES (@train_number, @seat_number, @type_of_class, @upper_berth, @lower_berth, @chair_car, @price3);
    END
    ELSE IF @type_of_class = 'Sleeper'
    BEGIN
        INSERT INTO seatnumber (train_number, seat_number, type_of_class, upper_berth, lower_berth, chair_car, price)
        VALUES (@train_number, @seat_number, @type_of_class, @upper_berth, @lower_berth, @chair_car, @price4);
    END
    ELSE IF @type_of_class = 'chair_car'
    BEGIN
        INSERT INTO seatnumber (train_number, seat_number, type_of_class, upper_berth, lower_berth, chair_car, price)
        VALUES (@train_number, @seat_number, @type_of_class, @upper_berth, @lower_berth, @chair_car, @price5);
    END
END;

--Drop procedure sp_seatnumber;
select * from seatnumber;