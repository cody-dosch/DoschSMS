USE [StudentManagementSystemDB]
GO
/****** Object:  StoredProcedure [dbo].[courses_insert]    Script Date: 11/27/2020 7:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/3/2020
-- Description:	Insert a new course.
-- =============================================
CREATE PROCEDURE [dbo].[courses_insert]
	@Department					VARCHAR(64),
	@CourseNumber				VARCHAR(16),
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

    -- Insert statements for procedure here
	INSERT INTO Courses(Department, CourseNumber, CourseName, CourseDescription, CourseInstructorId, CourseInstructorUsername, Semester, SeatsOpen, SeatsMax, StartTime, EndTime, [DayOfWeek])
	VALUES (@Department, @CourseNumber, @CourseName, @CourseDescription, @CourseInstructorId, @CourseInstructorUsername, @Semester, @SeatsOpen, @SeatsMax, @StartTime, @EndTime, @DayOfWeek)

	SELECT *
	FROM Courses
	WHERE IdCourse = SCOPE_IDENTITY()
END
GO
