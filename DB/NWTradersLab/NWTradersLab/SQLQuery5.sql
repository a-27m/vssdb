/*
5.	��������� � ������ ��� ���������� ������ 10263 ���������
    ������ � ������ ��������, ���� ������� ����.
*/
select count(*) as Positions,
       SUM([Order Details].Quantity*Products.UnitPrice*[Order Details].Discount) as TotalSum
from Products inner join [Order Details] on Products.ProductID = [Order Details].ProductID
where [Order Details].OrderID = 10263