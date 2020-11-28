
-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/22/2020
-- Description:	Update a course by IdCourse
-- =============================================
CREATE PROCEDURE [dbo].[courses_update]
	@IdCourse					INT,
	@CourseName					VARCHAR(64),
	@CourseDescription			VARCHAR(512) = NULL,
	@CourseInstructorId			INT = NULL,
	@CourseInstructorUsername	VARCHAR(32) = NULL,
	@Semester					VARCHAR(16),
	@SeatsOpen					INT,
	@SeatsMax					INT,
	@StartTime					DATETIME = NULL,
	@EndTime					DATETIME = NULL,
	@DayOfWeek					VARCHAR(9) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Courses
	SET
		[CourseName] = COALESCE(@CourseName, [CourseName]),
		[CourseDescription] = COALESCE(@CourseDescription, [CourseDescription]),
		[CourseInstructorId] = @CourseInstructorId,
		[CourseInstructorUsername] = @CourseInstructorUsername,
		[Semester] = COALESCE(@Semester, [Semester]),
		[SeatsOpen] = COALESCE(@SeatsOpen, [SeatsOpen]),
		[SeatsMax] = COALESCE(@SeatsMax, [SeatsMax]),
		[StartTime] = COALESCE(@StartTime, [StartTime]),
		[EndTime] = COALESCE(@EndTime, [EndTime]),
		[DayOfWeek] = COALESCE(@DayOfWeek, [DayOfWeek])
	WHERE 
		IdCourse = @IdCourse

	SELECT *
	FROM Courses
	WHERE IdCourse = @IdCourse
		
END