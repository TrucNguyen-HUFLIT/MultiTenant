USE [MultiTenant]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19/07/2021 1:21:07 PM ******/
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 19/07/2021 1:21:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Avatar] [nvarchar](max) NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountTenants]    Script Date: 19/07/2021 1:21:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountTenants](
	[AccId] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
 CONSTRAINT [PK_AccountTenants] PRIMARY KEY CLUSTERED 
(
	[AccId] ASC,
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenants]    Script Date: 19/07/2021 1:21:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenants](
	[TenantId] [int] IDENTITY(1,1) NOT NULL,
	[URL] [nvarchar](max) NULL,
	[DbName] [nvarchar](max) NULL,
	[Favicon] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tenants] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210710082123_CreateMultiTenantDB1', N'5.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210712155755_CreateMultiTenantDB2', N'5.0.7')
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccId], [Email], [Name], [UserName], [Avatar], [Role]) VALUES (1, N'minhtam@gmail.com', N'Minh Tam', N'tam', N'/img/abc.png', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Name], [UserName], [Avatar], [Role]) VALUES (2, N'minhnhut@gmail.com', N'Minh Nhut', N'nhut', N'/img/abc.png', 2)
INSERT [dbo].[Accounts] ([AccId], [Email], [Name], [UserName], [Avatar], [Role]) VALUES (3, N'quockha@gmail.com', N'Quoc Kha', N'kha', N'/img/abc.png', 2)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
INSERT [dbo].[AccountTenants] ([AccId], [TenantId]) VALUES (1, 1)
INSERT [dbo].[AccountTenants] ([AccId], [TenantId]) VALUES (1, 3)
INSERT [dbo].[AccountTenants] ([AccId], [TenantId]) VALUES (2, 1)
INSERT [dbo].[AccountTenants] ([AccId], [TenantId]) VALUES (2, 2)
INSERT [dbo].[AccountTenants] ([AccId], [TenantId]) VALUES (3, 2)
GO
SET IDENTITY_INSERT [dbo].[Tenants] ON 

INSERT [dbo].[Tenants] ([TenantId], [URL], [DbName], [Favicon]) VALUES (1, N'https://tenant1.multitenant.com', N'tenant1', N'/img/abc.png')
INSERT [dbo].[Tenants] ([TenantId], [URL], [DbName], [Favicon]) VALUES (2, N'https://tenant2.multitenant.com', N'tenant2', N'/img/android-robot-head.png')
INSERT [dbo].[Tenants] ([TenantId], [URL], [DbName], [Favicon]) VALUES (3, N'https://tenant..multitenant.com', N'tenant', N'/img/favicon-robo.jpg')
SET IDENTITY_INSERT [dbo].[Tenants] OFF
GO
ALTER TABLE [dbo].[AccountTenants]  WITH CHECK ADD  CONSTRAINT [FK_AccountTenants_Accounts_AccId] FOREIGN KEY([AccId])
REFERENCES [dbo].[Accounts] ([AccId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AccountTenants] CHECK CONSTRAINT [FK_AccountTenants_Accounts_AccId]
GO
ALTER TABLE [dbo].[AccountTenants]  WITH CHECK ADD  CONSTRAINT [FK_AccountTenants_Tenants_TenantId] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenants] ([TenantId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AccountTenants] CHECK CONSTRAINT [FK_AccountTenants_Tenants_TenantId]
GO
