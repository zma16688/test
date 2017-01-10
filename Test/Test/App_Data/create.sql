
create database [test_db] on primary
(name=[Test],filename='C:\Users\mazhe\Desktop\Test\Test\App_Data\Test.mdf') 
log on (name = [Test_log],filename='C:\Users\mazhe\Desktop\Test\Test\App_Data\Test_log.ldf');
go
use [test_db]
go

CREATE TABLE [dbo].[Students]
(
	[ID] INT IDENTITY (1,1) NOT NULL,

	[VNumber] NVARCHAR (50) NOT NULL, 
	[FirstName] NVARCHAR (50) NOT NULL,
	[LastName] NVARCHAR (50) NOT NULL,
	[Date] NVARCHAR(50) NOT NULL,
	[PhoneNumber]  NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR (50) NOT NULL,
	[Major] NVARCHAR (50) NOT NULL,
	[Minor] NVARCHAR (50) NOT NULL,
	[Advisor] NVARCHAR (50) NOT NULL,
	CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED ([ID] ASC)
);
go
insert into [dbo].[students](VNumber,FirstName,LastName,Date,PhoneNumber,Email,Major,Minor,Advisor)values('00233123','Blake','Shelton','8/24/1990','206-334-8880','blake110@wou.edu','Computer Science','Math','David');

