﻿CREATE DATABASE MovieTicketManagement;

CREATE TABLE dbo.Movies (
	ID BIGINT IDENTITY NOT NULL PRIMARY KEY,
	MovieName NVARCHAR(255) NOT NULL,
	HeroID BIGINT,
	HeroinID BIGINT,
	Director INT  NOT NULL,

	);