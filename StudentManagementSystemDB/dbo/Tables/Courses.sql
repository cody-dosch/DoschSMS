CREATE TABLE [dbo].[Courses] (
    [IdCourse]                 INT           IDENTITY (1, 1) NOT NULL,
    [Department]               VARCHAR (32)  NOT NULL,
    [CourseNumber]             INT           NOT NULL,
    [CourseName]               VARCHAR (64)  NOT NULL,
    [CourseDescription]        VARCHAR (512) NULL,
    [CourseInstructorId]       INT           NULL,
    [CourseInstructorUsername] VARCHAR (32)  NULL,
    [Semester]                 VARCHAR (32)  NOT NULL,
    [SeatsOpen]                INT           NOT NULL,
    [SeatsMax]                 INT           NOT NULL,
    [StartTime]                DATETIME      NULL,
    [EndTime]                  DATETIME      NULL,
    [DayOfWeek]                VARCHAR (9)   NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED ([IdCourse] ASC, [Department] ASC, [CourseNumber] ASC),
    CONSTRAINT [FK_Courses_CourseInstructorId] FOREIGN KEY ([CourseInstructorId], [CourseInstructorUsername]) REFERENCES [dbo].[Users] ([IdUser], [Username]),
    CONSTRAINT [FK_Courses_DayOfWeek] FOREIGN KEY ([DayOfWeek]) REFERENCES [dbo].[DaysOfWeek] ([Day]),
    CONSTRAINT [FK_Courses_Department] FOREIGN KEY ([Department]) REFERENCES [dbo].[Departments] ([DepartmentValue]),
    CONSTRAINT [FK_Courses_Semester] FOREIGN KEY ([Semester]) REFERENCES [dbo].[Semesters] ([SemesterValue])
);









