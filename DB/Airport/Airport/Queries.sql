use Airport;

/*
1.	Одержати список і загальну кількість
	1) всіх робітників аеpопоpту
	2) керівників відділів
	3) робітників зазначеного відділу
	
	a) за стажем роботи в аеpопоpту
	b) статевою ознакою
	c) віком
	d) ознакою наявності та кількості дітей
	e) за розміром заробітної платні.
*/

-- все работники
select
	*
from
	Person p
where exists	
	 inner join 
		(
			select p.IDPerson as persid, p.Salary as salary, p.IDTeam from Pilot p
			union
			select p.IDPerson as persid, p.Salary as salary, p.IDTeam from Worker p
		) empl on Person.IDPerson = empl.persid