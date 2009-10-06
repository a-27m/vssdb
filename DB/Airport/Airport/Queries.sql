use Airport;

/*
1.	�������� ������ � �������� �������
	1) ��� �������� ��p���p��
	2) �������� �����
	3) �������� ����������� �����
	
	a) �� ������ ������ � ��p���p��
	b) �������� �������
	c) ����
	d) ������� �������� �� ������� ����
	e) �� ������� �������� �����.
*/

-- ��� ���������
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