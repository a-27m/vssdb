use Airport;
drop trigger RouteDel;
GO

create trigger RouteDel
on AirRoute instead of delete
as

declare @num int;

select @num=count(*)
from PlannedRoute pr inner join deleted d on pr.IDAirRoute = d.IDRoute

if @num > 0 
begin
	PRINT 'Cannot DELETE: There are planned flights for this route!'
end
