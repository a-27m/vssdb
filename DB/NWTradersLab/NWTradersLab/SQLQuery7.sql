/*
7.	Найти заказчиков, не делавших заказы
    в указанный период (1996 год)
*/
select *
from Customers
where Customers.CustomerID not in
	(
	select Orders.CustomerID
	from Orders
	where Year(Orders.OrderDate) = 1996
	)