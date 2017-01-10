create database[Pts]on primary(name=[Pts],filename='C:\Users\mazhe\Desktop\Test\pirates\pt\pt\App_Data\Pts.mdf')
log on(name=[Pts_log],filename='C:\Users\mazhe\Desktop\Test\pirates\pt\pt\App_Data\Pts_log.ldf')

use [Pts]
go

alter table[dbo].[Crew]
drop constraint[FK_dbo.Crew_dbo.Ships_ShipId],
     constraint[FK_dbo.Crew_dbo.Pirates_PirateId];
	 
			   
if object_id('dbo.Pirates') is not null
drop table [dbo].[Pirates];

if object_id('dbo.Ships') is not null
drop table [dbo].[Ships];

if object_id('dbo.Crew') is not null
drop table [dbo].[Crew];


create table [dbo].[Pirates]
(
	[id] int not null identity(1,1),
	[Name] nvarchar(50) not null,
	[Date]datetime2(7) not null,
	constraint[pk_dbo.Pirates]primary key clustered([id]asc)
);
create table [dbo].[Ships]
(
	[id] int not null identity(1,1),
	[Name] nvarchar(20) not null,
	[Type] nvarchar(20) not null,
	[Ton] int not null,	
	constraint[pk_dbo.Ships]primary key clustered([id]asc)
);
create table[dbo].[Crew]
(
	[id] int not null identity (1,1),
	[ShipId] int not null,
	[PirateId] int not null,
	[Booty] decimal not null,
	constraint[pk_dbo.crew] primary key clustered([id]asc),
	constraint[fk_dbo.Crew_dbo.Pirates_id] foreign key([PirateId])references[dbo].[Pirates]([id]),
	constraint[fk_dbo.Crew_dbo.Ships_id] foreign key([ShipId]) references[dbo].[Ships]([id])

);

