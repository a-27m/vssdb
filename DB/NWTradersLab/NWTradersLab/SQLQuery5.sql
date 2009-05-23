/*
5.	ѕосчитать и выдать дл€ указанного заказа 10263 стоимость
    товара с учетом дисконта, если таковой есть.
*/
select count(*) as Positions,
       SUM([Order Details].Quantity*Products.UnitPrice*[Order Details].Discount) as TotalSum
from Products inner join [Order Details] on Products.ProductID = [Order Details].ProductID
where [Order Details].OrderID = 10263