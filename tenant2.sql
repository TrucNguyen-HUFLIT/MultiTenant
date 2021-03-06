USE [tenant2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/5/2021 12:28:40 PM ******/
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 7/5/2021 12:28:41 PM ******/
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

INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (1, N'Marna Paulitschke', N'25', N'mpaulitschke0@usa.gov')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (2, N'Matty Gave', N'24', N'mgave1@macromedia.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (3, N'Carie Baudry', N'16', N'cbaudry2@histats.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (4, N'Damaris Greggor', N'19', N'dgreggor3@list-manage.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (5, N'Corrina Jedrzejewsky', N'23', N'cjedrzejewsky4@prweb.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (6, N'Sylas Denniston', N'30', N'sdenniston5@sciencedaily.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (7, N'Adda Iacovacci', N'27', N'aiacovacci6@ow.ly')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (8, N'Rod Gotts', N'28', N'rgotts7@eepurl.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (9, N'Clerissa Alu', N'26', N'calu8@wisc.edu')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (10, N'Oswald Colliard', N'16', N'ocolliard9@slideshare.net')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (11, N'Tatiania Rosewell', N'25', N'trosewella@businesswire.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (12, N'Had Velez', N'17', N'hvelezb@icio.us')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (13, N'Leroi Barrat', N'21', N'lbarratc@paypal.com')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (14, N'Maxim Ruperto', N'24', N'mrupertod@dmoz.org')
INSERT [dbo].[Accounts] ([IdAcc], [Name], [Age], [Email]) VALUES (15, N'Rica Glas', N'19', N'rglase@rambler.ru')
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
