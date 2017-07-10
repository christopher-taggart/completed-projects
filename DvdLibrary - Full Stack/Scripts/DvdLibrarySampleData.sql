USE DvdLibrary
GO

DELETE FROM Dvds;
DELETE FROM Ratings;

DBCC CHECKIDENT ('dvds', RESEED, 1)

INSERT INTO Ratings(RatingId)
VALUES ('G'),
('PG'),
('PG-13'),
('R')

GO

SET IDENTITY_INSERT Dvds ON;
GO
INSERT INTO Dvds(DvdId, RatingId, Title, Director, ReleaseYear, Notes)
VALUES (1, 'G', 'Test', 'Test Director', '1995', 'Great Movie'),
(2, 'G', 'Test Movie 2', 'Another Director', '2001', 'Decent Movie'),
(3, 'PG-13', 'Test Three', 'Test Director 3', '2017', 'Note'),
(4, 'PG', 'Test 4', 'TDirector', '2012', 'More notes'),
(5, 'R', 'Last Test', 'Guy', '2001', 'Blank')
SET IDENTITY_INSERT Dvds OFF;
GO
