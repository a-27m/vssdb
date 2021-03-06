/*
1.	Для заданного товара 'Mishi Kobe Niku' выполнить проверку 
    наличия дисконта и выдать его значение, если он существует.
    (Использовать квантор существования).
*/

-- no quantors
select distinct 
	Products.ProductID,
	Products.ProductName,
	[Order Details].Discount
from
	Products inner join [Order Details] on Products.ProductID = [Order Details].ProductID
where 
	Discount > 0
	and ProductName = 'Mishi Kobe Niku'
order by
	Discount desc;

-- with quantor
select distinct 
	p.ProductID,
	p.ProductName,
	o.Discount
from
	Products p inner join [Order Details] o on p.ProductID = o.ProductID
where exists (
	select *
	from [Order Details] t
	where t.Discount > 0
	  and t.ProductID = p.ProductID
	)
 and o.Discount > 0
 and p.ProductName = 'Mishi Kobe Niku'
order by
	o.Discount desc;

-- ручная оптимизация
select p.ProductID, p.ProductName, Discount
from
(select distinct ProductID, Discount
from [Order Details]
where Discount > 0
  and ProductID = (select top 1 ProductID from Products where ProductName = 'Mishi Kobe Niku')
) t inner join
(select top 1 ProductID, ProductName
from Products
where ProductName = 'Mishi Kobe Niku'
) p on t.ProductID = p.ProductID
order by
	Discount desc;