USE [StudentManagementSystemDB]
GO
/****** Object:  StoredProcedure [dbo].[instructorcourseassoc_get]    Script Date: 11/27/2020 7:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/17/2020
-- Description:	Get a specific instructor course association by course id.
-- =============================================
CREATE PROCEDURE [dbo].[instructorcourseassoc_get]
	@IdCourse		INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM InstructorCourseAssoc
	WHERE IdCourse = @IdCourse
		 
END
GO
