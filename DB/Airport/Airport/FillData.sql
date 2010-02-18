use Airport;

-- delete from Ticket;
-- delete from Passenger;

--  delete from TechCheckup;
--  delete from MedCheckup;
-- delete from Pilot;
--delete from Team;
--delete from Department;
--delete from Worker;
-- delete from Seat;
-- delete from Delayed;
-- delete from DelayCause;
-- delete from PlannedFlight;
-- delete from AirRoute;
-- delete from Flight;
-- delete from FlightType; 
-- delete from Plane;
-- delete from Person;

insert into Person values (111, 'Алексей', 'Анатольевич', 'Мироненко', '1988-04-30','M',0)
insert into Person values (112, 'Иван', 'Петрович', 'Сидоров', '1945-03-12','M',2)
insert into Person values (121, 'Нина', 'Федоровна', 'Двойченко', '1961-05-17','F',2)
insert into Person values (122, 'Наталия', 'Михайловна', 'Степанова', '1968-09-28','F',0)
insert into Person values (131, 'Елена', 'Петровна', 'Максимчук', '1983-02-05','F',1)
insert into Person values (141, 'Вениамин', 'Александрович', 'Беляев', '1959-01-27','M',1)
insert into Person values (142, 'Сергей', 'Витальевич', 'Деркач', '1977-12-10','M',0)
insert into Person values (143, 'Иван', 'Семенович', 'Сидоренко', '1974-04-15','M',0)
insert into Person values (144, 'Евгений', 'Сергеевич', 'Бакланов', '1965-07-25','M',1)
--select * from Person;

insert into Plane values (1, 'Як-18Т', 'RA-13244', '2001-05-30', 5000, 20000, 653, 2005, '2009-09-30', 143581.26)
insert into Plane values (2, 'Boeing-737', 'W3244', '2004-11-22', 4500, 22000, 212, 720, '2009-09-26', 351455.00)
insert into Plane values (3, 'АН-27', 'QB5-942', '2003-02-14', 7000, 30000, 431, 5000, '2009-12-30', 207415.57)
--select * from Plane;

insert into FlightType values (1, 'Internal')
insert into FlightType values (2, 'International')
insert into FlightType values (3, 'Private')
insert into FlightType values (4, 'Special')
insert into FlightType values (5, 'Charter')
--select * from FlightType

insert into Flight values (1, 0, 'BPL-Frank', 3)
insert into Flight values (2, 0, 'Frank-NYC', 2)
insert into Flight values (3, 0, 'NYC-Zuric', 2)
insert into Flight values (4, 0, 'Zur-Frank', 2)
insert into Flight values (5, 0, 'Frank-BOM', 2)
--select * from Flight;

insert into AirRoute values (10, 'BPL-NYC', 2)
insert into AirRoute values (21, 'NYC-BOM', 2)
--select * from AirRoute;

insert into PlannedFlight values (5, 1, 1, '2009-10-04', 4000, null); 
insert into PlannedFlight values (6, 2, 1, '2009-10-05', 7000, null);
insert into PlannedFlight values (7, 1, 2, '2009-12-30', 4000, null); --
insert into PlannedFlight values (8, 2, 2, '2009-12-31', 7000, null);
insert into PlannedFlight values (9, 3, 3, '2009-09-27', 6500, null);
insert into PlannedFlight values (10,4, 3, '2010-03-28', 2000, null); --
insert into PlannedFlight values (11,5, 3, '2010-03-28', 6500, null);
--select * from PlannedFlight;

insert into Seat values (1, 5, 1, 0);
insert into Seat values (2, 5, 3, 0);
insert into Seat values (3, 5, 5, 1);
insert into Seat values (4, 5, 7, 1);
insert into Seat values (5, 5, 9, 1);
insert into Seat values (6, 5, 11, 0);
insert into Seat values (7, 5, 13, 0);
insert into Seat values (8, 5, 15, 0);
insert into Seat values (9, 5, 17, 0);
insert into Seat values (10, 5, 19, 0);
insert into Seat values (11, 5, 21, 0);

insert into Worker values (1, 144, null, null, 'Рабочий', 2000, '2007-05-01');
insert into Worker values (2, 141, null, null, 'Помощник рабочего', 1000, '2009-02-01');
insert into Worker values (3, 142, null, null, 'Механик', 2500, '2008-06-17');
insert into Worker values (4, 111, null, null, 'Председатель правления', 17000, '2007-04-15');
insert into Worker values (5, 121, null, null, 'Главный бухгалтер', 4000, '2008-06-28');
insert into Worker values (6, 131, null, null, 'Начальник планового отдела', 3000, '2010-02-01');
insert into Worker values (7, 141, null, null, 'Главный механик', 5000, '2007-11-04');

insert into Department values (1, 'Администрация', 4, null);
insert into Department values (2, 'Бухгалтерия', 5, 1);
insert into Department values (3, 'Плановый', 6, 1);
insert into Department values (4, 'Технический', 7, 1);
--select * from Department;

insert into Team values (1111, 2, 1)
insert into Team values (2222, 1, 3)
--select * from Team;

update Worker set IDDepartment = 4 where IDWorker = 1;
update Worker set IDDepartment = 4 where IDWorker = 2;
update Worker set IDDepartment = 4 where IDWorker = 3;
update Worker set IDDepartment = 1 where IDWorker = 4;
update Worker set IDDepartment = 2 where IDWorker = 5;
update Worker set IDDepartment = 3 where IDWorker = 6;
update Worker set IDDepartment = 4 where IDWorker = 7;

update Worker set IDTeam = 1111 where IDWorker = 1;
update Worker set IDTeam = 1111 where IDWorker = 2;
update Worker set IDTeam = 2222 where IDWorker = 3;

insert into Pilot values(1, 111, 1111, 4, 7000, '2008-09-01');
insert into Pilot values(2, 143, 2222, 4, 7000, '2007-05-01');
--select * from Pilot;

insert into MedCheckup values(1, 1, '2009-03-31', 4, 'Такой длинный и подробный комментарий');
insert into MedCheckup values(2, 1, '2009-02-28', 5, 'Такой длинный и очень подробный комментарий');
insert into MedCheckup values(3, 2, '2009-03-31', 2, 'Такой очень длинный и подробный комментарий');
insert into MedCheckup values(4, 2, '2009-02-28', 4, 'Такой сверх длинный и очень подробный комментарий');
--select * from MedCheckup;

insert into TechCheckup values (4, 1, '2009-07-09');
insert into TechCheckup values (5, 2, '2009-07-16');

insert into Passenger values (1, 'Дмитрий', 'Герасимович', 'Туманов', 'M', 'СВ123456', 'UKR187-441', 0)
insert into Passenger values (2, 'Николай', 'Александрович', 'Луговой', 'M', 'СВ654321', 'RUS12954', 0)


insert into Ticket values (1001, 6, 1, '2009-10-03 18:45')
insert into Ticket values (1002, 8, 2, '2009-10-03 18:46')