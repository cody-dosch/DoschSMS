USE [StudentManagementSystemDB]
GO
/****** Object:  StoredProcedure [dbo].[users_delete]    Script Date: 11/27/2020 7:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Cody Dosch
-- Create date: 9/12/2020
-- Description:	Delete a user by IdUser.
-- =============================================
CREATE PROCEDURE [dbo].[users_delete]
	@IdUser INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM Users
	WHERE IdUser = @IdUser
END
GO
