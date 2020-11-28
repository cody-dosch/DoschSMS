CREATE TABLE [dbo].[Roles] (
    [IdRole] INT          IDENTITY (1, 1) NOT NULL,
    [Key]    VARCHAR (32) NOT NULL,
    [Value]  VARCHAR (32) NOT NULL, 
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Value])
);

