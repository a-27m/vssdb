/*
7.	����� ����������, �� �������� ������
    � ��������� ������ (1996 ���)
*/
select *
from Customers
where Customers.CustomerID not in
	(
	select Orders.CustomerID
	from Orders
	where Year(Orders.OrderDate) = 1996
	)