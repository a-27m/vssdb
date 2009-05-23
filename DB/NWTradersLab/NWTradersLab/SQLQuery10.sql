/*
10.	������ ���������� (��� ��������, �����, ������, ��������
    ������ � ������), ������� ������ ������ � 1996 ���� � ������
    � ��������, ������� �� ����������� (���, �����, ������, �������� ������ � ������)
*/

select
	Customers.CompanyName as [Company name], 
	Customers.City as [Company city], 
	Customers.Region as [�ompany region],
	Customers.PostalCode as [Company ZIP], 
	Customers.Country as [Company country], 
	
	(Employees.FirstName + ' ' +	Employees.LastName) as [Employee name],
	Employees.Country as [Employee country],
	Employees.Region as [Employee region],
	Employees.PostalCode as [Employee ZIP]
from
	Employees inner join
	Orders on Employees.EmployeeID = Orders.EmployeeID inner join
	Customers on Orders.CustomerID = Customers.CustomerID
where
	(YEAR(Orders.OrderDate) = 1996)
group by
	Employees.EmployeeID, 
	Employees.FirstName,
	Employees.LastName,
	Employees.Country,
	Employees.Region, 
	Employees.PostalCode, 

	Customers.CustomerID,
	Customers.CompanyName, 
	Customers.City, 
	Customers.Region, 
	Customers.PostalCode, 
	Customers.Country
order by [Company name], [Employee name]