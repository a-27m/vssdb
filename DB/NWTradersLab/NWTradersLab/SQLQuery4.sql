/*
4.	Для заданного товара Maxilaku выполнить проверку 
    наличия дисконта и выдать его значение, если он существует.
    (Использовать квантор существования).
    См. п.1.
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
	and ProductName = 'Maxilaku'
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
 and p.ProductName = 'Maxilaku'
order by
	o.Discount desc;
	