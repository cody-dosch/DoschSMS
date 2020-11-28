
-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/17/2020
-- Description:	Update an instructor course association by IdCourse
-- =============================================
CREATE PROCEDURE [dbo].[instructorcourseassoc_update]
	@IdCourse		INT,
	@IdInstructor	INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE InstructorCourseAssoc
	SET		
		[IdInstructor] = COALESCE(@IdInstructor, [IdInstructor])
	WHERE 
		IdCourse = @IdCourse

	SELECT *
	FROM InstructorCourseAssoc
	WHERE IdCourse = @IdCourse
		
END