-- =============================================
-- Author:		Cody Dosch
-- Create date: 9/12/2020
-- Description:	Update a user by IdUser
-- =============================================
CREATE PROCEDURE [dbo].[users_update]
	@IdUser			INT,
	--@Username		VARCHAR(32) = NULL,
	--@Password		VARCHAR(MAX) = NULL,
	--@PasswordSalt	VARCHAR(MAX) = NULL,	WON'T WANT TO UPDATE THESE VALUES
	--@Role			VARCHAR(32) = NULL
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

	UPDATE Users
	SET
		--[Username] = COALESCE(@Username, [Username]),
		--[Password] = COALESCE(@Password, [Password]),
		--[PasswordSalt] = COALESCE(@PasswordSalt, [PasswordSalt]),
		--[Role] = COALESCE(@Role, [Role])
		[FirstName] = COALESCE(@FirstName, [FirstName]),
		[LastName] = COALESCE(@LastName, [LastName]),
		[Address] = COALESCE(@Address, [Address]),
		[City] = COALESCE(@City, [City]),
		[State] = COALESCE(@State, [State]),
		[ZipCode] = COALESCE(@ZipCode, [ZipCode])
	WHERE 
		IdUser = @IdUser

	SELECT *
	FROM Users
	WHERE IdUser = @IdUser
		
END