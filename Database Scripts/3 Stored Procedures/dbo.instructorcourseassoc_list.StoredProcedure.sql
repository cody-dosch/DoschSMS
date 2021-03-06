USE [StudentManagementSystemDB]
GO
/****** Object:  StoredProcedure [dbo].[instructorcourseassoc_list]    Script Date: 11/27/2020 7:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/17/2020
-- Description:	Lists all instructor course associations.
-- =============================================
CREATE PROCEDURE [dbo].[instructorcourseassoc_list] 
(
	@IdCourse		INT = NULL,
	@IdInstructor	INT = NULL
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM InstructorCourseAssoc
	WHERE 
	(
		@IdInstructor IS NULL
		OR IdInstructor = @IdInstructor
	)
	AND
	(
		@IdCourse IS NULL
		OR IdCourse = @IdCourse
	)
END
GO
