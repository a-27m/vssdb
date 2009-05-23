select Products.ProductID, Products.ProductName, Products.QuantityPerUnit, Products.UnitPrice
from Products inner join [Order Details] on Products.ProductID = [Order Details].ProductID
where [Order Details].Discount = 0.15
group by Products.ProductID, Products.ProductName, Products.QuantityPerUnit, Products.UnitPrice
order by 2 asc