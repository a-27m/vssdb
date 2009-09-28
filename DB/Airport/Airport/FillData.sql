use Airport;

delete from Passenger;

delete from Ticket;
delete from TechCheckup;
delete from Worker;
delete from MedCheckup;
delete from Pilot;
delete from Team;
delete from Department;

delete from PlannedFlight;
delete from PlannedRoute;
delete from AirRoute;
delete from RouteType;
delete from Flight;
delete from Plane;
delete from Person;

insert into Person values (101, 'Алексей', 'Анатольевич', 'Мироненко', '1988-04-30','M',0)
insert into Person values (102, 'Иван', 'Петрович', 'Сидоров', '1945-03-12','M',2)
select * from Person;

insert into Plane values (1, 'Як-18Т', 'RA-13244', '2001-05-30', 5000, 20000, 653, 2005, '2009-09-30', 143581.26)
insert into Plane values (2, 'Boeing-737', 'W3244', '2004-11-22', 4500, 22000, 212, 720, '2009-09-26', 351455.00)
select * from Plane;

insert into Flight values (1, 0, 'BPL-Frank')
insert into Flight values (2, 0, 'Frank-NYC')
insert into Flight values (3, 0, 'NYC-Zuric')
insert into Flight values (4, 0, 'Zur-Frank')
insert into Flight values (5, 0, 'Frank-BOM')
select * from Flight;

insert into RouteType values (1, 'Internal')
insert into RouteType values (2, 'International')
insert into RouteType values (3, 'Private')
insert into RouteType values (4, 'Special')
insert into RouteType values (5, 'Charter')
select * from RouteType

insert into AirRoute values (10, 'BPL-NYC', 2)
insert into AirRoute values (21, 'NYC-BOM', 2)
select * from AirRoute;

--delete from AirRouteTypes
--insert into AirRouteTypes values (1, 10, 2)
--insert into AirRouteTypes values (2, 21, 2)
--select * from AirRoute;

insert into PlannedRoute values (1, 10, 1600)
insert into PlannedRoute values (2, 10, 1400)
insert into PlannedRoute values (3, 21, 2700)
select *  from PlannedRoute;

insert into PlannedFlight values (5, 1, 1, 2, '2009-10-04', 400, null); 
insert into PlannedFlight values (6, 2, 1, 2, '2009-10-05', 700, null);
insert into PlannedFlight values (7, 1, 2, 1, '2009-12-30', 400, null); --
insert into PlannedFlight values (8, 2, 2, 1, '2009-12-31', 700, null);
insert into PlannedFlight values (9, 3, 3, 2, '2009-09-27', 650, null);
insert into PlannedFlight values (10,4, 3, 2, '2009-09-28', 200, null); --
insert into PlannedFlight values (11,5, 3, 2, '2009-09-28', 650, null);
select * from PlannedFlight;

insert into Ticket values (1001, 1)
insert into Ticket values (1002, 3)
select * from Ticket;

