use master;
GO

if exists (
	select name from sys.databases
	where name = 'Airport') drop database airport;
	
create database Airport;
GO

use Airport;

create table Person
(
	IDPerson int PRIMARY KEY NOT NULL , -- identity
	FirstName varchar(50) NOT NULL,
	MiddleName varchar(50),
	LastName varchar(50) NOT NULL,
	Birth Datetime, -- Date
	Sex	char(1), -- F or M
	Children int,

	check (Sex = 'F' or Sex = 'M')
)

create table Department
(
	IDDepartment int PRIMARY KEY NOT NULL , -- identity
	Title varchar(50) NOT NULL,
	Boss int references Person,
	IDMainDepartment int references Department,
)

create table Team
(
	IDTeam int PRIMARY KEY NOT NULL , -- identity
	IDDepartment int references Department,
	Boss int references Person,
)

create table Pilot
(
	IDPilot int PRIMARY KEY NOT NULL , -- identity
	IDPerson int references Person,
	Salary money,
)

create table Worker
(
	IDWorker int PRIMARY KEY NOT NULL , -- identity
	IDPerson int references Person,
	IDTeam int references Team,
	Salary money,
)

create table MedCheckup
(
	IDMedCheckup int PRIMARY KEY NOT NULL , -- identity
	IDPilot int references Pilot,
	CheckDate Datetime NOT NULL, -- Date
	Result int NOT NULL, -- пригодность 0..10
	Comment varchar(1024),
)

/*
 К р а т к а я   характеристика самолета Як-18Т:

государственный и регистрационный знак ВС-RA-44289;
марка двигателя – М14П № КЯ312013;
марка воздушного винта – В530ТА-Д35 № 2000098;
серийный (заводской) номер – 07-32 АО «Смоленский авиационный завод»;
дата выпуска – 18.06.1993 года;
установленный ресурс (часов, посадок) – 5000 ч., 20000 посадок;
наработка с начала эксплуатации (часов, посадок) – 653 час. 18 мин., 2005 посадок;
остаток ресурса (часов, посадок) – 4345 ч.,17995 посадок;
дата последнего вылета – 15.08.2004 года;
количество ремонтов – 2;
Первоначальная стоимость самолета Як-18Т 458 459, 26 рублей. 
Сертификат летной годности истек 31.12.2005 году, необходимо продление календарного срока эксплуатации. 
Прописка - аэропорт
*/
create table Plane
(
	IDPlane int PRIMARY KEY NOT NULL , -- identity
	Model varchar(20) NOT NULL,
	RegNo varchar(15) NOT NULL,
	ManufactDate datetime, -- Date
	ResHours int,
	ResLandings int,
	WorkoutHours int,
	WorkoutLandings int,
	LastDeparture datetime,
	Cost money,
)

create table TechCheckup
(
	IDCheckup int PRIMARY KEY NOT NULL , -- identity
	IDPlane int references Plane on delete cascade
)

create table Flight
(
	IDFlight int PRIMARY KEY NOT NULL , -- identity
	IDAviaCompany int, -- references AviaCompany
	
	ShortTitle varchar(10),
)

create table RouteType
(
	IDRouteType int PRIMARY KEY NOT NULL , -- identity
	Title varchar(20) NOT NULL,
)

create table AirRoute
(
	IDRoute int PRIMARY KEY NOT NULL , -- identity
	ShortTitle varchar(20),
	IDRouteType int references RouteType on delete set null,
)


create table PlannedRoute
(
	IDPlannedRoute int PRIMARY KEY NOT NULL , -- identity
	IDAirRoute int references AirRoute,
	Price money,
)

create table PlannedFlight
(
	IDPlannedFlight int PRIMARY KEY NOT NULL , -- identity
	IDFlight int references Flight,
	IDPlannedRoute int references PlannedRoute,
	IDPlane	int references Plane,
	Departure Datetime,
	Price money,
	FlightStatus int,
)

create table Ticket
(
	IDTicket int PRIMARY KEY NOT NULL , -- identity
	IDPlannedRoute int references PlannedRoute,
)

create table Passenger
(
	IDPassanger int PRIMARY KEY NOT NULL , -- identity
	FirstName varchar(50) NOT NULL,
	MiddleName varchar(50),
	LastName varchar(50) NOT NULL,
	Sex	char(1), -- F or M
	Multipas char(8) NOT NULL, -- Ukr passport No
	MultipasItl varchar(12) NULL, -- may be NULL if it's internal flight passenger
	Customs	tinyint NULL, -- nullable, for internal flights

	check (Sex = 'F' or Sex = 'M')
)