USE [StudentManagementSystemDB]
GO
/****** Object:  StoredProcedure [dbo].[courses_get]    Script Date: 11/27/2020 7:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cody Dosch
-- Create date: 9/12/2020
-- Description:	Get a specific course by IdCourse
-- =============================================
CREATE PROCEDURE [dbo].[courses_get]
	@IdCourse		INT = NULL,
	@Department		VARCHAR(32) = NULL,
	@CourseNumber	INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Courses
	WHERE
	(
		@IdCourse IS NULL
		OR IdCourse = @IdCourse
	)
	AND
	(
		@Department IS NULL
		OR Department = @Department
	)
	AND
	(
		@CourseNumber IS NULL
		OR CourseNumber = @CourseNumber
	)
		 
END
GO
