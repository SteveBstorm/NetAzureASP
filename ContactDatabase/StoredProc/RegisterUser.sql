CREATE PROCEDURE [dbo].[RegisterUser]
	@Email VARCHAR(50),
	@Password VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	--Creation du salt
	DECLARE @salt VARCHAR(100)
	SET @salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @secret VARCHAR(100)
	SET @secret = dbo.GetSecretKey()

	DECLARE @hash_password VARBINARY(64)
	SET @hash_password = HASHBYTES('SHA2_512', CONCAT(@salt, @Password, @secret, @salt))

	INSERT INTO [Users] (Email, [Password], Salt) VALUES (@Email, @hash_password, @salt)
END
