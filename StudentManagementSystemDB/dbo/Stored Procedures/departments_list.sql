-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/3/2020
-- Description:	Lists all Departments
-- =============================================
CREATE PROCEDURE [dbo].[departments_list] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Departments
END