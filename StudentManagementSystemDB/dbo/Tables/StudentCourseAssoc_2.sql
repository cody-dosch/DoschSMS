CREATE TABLE [dbo].[StudentCourseAssoc] (
    [IdCourse]  INT NOT NULL,
    [IdStudent] INT NOT NULL,
    CONSTRAINT [PK_StudentCourseAssoc] PRIMARY KEY CLUSTERED ([IdCourse] ASC, [IdStudent] ASC),
    CONSTRAINT [FK_StudentCourseAssoc_StudentCourseAssoc] FOREIGN KEY ([IdCourse], [IdStudent]) REFERENCES [dbo].[StudentCourseAssoc] ([IdCourse], [IdStudent])
);

