create procedure sp_displaytraindetails
@source_point varchar(40),
@destination_point varchar(40),
@source_date Date
as
begin
select train_number, train_name, source_point, destination_point, source_time,
type_of_class, total_berth, upper_berth, lower_berth,  chair_car, price, source_date from Addtrain
where source_point = @source_point and destination_point = @destination_point and source_date = @source_date and status = 'Active';
end
drop procedure sp_displaytraindetails;