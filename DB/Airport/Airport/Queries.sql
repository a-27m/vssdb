use Airport;
GO
/*
1.	�������� ������ � �������� �������
	1) ��� �������� ��p���p�� --- view Employee
	2) �������� ����� --- view Boss
	3) �������� ����������� ����� --- GetDepartmentEmployees(DeptID int)
	
	a) �� ������ ������ � ��p���p�� +
	b) �������� �������
	c) ����
	d) ������� �������� �� ������� ����
	e) �� ������� �������� ������.
*/

-- ��� ���������
if exists (select name from Airport.sys.views where name = 'Employee') drop view Employee;
GO

create view Employee
as
select
	*
from
	Person
	 inner join 
		(
			select p.IDPerson as persid, p.Salary as salary, p.IDTeam, p.IDDepartment, '�����' as JobTitle from Pilot p
			union
			select p.IDPerson as persid, p.Salary as salary, p.IDTeam, p.IDDepartment, p.JobTitle from Worker p
		) empl on Person.IDPerson = empl.persid

GO

if exists (select name from Airport.sys.views where name = 'Boss') drop view Boss;
GO

create view Boss
as
select
	'��������' as BossType, t.IDTeam as ID,
	p.FirstName,  p.MiddleName, p.LastName, p.Birth,
	w.Hired, w.Salary, w.JobTitle
from
	Team t, Worker w, Person p
where t.Boss = w.IDWorker
  and w.IDPerson = p.IDPerson
union
select
	'��������� ������' as BossType, d.IDDepartment as ID,
	p.FirstName,  p.MiddleName, p.LastName, p.Birth,
	w.Hired, w.Salary, w.JobTitle
from
	Department d, Worker w, Person p
where d.Boss = w.IDWorker
  and w.IDPerson = p.IDPerson
GO

if object_id (N'GetDepartmentEmployees', N'IF') is not null
	drop function GetDepartmentEmployees;
GO
create function GetDepartmentEmployees (@DeptID int)
returns table
as
return
(
	select * from Employee where IDDepartment = @DeptID
);
GO

-- a) �� �����
select
	*, DateDiff(month, e.Hired, GetDate()) as Stage
from
	Employee e
order by Stage desc

-- b) sex
select
	*
from
	Employee e
order by e.Sex desc

-- c) age
select
	*, DateDiff(year, e.Birth, GetDate()) as Age
from
	Employee e
order by Age desc

--22222222222222222222222222222222222222222222222222222222222222222222222222222
/*
2. �������� ������ � �������� ������� ��������
	� ������, �� ��� ������, � ����������� ����;
	�� ������������ ���������� ���� ,
	�� ����,
	�� �������� (���������) ���������� � ������
*/

select
	*
from
	PlannedFlight pf, Team t, Plane p
where
	t.IDPlane = p.IDPlane