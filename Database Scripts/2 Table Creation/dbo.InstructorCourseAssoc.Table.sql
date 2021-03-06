USE [StudentManagementSystemDB]
GO
/****** Object:  Table [dbo].[InstructorCourseAssoc]    Script Date: 11/27/2020 7:26:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstructorCourseAssoc](
	[IdCourse] [int] NOT NULL,
	[IdInstructor] [int] NOT NULL,
 CONSTRAINT [PK_InstructorCourseAssoc] PRIMARY KEY CLUSTERED 
(
	[IdCourse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[InstructorCourseAssoc] ([IdCourse], [IdInstructor]) VALUES (1, 4)
INSERT [dbo].[InstructorCourseAssoc] ([IdCourse], [IdInstructor]) VALUES (2, 4)
INSERT [dbo].[InstructorCourseAssoc] ([IdCourse], [IdInstructor]) VALUES (1007, 4)
INSERT [dbo].[InstructorCourseAssoc] ([IdCourse], [IdInstructor]) VALUES (1008, 0)
GO
ALTER TABLE [dbo].[InstructorCourseAssoc]  WITH CHECK ADD  CONSTRAINT [FK_InstructorCourseAssoc_IdCourse] FOREIGN KEY([IdCourse])
REFERENCES [dbo].[InstructorCourseAssoc] ([IdCourse])
GO
ALTER TABLE [dbo].[InstructorCourseAssoc] CHECK CONSTRAINT [FK_InstructorCourseAssoc_IdCourse]
GO
