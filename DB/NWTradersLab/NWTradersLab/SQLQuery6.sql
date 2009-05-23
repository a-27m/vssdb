/*
6.	������ ��� ���������� ���������������� Speedy Express
    ��� ������ ���������� (�����, ������)
*/

select Orders.ShipCountry, Orders.ShipCity
from Orders
where Orders.ShipVia = 
	(
	select top 1 Shippers.ShipperID
	from Shippers
	where Shippers.CompanyName = 'Speedy Express'
	)
group by Orders.ShipCountry, Orders.ShipCity
order by 1 asc, 2 asc;