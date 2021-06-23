USE [MultiTenant]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23/06/2021 10:51:21 AM ******/
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 23/06/2021 10:51:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[Role] [int] NOT NULL,
	[TenantId] [int] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenants]    Script Date: 23/06/2021 10:51:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenants](
	[TenantId] [int] IDENTITY(1,1) NOT NULL,
	[SubDomain] [nvarchar](max) NULL,
	[DataConnectionString] [nvarchar](max) NULL,
	[TenantName] [nvarchar](max) NULL,
	[Favicon] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tenants] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210622192811_CreateSchoolDB', N'5.0.7')
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccId], [Email], [Name], [UserName], [Password], [Avatar], [Role], [TenantId]) VALUES (2, N'giahuyngh16@gmail.com', N'Huy Nguyen', N'huy', N'AQAAAAEAACcQAAAAECbhYVxT6AhZQ0rXUBRqKQ9/qaEPyjEJdN/l8x7Fo7KUHnovu+Ee+iUvXutIZ63SHQ==', N'/img/vinfast.png', 1, 1)
INSERT [dbo].[Accounts] ([AccId], [Email], [Name], [UserName], [Password], [Avatar], [Role], [TenantId]) VALUES (12, N'ngoctruc020100@gmail.com', N'Ngoc Truc', N'truc', N'AQAAAAEAACcQAAAAECbhYVxT6AhZQ0rXUBRqKQ9/qaEPyjEJdN/l8x7Fo7KUHnovu+Ee+iUvXutIZ63SHQ==', N'/img/vinfast.png', 2, 1)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Tenants] ON 

INSERT [dbo].[Tenants] ([TenantId], [SubDomain], [DataConnectionString], [TenantName], [Favicon]) VALUES (1, N'https://tenant1.localhost:5002	', NULL, N'Tenant1', NULL)
INSERT [dbo].[Tenants] ([TenantId], [SubDomain], [DataConnectionString], [TenantName], [Favicon]) VALUES (2, N'https://tenant2.localhost:5002', NULL, N'Tenant2', NULL)
SET IDENTITY_INSERT [dbo].[Tenants] OFF
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Tenants_TenantId] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenants] ([TenantId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Tenants_TenantId]
GO
