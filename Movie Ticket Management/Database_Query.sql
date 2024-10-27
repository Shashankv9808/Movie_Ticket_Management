
------------------------------------------------------
--Table Creation
------------------------------------------------------

CREATE TABLE [dbo].[UserAccount]
(
	UserID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserName NVARCHAR(MAX) NOT NULL,
	EncryptedPassword NVARCHAR(MAX) NOT NULL,
	FirstName VARCHAR(128) NOT NULL,
	LastName VARCHAR(128) NOT NULL,
	ContactNumber NUMERIC(10,0) NOT NULL,
	EmailAddress NVARCHAR(255) NOT NULL,
	IsUserAdmin BIT NOT NULL,
	ImageSize INT,
	ImageData VARBINARY(MAX)
);

CREATE TABLE [dbo].[Genres] (
    GenreID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    GenreName VARCHAR(64) NOT NULL
);


CREATE TABLE [dbo].[Movies]
(
	MovieID BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	MovieName NVARCHAR(255) NOT NULL,
	HeroID INT,
	HeroinID INT,
	DirectorID INT NOT NULL,
	StoryWriterID INT NOT NULL,
	GenreID INT NOT NULL,
	Cost NUMERIC(10,4) NOT NULL,
	Rating NUMERIC(2,1),
	Duration NUMERIC(4,2) NOT NULL,
	ImageSize INT NOT NULL,
	ImageData VARBINARY(MAX) NOT NULL
);

CREATE TABLE [dbo].[MovieCast]
(
	PersonID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	PersonName VARCHAR(255) NOT NULL,
	PersonAge INT NOT NULL,
	PersonHeight INT NOT NULL,
	ImageSize INT,
	ImageData VARBINARY(MAX)
);




------------------------------------------------------
--Stored Procedure Creation
------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[spGetAllMovieDetails]

AS

BEGIN
	SELECT
		Movies.MovieID,
		Movies.MovieName,
		HeroCast.PersonName AS HeroName,
		HeroinCast.PersonName AS HeroinName,
		DirectorCast.PersonName AS DirectorName,
		StoryWriterCast.PersonName AS StoryWriterName,
		Genres.GenreName,
		Movies.Cost,
		Movies.Rating,
		Movies.Duration,
		Movies.ImageSize,
		Movies.ImageData
	 FROM 
        Movies
    INNER JOIN MovieCast HeroCast ON
		Movies.HeroID = HeroCast.PersonID
    INNER JOIN MovieCast HeroinCast ON
		Movies.HeroinID = HeroinCast.PersonID
    INNER JOIN MovieCast DirectorCast ON
		Movies.DirectorID = DirectorCast.PersonID
    INNER JOIN MovieCast StoryWriterCast ON
		Movies.StoryWriterID = StoryWriterCast.PersonID
    INNER JOIN Genres ON
		Movies.GenreID = Genres.GenreID;
END

GO