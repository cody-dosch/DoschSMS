USE [StudentManagementSystemDB]
GO
/****** Object:  StoredProcedure [dbo].[roles_list]    Script Date: 11/27/2020 7:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cody Dosch
-- Create date: 9/19/2020
-- Description:	Gets list of roles.
-- =============================================
CREATE PROCEDURE [dbo].[roles_list]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT *
	FROM Roles
END
GO
