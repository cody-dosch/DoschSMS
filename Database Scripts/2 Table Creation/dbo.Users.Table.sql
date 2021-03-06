USE [StudentManagementSystemDB]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/27/2020 7:26:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](32) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[PasswordSalt] [varchar](max) NOT NULL,
	[Role] [varchar](32) NOT NULL,
	[FirstName] [varchar](64) NULL,
	[LastName] [varchar](64) NULL,
	[Address] [varchar](64) NULL,
	[City] [varchar](64) NULL,
	[State] [varchar](32) NULL,
	[ZipCode] [varchar](32) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC,
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([IdUser], [Username], [Password], [PasswordSalt], [Role], [FirstName], [LastName], [Address], [City], [State], [ZipCode]) VALUES (1, N'admin', N'FRRT6HxZpPKg4XuuKt/FZCffG0mUfPVAdF+8ts0Wz3/t+T8a4a1+0eBIwbl6IwyY4rn36JNPw+WyM6qsuNr0yw==', N'6wcgnqk/npFXUkLLAJVDzd55PD6xz88YL6GKKoySVYg=', N'admin', N'Test', N'Admin', N'2300 Adams Ave Updated', N'Scranton', N'PA', N'18509')
INSERT [dbo].[Users] ([IdUser], [Username], [Password], [PasswordSalt], [Role], [FirstName], [LastName], [Address], [City], [State], [ZipCode]) VALUES (2, N'dddewald', N'uUwwJ4QogqTyXZX9SZytktZa1J7J6tK93+bGJOrMemUo2DGgIxnZc+J4ZnpH8m5mrIXqFvf8VstDd9xvh+wkeA==', N'5xhvQ8n+j5dR40MtCcciDzejBG8gjX8k3rwWeDmAYAc=', N'student', N'Drake', N'Dewald', N'2300 Adams Ave', N'Scranton', N'PA', N'18509')
INSERT [dbo].[Users] ([IdUser], [Username], [Password], [PasswordSalt], [Role], [FirstName], [LastName], [Address], [City], [State], [ZipCode]) VALUES (4, N'instructor', N'L+Qm3aPe1SI8H8WCMd6rybuq4ouEba8FcobJxh/NtXRdGcYCI6oDnZmMhm0ZuAmhjCiUrQ2NDMVBuGxIIL5TaA==', N'dBOFBlCCxNi1hOmslTp242B0rNd0UKh6b0RbOnVbVEM=', N'instructor', N'Test', N'Instructor', N'2300 Adams Ave', N'Scranton', N'PA', N'18509')
INSERT [dbo].[Users] ([IdUser], [Username], [Password], [PasswordSalt], [Role], [FirstName], [LastName], [Address], [City], [State], [ZipCode]) VALUES (5, N'cdosch', N'fUcaW2KHThXuKdY+v2nUHt+JCam+EAJR0sFYafDkEmV4IuI0ID9tJFRfrNNRVJeuuF/JLugdYpaqbHc6q3mOhw==', N'7giTifN6g9i9PvA+RVbLlgLAV/ykx87ZVDYIWWfvQxg=', N'student', N'Cody', N'Dosch', N'130 Wintergreen Cir', N'Greentown', N'PA', N'18426')
INSERT [dbo].[Users] ([IdUser], [Username], [Password], [PasswordSalt], [Role], [FirstName], [LastName], [Address], [City], [State], [ZipCode]) VALUES (6, N'student', N's24vKgpzW2fGs29ZHslRzmN2EiqVH5gCeM3ccqzJL7c+MNlU/UEpaFnUvG1LfS4Bk202GkX6kQdOABS7dxvlnA==', N'FVyZ/cg/adymNcoa4qXOwOyTmQvEWnDa/hTSEP6Kh0k=', N'student', N'Test', N'Student', N'2300 Adams Ave', N'Scranton', N'PA', N'18509')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[Roles] ([Value])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
