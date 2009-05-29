/*
8.	Выдать общую стоимость заказов для каждого продавца
    за указанный период времени – лето 1996 года
*/

select
	Orders.EmployeeID,
	Employees.LastName,	Employees.FirstName,
	SUM(Subtotal) as Total
from
	 Employees inner join (
		Orders inner join [Order Subtotals]
			on Orders.OrderID = [Order Subtotals].OrderID)
	 on Employees.EmployeeID = Orders.EmployeeID
where 
	Orders.OrderDate between '1996-06-01 00:00:00' and '1996-08-31 23:59:59'
group by
	Orders.EmployeeID, Employees.LastName, Employees.FirstName
order by
	2 asc, 3 asc;
