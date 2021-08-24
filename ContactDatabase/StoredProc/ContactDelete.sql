CREATE PROCEDURE [dbo].[ContactDelete]
	@Id INT
AS
	BEGIN
		DELETE FROM Contact WHERE Id = @Id
	END