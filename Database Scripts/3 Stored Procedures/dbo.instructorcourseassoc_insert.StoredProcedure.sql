USE [StudentManagementSystemDB]
GO
/****** Object:  StoredProcedure [dbo].[instructorcourseassoc_insert]    Script Date: 11/27/2020 7:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/17/2020
-- Description:	Insert a new instructor course association.
-- =============================================
CREATE PROCEDURE [dbo].[instructorcourseassoc_insert]
	@IdCourse					INT,
	@IdInstructor				INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO InstructorCourseAssoc(IdCourse, IdInstructor)
	VALUES (@IdCourse, @IdInstructor)

	SELECT *
	FROM InstructorCourseAssoc
	WHERE IdCourse = @IdCourse
END
GO
