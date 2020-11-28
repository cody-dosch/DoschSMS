

-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/17/2020
-- Description:	Delete an student course association by IdCourse and IdStudent.
-- =============================================
CREATE PROCEDURE [dbo].[studentcourseassoc_delete]
	@IdCourse INT,
	@IdStudent INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM StudentCourseAssoc
	WHERE IdCourse = @IdCourse AND IdStudent = @IdStudent
END