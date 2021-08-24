CREATE PROCEDURE [dbo].[ContactCreate]
	@LastName VARCHAR(50),
	@FirstName VARCHAR(50),
	@Email VARCHAR(100),
	@IsFavorite BIT
AS
BEGIN
	INSERT INTO Contact (LastName, FirstName, Email, IsFavorite) OUTPUT inserted.Id VALUES (@LastName, @FirstName, @Email, @IsFavorite)
END
