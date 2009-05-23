select Products.*--, [Order Details].*
  from Products-- inner join [Order Details] on Products.ProductID = [Order Details].ProductID
 where Products.ProductName = 'Mishi Kobe Niku'
    and exists
    (select *
    from [Order Details] Od
    where Od.Discount > 0
      and Od.ProductID = Products.ProductID
      --and 1 = 2
    )
 