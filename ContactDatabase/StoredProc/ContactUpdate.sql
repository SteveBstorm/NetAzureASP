CREATE PROCEDURE [dbo].[ContactUpdate]
	@LastName VARCHAR(50),
	@FirstName VARCHAR(50),
	@Email VARCHAR(100),
	@IsFavorite BIT,
	@Id INT
AS
	BEGIN
		UPDATE Contact SET LastName = @LastName, FirstName = @FirstName, Email = @Email, IsFavorite = @IsFavorite
		WHERE Id = @Id
	END