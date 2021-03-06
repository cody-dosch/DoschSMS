USE [StudentManagementSystemDB]
GO
/****** Object:  StoredProcedure [dbo].[departments_list]    Script Date: 11/27/2020 7:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/3/2020
-- Description:	Lists all Departments
-- =============================================
CREATE PROCEDURE [dbo].[departments_list] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Departments
END
GO
