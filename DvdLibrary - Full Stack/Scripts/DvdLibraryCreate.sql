USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='DvdLibrary')
DROP DATABASE DvdLibrary
GO

CREATE DATABASE DvdLibrary
GO

USE DvdLibrary
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Dvds')
	DROP TABLE Dvds
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Ratings')
	DROP TABLE Ratings
GO


CREATE TABLE Ratings (
	RatingId varchar(5) not null primary key
)

CREATE TABLE Dvds (
	DvdId int identity(1,1) not null primary key,
	RatingId varchar(5) not null foreign key references Ratings(RatingId),
	Title varchar(25) not null,
	ReleaseYear varchar(4),
	Director varchar(20),
	Notes varchar(50)
)
