use Airport;

 delete from Ticket;
 delete from Passenger;

 delete from TechCheckup;
 delete from Worker;
 delete from MedCheckup;
 delete from Pilot;
 delete from Team;
 delete from Department;

 delete from Seat;
 delete from Delayed;
 delete from DelayCause;
 delete from PlannedFlight;
 delete from PlannedRoute;
 delete from AirRoute;
 delete from RouteType;
 delete from Flight;
 delete from Plane;
 delete from Person;

insert into Person values (111, 'Алексей', 'Анатольевич', 'Мироненко', '1988-04-30','M',0, '2009-01-01')
insert into Person values (112, 'Иван', 'Петрович', 'Сидоров', '1945-03-12','M',2, '2009-01-01')
insert into Person values (121, 'Нина', 'Федоровна', 'Двойченко', '1961-05-17','F',2, '2009-01-01')
insert into Person values (122, 'Наталия', 'Михайловна', 'Степанова', '1968-09-28','F',0, '2009-01-01')
insert into Person values (131, 'Елена', 'Петровна', 'Максимчук', '1983-02-05','F',1, '2009-01-01')
insert into Person values (141, 'Вениамин', 'Александрович', 'Беляев', '1959-01-27','M',1, '2009-01-01')
insert into Person values (142, 'Сергей', 'Витальевич', 'Деркач', '1977-12-10','M',0, '2009-01-01')
insert into Person values (143, 'Иван', 'Семенович', 'Сидоренко', '1974-04-15','M',0, '2009-01-01')
insert into Person values (144, 'Евгений', 'Сергеевич', 'Бакланов', '1965-07-25','M',1, '2009-01-01')
--select * from Person;

insert into Plane values (1, 'Як-18Т', 'RA-13244', '2001-05-30', 5000, 20000, 653, 2005, '2009-09-30', 143581.26)
insert into Plane values (2, 'Boeing-737', 'W3244', '2004-11-22', 4500, 22000, 212, 720, '2009-09-26', 351455.00)
--select * from Plane;

insert into Flight values (1, 0, 'BPL-Frank')
insert into Flight values (2, 0, 'Frank-NYC')
insert into Flight values (3, 0, 'NYC-Zuric')
insert into Flight values (4, 0, 'Zur-Frank')
insert into Flight values (5, 0, 'Frank-BOM')
--select * from Flight;

insert into RouteType values (1, 'Internal')
insert into RouteType values (2, 'International')
insert into RouteType values (3, 'Private')
insert into RouteType values (4, 'Special')
insert into RouteType values (5, 'Charter')
--select * from RouteType

insert into AirRoute values (10, 'BPL-NYC', 2)
insert into AirRoute values (21, 'NYC-BOM', 2)
--select * from AirRoute;

insert into PlannedRoute values (1, 10, 1600)
insert into PlannedRoute values (2, 10, 1400)
insert into PlannedRoute values (3, 21, 2700)
--select *  from PlannedRoute;

insert into PlannedFlight values (5, 1, 1, 2, '2009-10-04', 400, null); 
insert into PlannedFlight values (6, 2, 1, 2, '2009-10-05', 700, null);
insert into PlannedFlight values (7, 1, 2, 1, '2009-12-30', 400, null); --
insert into PlannedFlight values (8, 2, 2, 1, '2009-12-31', 700, null);
insert into PlannedFlight values (9, 3, 3, 2, '2009-09-27', 650, null);
insert into PlannedFlight values (10,4, 3, 2, '2009-09-28', 200, null); --
insert into PlannedFlight values (11,5, 3, 2, '2009-09-28', 650, null);
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

insert into Department values (1, 'Администрация', 111, null);
insert into Department values (2, 'Бухгалтерия', 121, 1);
insert into Department values (3, 'Плановый', 131, 1);
insert into Department values (4, 'Технический', 141, 1);
--select * from Department;

insert into Team values (1111, 2, 141)
insert into Team values (2222, 1, 142)
--select * from Team;

insert into Pilot values(1, 111, 1111, 4, 7000);
insert into Pilot values(2, 143, 2222, 4, 7000);
--select * from Pilot;

insert into MedCheckup values(1, 1, '2009-03-31', 4, 'Такой длинный и подробный комментарий');
insert into MedCheckup values(2, 1, '2009-02-28', 5, 'Такой длинный и очень подробный комментарий');
insert into MedCheckup values(3, 2, '2009-03-31', 2, 'Такой очень длинный и подробный комментарий');
insert into MedCheckup values(4, 2, '2009-02-28', 4, 'Такой сверх длинный и очень подробный комментарий');
--select * from MedCheckup;

insert into Worker values (1, 144, 1111, 4, 'Рабочий', 2000);
insert into Worker values (2, 141, 1111, 4, 'Помощник рабочего', 1000);

insert into TechCheckup values (4, 1, '2009-07-09');
insert into TechCheckup values (5, 2, '2009-07-16');

insert into Passenger values (1, 'Дмитрий', 'Герасимович', 'Туманов', 'M', 'СВ123456', 'UKR187-441', 0)
insert into Passenger values (2, 'Николай', 'Александрович', 'Луговой', 'M', 'СВ654321', 'RUS12954', 0)


insert into Ticket values (1001, 6, 1, '2009-10-03 18:45')
insert into Ticket values (1002, 8, 2, '2009-10-03 18:46')