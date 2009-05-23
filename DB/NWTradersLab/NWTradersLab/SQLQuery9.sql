/*
9.	Определить наиболее успешных продавцов.
    Успешность определяется количеством заказов.
*/

/*
select COUNT(*) as [HowManyOrder], Employees.FirstName, Employees.LastName
from Orders inner join Employees on Orders.EmployeeID = Employees.EmployeeID
group by Employees.EmployeeID, Employees.FirstName, Employees.LastName
order by 1 desc
*/

select count(distinct OrderID) as [HowManyOrder], Employees.FirstName, Employees.LastName
from Employees left join Orders on Employees.EmployeeID = Orders.EmployeeID
group by Employees.EmployeeID, Employees.FirstName, Employees.LastName
order by 1 desc
