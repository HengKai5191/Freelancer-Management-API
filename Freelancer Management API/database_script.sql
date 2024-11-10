USE [FreeLancer]
GO
/****** Object:  Table [dbo].[FreeLancers]    Script Date: 11/10/2024 11:05:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FreeLancers](
	[FL_ID] [int] IDENTITY(1,1) NOT NULL,
	[FL_Username] [nvarchar](60) NULL,
	[FL_Email] [nvarchar](100) NULL,
	[FL_PhoneNumber] [nvarchar](50) NULL,
	[FL_Skillsets] [nvarchar](max) NULL,
	[FL_Hobbies] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FreeLancers] ON 

INSERT [dbo].[FreeLancers] ([FL_ID], [FL_Username], [FL_Email], [FL_PhoneNumber], [FL_Skillsets], [FL_Hobbies]) VALUES (1, N'limhengkaitest', N'limhengkaitest@gmail.com', N'01110210018', N'C#,sql,java,python,newskill', N'watchingf1,soccer footbal,swimming')
INSERT [dbo].[FreeLancers] ([FL_ID], [FL_Username], [FL_Email], [FL_PhoneNumber], [FL_Skillsets], [FL_Hobbies]) VALUES (7, N'TEST', N'TEST@GMAIL.COM', N'123', N'123', N'123')
INSERT [dbo].[FreeLancers] ([FL_ID], [FL_Username], [FL_Email], [FL_PhoneNumber], [FL_Skillsets], [FL_Hobbies]) VALUES (5, N'test', N'test@gmail.com', N'123', N'123', N'')
SET IDENTITY_INSERT [dbo].[FreeLancers] OFF
GO
