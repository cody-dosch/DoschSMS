-- =============================================
-- Author:		Cody Dosch
-- Create date: 9/12/2020
-- Description:	Returns a list of all users
-- =============================================
CREATE PROCEDURE [dbo].[users_list]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT *
	FROM Users
END