USE [StudentManagementSystemDB]
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 11/27/2020 7:26:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters](
	[IdSemester] [int] IDENTITY(1,1) NOT NULL,
	[SemesterName] [varchar](64) NOT NULL,
	[SemesterValue] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED 
(
	[SemesterValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Semesters] ON 

INSERT [dbo].[Semesters] ([IdSemester], [SemesterName], [SemesterValue]) VALUES (1, N'Fall 2020', N'Fall 2020')
INSERT [dbo].[Semesters] ([IdSemester], [SemesterName], [SemesterValue]) VALUES (2, N'Spring 2021', N'Spring 2021')
SET IDENTITY_INSERT [dbo].[Semesters] OFF
GO
