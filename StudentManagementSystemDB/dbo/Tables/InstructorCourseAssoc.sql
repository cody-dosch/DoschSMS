CREATE TABLE [dbo].[InstructorCourseAssoc] (
    [IdCourse]     INT NOT NULL,
    [IdInstructor] INT NOT NULL,
    CONSTRAINT [PK_InstructorCourseAssoc] PRIMARY KEY CLUSTERED ([IdCourse] ASC),
    CONSTRAINT [FK_InstructorCourseAssoc_IdCourse] FOREIGN KEY ([IdCourse]) REFERENCES [dbo].[InstructorCourseAssoc] ([IdCourse])
);

