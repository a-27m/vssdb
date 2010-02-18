use Airport;
GO
/*
1.	Одержати список і загальну кількість
	1) всіх робітників аеpопоpту --- view Employee
	2) керівників відділів
	3) робітників зазначеного відділу
	
	a) за стажем роботи в аеpопоpту
	b) статевою ознакою
	c) віком
	d) ознакою наявності та кількості дітей
	e) за розміром заробітної платні.
*/

-- все работники
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
			select p.IDPerson as persid, p.Salary as salary, p.IDTeam, p.IDDepartment, 'Пилот' as JobTitle from Pilot p
			union
			select p.IDPerson as persid, p.Salary as salary, p.IDTeam, p.IDDepartment, 'Рабочий' as JobTitle from Worker p
		) empl on Person.IDPerson = empl.persid

GO

if exists (select name from Airport.sys.views where name = 'Boss') drop view Boss;
GO

create view Boss
as
select
	'Бригада' as BossType, Team.IDTeam as ID, Person.*
from
	Team inner join Person on Team.Boss = Person.IDPerson
union
select
	'Отдел' as BossType, Department.IDDepartment as ID, Person.*
from
	Department inner join Person on Department.Boss = Person.IDPerson

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

-- a) по стажу
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
2. Одержати перелік і загальну кількість робітників
	в бригаді, по усіх відділах, у зазначеному відділі;
	які обслуговують конкретний рейс ,
	за віком,
	за сумарною (середньою) зарплатнею в бригаді
*/

select 