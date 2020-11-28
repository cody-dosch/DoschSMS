CREATE TABLE [dbo].[Semesters] (
    [IdSemester]    INT          IDENTITY (1, 1) NOT NULL,
    [SemesterName]  VARCHAR (64) NOT NULL,
    [SemesterValue] VARCHAR (32) NOT NULL,
    CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED ([SemesterValue] ASC)
);

