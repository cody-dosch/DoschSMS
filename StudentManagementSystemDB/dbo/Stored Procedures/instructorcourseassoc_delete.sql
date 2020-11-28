
-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/17/2020
-- Description:	Delete an instructor course association by IdCourse.
-- =============================================
CREATE PROCEDURE [dbo].[instructorcourseassoc_delete]
	@IdCourse INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM InstructorCourseAssoc
	WHERE IdCourse = @IdCourse
END