USE [StudentManagementSystemDB]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 11/27/2020 7:26:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[IdCourse] [int] IDENTITY(1,1) NOT NULL,
	[Department] [varchar](32) NOT NULL,
	[CourseNumber] [int] NOT NULL,
	[CourseName] [varchar](64) NOT NULL,
	[CourseDescription] [varchar](512) NULL,
	[CourseInstructorId] [int] NULL,
	[CourseInstructorUsername] [varchar](32) NULL,
	[Semester] [varchar](32) NOT NULL,
	[SeatsOpen] [int] NOT NULL,
	[SeatsMax] [int] NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[DayOfWeek] [varchar](9) NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[IdCourse] ASC,
	[Department] ASC,
	[CourseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([IdCourse], [Department], [CourseNumber], [CourseName], [CourseDescription], [CourseInstructorId], [CourseInstructorUsername], [Semester], [SeatsOpen], [SeatsMax], [StartTime], [EndTime], [DayOfWeek]) VALUES (1, N'CS', 142, N'Programming in C++', N'This is an intro programming course in C++.', 4, N'instructor', N'Fall 2020', 19, 20, CAST(N'1900-01-01T10:00:00.000' AS DateTime), CAST(N'1900-01-01T11:00:00.000' AS DateTime), N'MWF')
INSERT [dbo].[Courses] ([IdCourse], [Department], [CourseNumber], [CourseName], [CourseDescription], [CourseInstructorId], [CourseInstructorUsername], [Semester], [SeatsOpen], [SeatsMax], [StartTime], [EndTime], [DayOfWeek]) VALUES (2, N'CS', 150, N'Object Oriented Programming', N'This is an intro to object-oriented programming in C++.', 4, N'instructor', N'Fall 2020', 19, 20, CAST(N'1900-01-01T11:30:00.000' AS DateTime), CAST(N'1900-01-01T13:00:00.000' AS DateTime), N'TTh')
INSERT [dbo].[Courses] ([IdCourse], [Department], [CourseNumber], [CourseName], [CourseDescription], [CourseInstructorId], [CourseInstructorUsername], [Semester], [SeatsOpen], [SeatsMax], [StartTime], [EndTime], [DayOfWeek]) VALUES (3, N'MUSC', 100, N'Aural Skills', N'An intro level music course.', NULL, NULL, N'Fall 2020', 14, 15, CAST(N'1900-01-01T09:00:00.000' AS DateTime), CAST(N'1900-01-01T10:00:00.000' AS DateTime), N'MWF')
INSERT [dbo].[Courses] ([IdCourse], [Department], [CourseNumber], [CourseName], [CourseDescription], [CourseInstructorId], [CourseInstructorUsername], [Semester], [SeatsOpen], [SeatsMax], [StartTime], [EndTime], [DayOfWeek]) VALUES (1004, N'MUSC', 112, N'Written Theory 1A', N'This is a course in written music theory.', NULL, NULL, N'Fall 2020', 29, 30, CAST(N'2020-10-14T08:30:00.000' AS DateTime), CAST(N'2020-10-14T10:00:00.000' AS DateTime), N'TTh')
INSERT [dbo].[Courses] ([IdCourse], [Department], [CourseNumber], [CourseName], [CourseDescription], [CourseInstructorId], [CourseInstructorUsername], [Semester], [SeatsOpen], [SeatsMax], [StartTime], [EndTime], [DayOfWeek]) VALUES (1007, N'CS', 242, N'Computer Architecture', N'This is an introduction course to the inner workings of computers and hardware.', 4, N'instructor', N'Spring 2021', 19, 20, CAST(N'1900-01-01T10:00:00.000' AS DateTime), CAST(N'1900-01-01T11:00:00.000' AS DateTime), N'MWF')
INSERT [dbo].[Courses] ([IdCourse], [Department], [CourseNumber], [CourseName], [CourseDescription], [CourseInstructorId], [CourseInstructorUsername], [Semester], [SeatsOpen], [SeatsMax], [StartTime], [EndTime], [DayOfWeek]) VALUES (1008, N'MATH', 420, N'Discrete Mathematics', N'This course introduces discrete mathematics concepts.', NULL, NULL, N'Fall 2020', 20, 20, CAST(N'2020-11-27T14:00:00.000' AS DateTime), CAST(N'2020-11-27T15:00:00.000' AS DateTime), N'MWF')
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_CourseInstructorId] FOREIGN KEY([CourseInstructorId], [CourseInstructorUsername])
REFERENCES [dbo].[Users] ([IdUser], [Username])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_CourseInstructorId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_DayOfWeek] FOREIGN KEY([DayOfWeek])
REFERENCES [dbo].[DaysOfWeek] ([Day])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_DayOfWeek]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Department] FOREIGN KEY([Department])
REFERENCES [dbo].[Departments] ([DepartmentValue])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Department]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Semester] FOREIGN KEY([Semester])
REFERENCES [dbo].[Semesters] ([SemesterValue])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Semester]
GO
