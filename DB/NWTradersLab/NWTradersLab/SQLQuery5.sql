/*
5.	ѕосчитать и выдать дл€ указанного заказа 10263 стоимость
    товара с учетом дисконта, если таковой есть.
*/
select
	count(*) as Items,
	SUM(CONVERT(money, (UnitPrice * Quantity) * (1 - Discount) / 100) * 100) AS Subtotal
	--,
	--SUM(CONVERT(money, (UnitPrice * Quantity) * (1 - Discount) )) AS Subtotal2,
	--SUM(((UnitPrice * Quantity) * (1 - Discount) / 100) * 100) AS Subtotal3,
	--SUM( (UnitPrice * Quantity) * (1 - Discount) ) AS Subtotal4,
	--SUM( UnitPrice * Quantity * (1 - Discount) ) AS Subtotal5	
from [Order Details]
where [Order Details].OrderID = 10263