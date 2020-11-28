-- =============================================
-- Author:		Cody Dosch
-- Create date: 9/12/2020
-- Description:	Get a specific user by IdUser
-- =============================================
CREATE PROCEDURE [dbo].[users_get]
	@IdUser		INT = NULL,
	@Username	VARCHAR(32) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Users
	WHERE 
	(
		@IdUser IS NULL
		OR IdUser = @IdUser
	)
	AND
	(
		@Username IS NULL
		OR Username = @Username
	)
END