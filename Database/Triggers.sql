
create trigger Sale
on SalesHistory
after insert
as
 begin
 declare @idVehicle int =(select Id_Vehicle from inserted)
 update Vehicles
 set Sold=1
 where Vehicles.Id_Vehicle=@idVehicle
 end