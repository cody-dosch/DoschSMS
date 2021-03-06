USE [StudentManagementSystemDB]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 11/27/2020 7:26:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[IdDepartment] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](64) NOT NULL,
	[DepartmentValue] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([IdDepartment], [DepartmentName], [DepartmentValue]) VALUES (1, N'Computer Science', N'CS')
INSERT [dbo].[Departments] ([IdDepartment], [DepartmentName], [DepartmentValue]) VALUES (1002, N'Math', N'MATH')
INSERT [dbo].[Departments] ([IdDepartment], [DepartmentName], [DepartmentValue]) VALUES (2, N'Music', N'MUSC')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
