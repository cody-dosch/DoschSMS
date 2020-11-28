CREATE TABLE [dbo].[Departments] (
    [IdDepartment]   INT          IDENTITY (1, 1) NOT NULL,
    [DepartmentName] VARCHAR (64) NOT NULL,
    [DepartmentValue] VARCHAR(32) NOT NULL, 
    CONSTRAINT [PK_Departments] PRIMARY KEY ([DepartmentValue]) 
);

