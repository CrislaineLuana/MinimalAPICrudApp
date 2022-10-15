CREATE PROCEDURE [dbo].[spUser_Get]
	@id int
AS
BEGIN	
	SELECT Id, FirstName, LastName
	FROM dbo.[User]
	WHERE Id = @id;
END
