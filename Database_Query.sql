
------------------------------------------------------
--Table Creation
------------------------------------------------------
CREATE TABLE [dbo].[ErrorLog]
(
	ErrorLogID BIGINT IDENTITY (-9223372036854775808, 1) NOT NULL, -- max negative number for bigint
	ErrorDateTime DATETIME NOT NULL,
	ErrorNumber INT NOT NULL DEFAULT(0),
	ErrorSeverity INT NOT NULL DEFAULT(0),
	ErrorState INT NOT NULL DEFAULT(0),
	ErrorProcedure NVARCHAR(126) NOT NULL DEFAULT(''),
	ErrorLine INT NOT NULL DEFAULT(0),
	ErrorMessage NVARCHAR(2048) NOT NULL DEFAULT('')
)

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
--Onboarding Script
------------------------------------------------------

INSERT INTO UserAccount (UserName,EncryptedPassword,FirstName,LastName,ContactNumber,EmailAddress,IsUserAdmin,ImageData,ImageSize) VALUES('admin','jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=','ISource','Infos',0123456789,'isourceinfos@gmail.com',1,NULL,NULL);

---------------------------------------------------------------------
-- Remove existing version
---------------------------------------------------------------------
GO
IF OBJECT_ID('dbo.spErrorHandler') IS NOT NULL
    DROP PROCEDURE dbo.spErrorHandler
GO

GO
IF OBJECT_ID('dbo.spGetAllMovieDetails') IS NOT NULL
	DROP PROCEDURE dbo.spGetAllMovieDetails
GO

IF OBJECT_ID('dbo.spRegisterUserAccount') IS NOT NULL
	DROP PROCEDURE dbo.spRegisterUserAccount
GO

IF OBJECT_ID('dbo.spGetAllUserAccountDetails') IS NOT NULL
	DROP PROCEDURE dbo.spGetAllUserAccountDetails
GO

IF OBJECT_ID('dbo.spUserAccountAuthenication') IS NOT NULL
	DROP PROCEDURE dbo.spUserAccountAuthenication
GO
------------------------------------------------------
--Stored Procedure Creation
------------------------------------------------------


