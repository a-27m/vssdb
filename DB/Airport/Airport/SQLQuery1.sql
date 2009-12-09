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
	Hired datetime,
	
	check (Sex = 'F' or Sex = 'M')
)

/*
 � � � � � � �   �������������� �������� ��-18�:

��������������� � ��������������� ���� ��-RA-44289;
����� ��������� � �14� � ��312013;
����� ���������� ����� � �530��-�35 � 2000098;
�������� (���������) ����� � 07-32 �� ����������� ����������� �����;
���� ������� � 18.06.1993 ����;
������������� ������ (�����, �������) � 5000 �., 20000 �������;
��������� � ������ ������������ (�����, �������) � 653 ���. 18 ���., 2005 �������;
������� ������� (�����, �������) � 4345 �.,17995 �������;
���� ���������� ������ � 15.08.2004 ����;
���������� �������� � 2;
�������������� ��������� �������� ��-18� 458 459, 26 ������. 
���������� ������ �������� ����� 31.12.2005 ����, ���������� ��������� ������������ ����� ������������. 
�������� - ��������
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
	--IDDepartment int references Department,
	IDPlane int references Plane on delete set null,
	Boss int references Person,
	
)

create table Pilot
(
	IDPilot int PRIMARY KEY NOT NULL , -- identity
	IDPerson int references Person,
	IDTeam int references Team on delete set null,
	IDDepartment int references Department on delete set null,
	Salary money,
)

create table Worker
(
	IDWorker int PRIMARY KEY NOT NULL , -- identity
	IDPerson int references Person,
	IDTeam int references Team,
	IDDepartment int references Department on delete set null,
	Salary money,
)

create table MedCheckup
(
	IDMedCheckup int PRIMARY KEY NOT NULL , -- identity
	IDPilot int references Pilot,
	CheckDate Datetime NOT NULL, -- Date
	Result int NOT NULL, -- ����������� 0..10
	Comment varchar(1024),
)

create table TechCheckup
(
	IDCheckup int PRIMARY KEY NOT NULL , -- identity
	IDPlane int references Plane on delete cascade,
	Datetaken datetime NOT NULL,
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

create table DelayCause
(
	IDDelayCause int primary key NOT NULL , -- identity
	Descript varchar(1024) NOT NULL,
	-- ? �������� ��������, �������� � ������ �������������, ������ �� ������ ����������...
)

create table Delayed
(
	IDDelayed int PRIMARY KEY NOT NULL , -- identity
	IDPlannedFlight int references PlannedFlight on delete cascade,
	IDDelayCause int references DelayCause on delete set NULL,
	DelayMinutes int,
	-- DelayInterval datetime,
)

/*
�������� ��������� ��� "��������������" ����� ��������� ������������ ��������� �����.
*/
create table Place
(
	IDPlace int PRIMARY KEY NOT NULL, -- identity
	IDPlannedFlight int references PlannedFlight on delete cascade,
	Number int,
	Sold int,
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

create table Ticket
(
	IDTicket int PRIMARY KEY NOT NULL , -- identity
	IDPlace int references Place on delete set null,
	IDPassenger int references Passenger,
	DateSold datetime,
)