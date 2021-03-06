USE [Tenant]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/5/2021 12:29:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 7/5/2021 12:29:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[IdAcc] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Age] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[IdAcc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (1, N'Sianna Kelson', N'15', N'skelson0@ameblo.jp')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (2, N'Baudoin Cota', N'16', N'bcota1@artisteer.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (3, N'Lu Stansfield', N'25', N'lstansfield2@economist.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (4, N'Elita Peek', N'24', N'epeek3@yale.edu')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (5, N'Brianne Vedeshkin', N'19', N'bvedeshkin4@meetup.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (6, N'Arley Fiddian', N'20', N'afiddian5@loc.gov')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (7, N'Jeanette Jeram', N'21', N'jjeram6@moonfruit.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (8, N'Frasquito Goodnow', N'22', N'fgoodnow7@ifeng.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (9, N'Cassius Lodin', N'23', N'clodin8@trellian.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (10, N'Marcille Batten', N'17', N'mbatten9@soup.io')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (11, N'Ashlen Rex', N'19', N'arexa@a8.net')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (12, N'Isa Stansell', N'22', N'istansellb@census.gov')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (13, N'Parke Dicky', N'18', N'pdickyc@yellowbook.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (14, N'Markus Jagger', N'19', N'mjaggerd@statcounter.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (15, N'Teresita Node', N'23', N'tnodee@wisc.edu')
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
