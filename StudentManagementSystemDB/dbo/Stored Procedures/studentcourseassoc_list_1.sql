

-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/17/2020
-- Description:	Lists all student course associations by IdStudent or IdCourse.
-- =============================================
CREATE PROCEDURE [dbo].[studentcourseassoc_list] 
(
	@IdStudent		INT = NULL,
	@IdCourse		INT = NULL
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM StudentCourseAssoc
	WHERE 
	(
		@IdStudent IS NULL
		OR IdStudent = @IdStudent
	)
	AND
	(
		@IdCourse IS NULL
		OR IdCourse = @IdCourse
	)
END