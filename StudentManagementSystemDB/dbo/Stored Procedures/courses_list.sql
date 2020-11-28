
-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/8/2020
-- Description:	Returns a list of all courses
-- =============================================
CREATE PROCEDURE [dbo].[courses_list]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT *
	FROM Courses
	ORDER BY Department, CourseNumber ASC
END