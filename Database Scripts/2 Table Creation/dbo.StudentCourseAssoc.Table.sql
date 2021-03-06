USE [StudentManagementSystemDB]
GO
/****** Object:  Table [dbo].[StudentCourseAssoc]    Script Date: 11/27/2020 7:26:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourseAssoc](
	[IdCourse] [int] NOT NULL,
	[IdStudent] [int] NOT NULL,
 CONSTRAINT [PK_StudentCourseAssoc] PRIMARY KEY CLUSTERED 
(
	[IdCourse] ASC,
	[IdStudent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[StudentCourseAssoc] ([IdCourse], [IdStudent]) VALUES (1, 5)
INSERT [dbo].[StudentCourseAssoc] ([IdCourse], [IdStudent]) VALUES (2, 5)
INSERT [dbo].[StudentCourseAssoc] ([IdCourse], [IdStudent]) VALUES (3, 6)
INSERT [dbo].[StudentCourseAssoc] ([IdCourse], [IdStudent]) VALUES (1004, 6)
INSERT [dbo].[StudentCourseAssoc] ([IdCourse], [IdStudent]) VALUES (1007, 5)
GO
ALTER TABLE [dbo].[StudentCourseAssoc]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourseAssoc_StudentCourseAssoc] FOREIGN KEY([IdCourse], [IdStudent])
REFERENCES [dbo].[StudentCourseAssoc] ([IdCourse], [IdStudent])
GO
ALTER TABLE [dbo].[StudentCourseAssoc] CHECK CONSTRAINT [FK_StudentCourseAssoc_StudentCourseAssoc]
GO
