select Products.ProductName, Products.UnitPrice
from Products
where Products.SupplierID = (
	select top 1 Suppliers.SupplierID 
	from Suppliers
	where Suppliers.CompanyName = 'Karkki Oy'
	)
order by 2 desc;

