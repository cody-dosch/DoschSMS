-- =============================================
-- Author:		Cody Dosch
-- Create date: 9/12/2020
-- Description:	Insert a new user.
-- =============================================
CREATE PROCEDURE [dbo].[users_insert]
	@Username		VARCHAR(32),
	@Password		VARCHAR(MAX),
	@PasswordSalt	VARCHAR(MAX),
	@Role			VARCHAR(32),
	@FirstName		VARCHAR(64) = NULL,
	@LastName		VARCHAR(64) = NULL,
	@Address		VARCHAR(64) = NULL,
	@City			VARCHAR(64) = NULL,
	@State			VARCHAR(32) = NULL,
	@ZipCode		VARCHAR(32) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Users(Username, [Password], PasswordSalt, [Role], [FirstName], [LastName], [Address], [City], [State], [ZipCode])
	VALUES (@Username, @Password, @PasswordSalt, @Role, @FirstName, @LastName, @Address, @City, @State, @ZipCode)

	SELECT *
	FROM Users
	WHERE IdUser = SCOPE_IDENTITY()
END