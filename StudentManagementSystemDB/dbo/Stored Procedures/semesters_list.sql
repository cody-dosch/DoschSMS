
-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/6/2020
-- Description:	Lists all Semesters
-- =============================================
CREATE PROCEDURE [dbo].[semesters_list] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Semesters
END