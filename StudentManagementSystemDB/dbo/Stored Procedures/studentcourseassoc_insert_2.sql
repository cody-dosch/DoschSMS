

-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/27/2020
-- Description:	Insert a new student course association.
-- =============================================
CREATE PROCEDURE [dbo].[studentcourseassoc_insert]
	@IdCourse					INT,
	@IdStudent					INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO StudentCourseAssoc(IdCourse, IdStudent)
	VALUES (@IdCourse, @IdStudent)

	SELECT *
	FROM StudentCourseAssoc
	WHERE IdCourse = @IdCourse AND IdStudent = @IdStudent
END