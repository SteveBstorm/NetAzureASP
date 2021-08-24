CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	LastName VARCHAR(50),
	FirstName VARCHAR(50),
	Email VARCHAR(100),
	IsFavorite BIT
)
