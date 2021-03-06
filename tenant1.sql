USE [tenant1]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/5/2021 12:29:39 PM ******/
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 7/5/2021 12:29:39 PM ******/
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

INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (1, N'Deerdre Bagg', N'19', N'dbagg0@boston.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (2, N'Sharline Yendall', N'30', N'syendall1@trellian.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (3, N'Gretel Honacker', N'35', N'ghonacker2@ihg.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (4, N'Nickola Wiffler', N'16', N'nwiffler3@ameblo.jp')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (5, N'Emmalynne Labes', N'25', N'elabes4@youtu.be')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (6, N'Nat Papa', N'16', N'npapa5@nymag.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (7, N'Krishnah Walding', N'18', N'kwalding6@barnesandnoble.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (8, N'Alidia Curry', N'50', N'acurry7@psu.edu')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (9, N'Wilfrid Wollers', N'34', N'wwollers8@nhs.uk')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (10, N'Jaquenette Bathersby', N'24', N'jbathersby9@upenn.edu')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (11, N'Karalynn Cantu', N'25', N'kcantua@so-net.ne.jp')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (12, N'Honoria Rootham', N'30', N'hroothamb@abc.net.au')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (13, N'Latisha Ondrak', N'19', N'londrakc@economist.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (14, N'Dino Smowton', N'23', N'dsmowtond@senate.gov')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (15, N'Erina Nineham', N'28', N'eninehame@miibeian.gov.cn')
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
