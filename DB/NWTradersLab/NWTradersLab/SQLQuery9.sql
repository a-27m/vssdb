/*
9.	Определить наиболее успешных продавцов.
    Успешность определяется количеством заказов.
*/

/*
  'distinct' in the Count tells to count distinct NONNULL rows, so the worse seller gets 0
becouse of nulls in joined columns, added by left join)
*/
select
	count(distinct OrderID) as [HowManyOrder],
	Employees.FirstName,
	Employees.LastName
from
	Employees left join Orders
		on Employees.EmployeeID = Orders.EmployeeID
group by
	Employees.EmployeeID,
	Employees.FirstName,
	Employees.LastName
order by
	1 desc;