CREATE PROCEDURE dbo.spErrorHandler
(
    @Rollback bit = 1,
    @Rethrow bit = 1
)
AS

    DECLARE 
        @ErrorDateTime datetime,
        @ErrorNumber int,
        @ErrorSeverity int,
        @ErrorState int,
        @ErrorProcedure nvarchar(126),
        @ErrorLine int,
        @ErrorMessage nvarchar(2048)
        
    -- Capture the error information that caused the catch block to be invoked
	SELECT 
            @ErrorDateTime = GETDATE(),
            @ErrorNumber = ERROR_NUMBER(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE(),
            @ErrorProcedure = ISNULL(ERROR_PROCEDURE(), '<dyanmic SQL>'),
            @ErrorLine = ERROR_LINE(),
            @ErrorMessage = ERROR_MESSAGE()
    
    IF @Rollback = 1 AND (XACT_STATE()) <> 0
    BEGIN
        ROLLBACK TRANSACTION
    END
    --If the error being handled was thrown by this procedure (the error handler)
    --do not repersist the error in the error log.  It was already logged once.
	IF @ErrorProcedure <> OBJECT_NAME(@@PROCID)
        BEGIN
            --Persist the error
            INSERT INTO ErrorLog
            (
                ErrorDateTime,
                ErrorNumber,
                ErrorSeverity,
                ErrorState,
                ErrorProcedure,
                ErrorLine,
                ErrorMessage
            )
            VALUES
            (
                @ErrorDateTime,
                @ErrorNumber,
                @ErrorSeverity,
                @ErrorState,
                ISNULL(@ErrorProcedure, ''),
                @ErrorLine,
                @ErrorMessage
            )
        END
        
    --Raise an error message with information on the error
    IF @Rethrow = 1
    BEGIN
        RAISERROR ('%s Error: %d, Severity: %d, State: %d, in Procedure %s at line %d', 16, 1, @ErrorMessage, @ErrorNumber, @ErrorSeverity, @ErrorState, @ErrorProcedure, @ErrorLine)
    END

GO



CREATE PROCEDURE [dbo].[spGetAllMovieDetails]

AS

BEGIN
	BEGIN TRY
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
	END TRY
    BEGIN CATCH
		EXEC spErrorHandler
		RETURN -1
    END CATCH
END


GO



CREATE PROCEDURE [dbo].[spRegisterUserAccount]
(
	@UserName NVARCHAR(MAX),
	@EncryptedPassword NVARCHAR(MAX),
	@FirstName VARCHAR(128),
	@LastName VARCHAR(128),
	@ContactNumber NUMERIC(10,0),
	@EmailAddress NVARCHAR(255),
	@IsUserAdmin BIT ,
	@ImageSize INT = NULL,
	@ImageData VARBINARY(MAX) = NULL,
	@ReturnStatusCode INT OUTPUT
)
AS

BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM UserAccount WHERE LOWER(UserName) = LOWER(@UserName))
		BEGIN
			SET @ReturnStatusCode = 1001;
			RETURN;
		END
		ELSE IF EXISTS (SELECT 1 FROM UserAccount WHERE LOWER(EmailAddress) = LOWER(@EmailAddress))
		BEGIN
			SET @ReturnStatusCode = 1002;
			RETURN;
		END
		ELSE IF EXISTS (SELECT 1 FROM UserAccount WHERE ContactNumber = @ContactNumber)
		BEGIN
			SET @ReturnStatusCode = 1003;
			RETURN;
		END
		ELSE
		BEGIN
			INSERT INTO UserAccount (UserName,EncryptedPassword,FirstName,LastName,ContactNumber,EmailAddress,IsUserAdmin,ImageData,ImageSize) 
			VALUES(@UserName,@EncryptedPassword,@FirstName,@LastName,@ContactNumber,@EmailAddress,@IsUserAdmin,@ImageSize,@ImageData);
			SET @ReturnStatusCode = 1000;
			RETURN;
		END
	END TRY
    BEGIN CATCH
		EXEC spErrorHandler
		RETURN -1
    END CATCH
END

GO


CREATE PROCEDURE [dbo].[spGetAllUserAccountDetails]

AS

BEGIN
	BEGIN TRY
		SELECT
			UserAccount.UserID,
			UserAccount.UserName,
			UserAccount.EncryptedPassword,
			UserAccount.FirstName,
			UserAccount.LastName,
			UserAccount.ContactNumber,
			UserAccount.EmailAddress,
			UserAccount.IsUserAdmin,
			UserAccount.ImageSize,
			UserAccount.ImageData
		 FROM 
			UserAccount;
	END TRY
    BEGIN CATCH
		EXEC spErrorHandler
		RETURN -1
    END CATCH
END


GO



CREATE PROCEDURE [dbo].[spUserAccountAuthenication]
(
	@UserName NVARCHAR(MAX),
	@EncryptedPassword NVARCHAR(MAX),
	@IsUserAdmin BIT OUTPUT,
	@ReturnStatusCode INT OUTPUT
)
AS

BEGIN
	BEGIN TRY
		SELECT
			@IsUserAdmin = IsUserAdmin
		FROM
			UserAccount
		WHERE
			UserName = @UserName AND
			EncryptedPassword = @EncryptedPassword;
		
		IF @@ROWCOUNT > 0
		BEGIN
			SET @ReturnStatusCode = 1000;
			RETURN;
		END
		ELSE
		BEGIN
			SET @ReturnStatusCode = 0;
			RETURN;
		END
	END TRY
    BEGIN CATCH
		EXEC spErrorHandler
		RETURN -1
    END CATCH
END

GO
