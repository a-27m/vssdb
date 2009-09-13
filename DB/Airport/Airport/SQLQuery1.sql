use master;
GO

if exists (
	select name from sys.databases
	where name = 'airport') drop database airport;
	
create database Airport;
GO

use Airport;

create table Person
(
	IDPerson int PRIMARY KEY NOT NULL,
	FirstName varchar(50) NOT NULL,
	MiddleName varchar(50),
	LastName varchar(50) NOT NULL,
	Birth Date,
	Sex	char(1), -- F or M
	Children int,
)

create table Department
(
	IDDepartment int PRIMARY KEY NOT NULL,
	Title varchar(50) NOT NULL,
	Boss int references Person,
	IDMainDepartment int references Department,
)

create table Team
(
	IDTeam int PRIMARY KEY NOT NULL,
	IDDepartment int references Department,
	Boss int references Person,
)

create table Pilot
(
	IDPilot int PRIMARY KEY NOT NULL,
	IDPerson int references Person,
	Salary money,
)

create table Worker
(
	IDWorker int PRIMARY KEY NOT NULL,
	IDPerson int references Person,
	IDTeam int references Team,
	Salary money,
)

create table MedCheckup
(
	IDMedCheckup int PRIMARY KEY NOT NULL,
	IDPilot int references Pilot,
	CheckDate Date NOT NULL,
	Result int NOT NULL, -- пригодность 0..10
	Comment varchar(1024),
)

create table Plain
(
	IDPlain int PRIMARY KEY NOT NULL,
)

create table TechCheckup
(
	IDCheckup int PRIMARY KEY NOT NULL,
	IDPlain int references Plain
)

create table Flight
(
	IDFlight int PRIMARY KEY NOT NULL,
	
)