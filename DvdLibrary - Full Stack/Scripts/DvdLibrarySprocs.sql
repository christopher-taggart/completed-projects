USE DvdLibrary
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsSelectAll')
      DROP PROCEDURE DvdsSelectAll
GO

CREATE PROCEDURE DvdsSelectAll AS
BEGIN
	SELECT DvdId, Title, Director, RatingId, Notes, ReleaseYear
	FROM Dvds
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsSelectById')
      DROP PROCEDURE DvdsSelectById
GO

CREATE PROCEDURE DvdsSelectById (
	@DvdId int
) AS
BEGIN
	SELECT DvdId, Title, Director, RatingId, Notes, ReleaseYear
	FROM Dvds
	WHERE DvdId = @DvdId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsSelectByReleaseYear')
      DROP PROCEDURE DvdsSelectByReleaseYear
GO
CREATE PROCEDURE DvdsSelectByReleaseYear (
	@ReleaseYear varchar(4)
) AS
BEGIN
	SELECT DvdId, Title, Director, RatingId, Notes, ReleaseYear 
	FROM Dvds
	WHERE ReleaseYear = @ReleaseYear
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsSelectByTitle')
      DROP PROCEDURE DvdsSelectByTitle
GO
CREATE PROCEDURE DvdsSelectByTitle (
	@Title varchar(25)
) AS
BEGIN
	SELECT DvdId, Title, Director, RatingId, Notes, ReleaseYear 
	FROM Dvds
	WHERE Title LIKE '%'+ @Title + '%'
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsSelectByDirector')
      DROP PROCEDURE DvdsSelectByDirector
GO
CREATE PROCEDURE DvdsSelectByDirector (
	@Director varchar(50)
) AS
BEGIN
	SELECT DvdId, Title, Director, RatingId, Notes, ReleaseYear 
	FROM Dvds
	WHERE Director LIKE '%'+ @Director + '%'
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsSelectByRatingId')
      DROP PROCEDURE DvdsSelectByRatingId
GO
CREATE PROCEDURE DvdsSelectByRatingId (
	@RatingId nvarchar(5)
) AS
BEGIN
	SELECT DvdId, Title, Director, RatingId, Notes, ReleaseYear 
	FROM Dvds
	WHERE RatingId = @RatingId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsUpdate')
      DROP PROCEDURE DvdsUpdate
GO

CREATE PROCEDURE DvdsUpdate (
	@DvdId int,
	@Title varchar(25),
	@RatingId nvarchar(5),
	@Director varchar(50),
	@Notes varchar(50),
	@ReleaseYear varchar(4)
) AS
BEGIN
	UPDATE Dvds SET 
		Title = @Title, 
		RatingId = @RatingId, 
		Director = @Director, 
		Notes = @Notes, 
		ReleaseYear = @ReleaseYear
	WHERE DvdId = @DvdId
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsInsert')
      DROP PROCEDURE DvdsInsert
GO

CREATE PROCEDURE DvdsInsert (
	
	@Title varchar(25),
	@RatingId nvarchar(5),
	@Director varchar(50),
	@Notes varchar(50),
	@ReleaseYear varchar(4)
) AS
BEGIN
	INSERT INTO Dvds (Title, Director, RatingId, Notes, ReleaseYear)
	VALUES (@Title, @Director, @RatingId, @Notes, @ReleaseYear);

	
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsDelete')
      DROP PROCEDURE DvdsDelete
GO

CREATE PROCEDURE DvdsDelete (
	@DvdId int
) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Dvds WHERE DvdId = @DvdId;

	COMMIT TRANSACTION
END
GO