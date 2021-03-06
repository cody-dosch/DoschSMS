USE [StudentManagementSystemDB]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/27/2020 7:26:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[Key] [varchar](32) NOT NULL,
	[Value] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([IdRole], [Key], [Value]) VALUES (3, N'Admin', N'admin')
INSERT [dbo].[Roles] ([IdRole], [Key], [Value]) VALUES (2, N'Instructor', N'instructor')
INSERT [dbo].[Roles] ([IdRole], [Key], [Value]) VALUES (1, N'Student', N'student')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
