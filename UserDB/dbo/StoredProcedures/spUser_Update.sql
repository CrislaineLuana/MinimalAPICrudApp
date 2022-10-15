CREATE PROCEDURE [dbo].[spUser_Update]
	@id int,
	@FirstName varchar(50),
	@LastName varchar(50)
AS
BEGIN

	UPDATE dbo.[User]
	SET FirstName = @FirstName, LastName = @LastName
	WHERE Id = @Id

END

