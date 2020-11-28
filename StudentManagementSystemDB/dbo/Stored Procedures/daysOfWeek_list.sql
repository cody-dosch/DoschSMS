

-- =============================================
-- Author:		Cody Dosch
-- Create date: 10/14/2020
-- Description:	Lists all Days of Week.
-- =============================================
CREATE PROCEDURE [dbo].[daysOfWeek_list] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM DaysOfWeek
END