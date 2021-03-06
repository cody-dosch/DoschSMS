USE [StudentManagementSystemDB]
GO
/****** Object:  StoredProcedure [dbo].[studentcourseassoc_get]    Script Date: 11/27/2020 7:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/27/2020
-- Description:	Get a specific student course association by course id.
-- =============================================
CREATE PROCEDURE [dbo].[studentcourseassoc_get]
	@IdCourse		INT,
	@IdStudent		INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM StudentCourseAssoc
	WHERE IdCourse = @IdCourse AND IdStudent = @IdStudent
		 
END
GO
