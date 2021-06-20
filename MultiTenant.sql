USE [MultiTenant]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17/06/2021 4:04:11 PM ******/
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 17/06/2021 4:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Avatar] [nvarchar](max) NULL,
	[TenantId] [int] NOT NULL,
	[Role] [int] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenants]    Script Date: 17/06/2021 4:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenants](
	[TenantId] [int] NOT NULL,
	[Host] [nvarchar](max) NULL,
	[DatabaseConnection] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Logo] [nvarchar](max) NULL,
	[Favicon] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tenants] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [TenantId], [Role]) VALUES (1, N'giahuyngh16@gmail.com', N'giahuy', N'Nguyen', N'Huy', N'https://robohash.org/pariaturida.png?size=50x50&set=set1', 1, 1)
INSERT [dbo].[Accounts] ([AccId], [Email], [Password], [FirstName], [LastName], [Avatar], [TenantId], [Role]) VALUES (2, N'ngoctruc@gmail.com', N'ngoctruc', N'Nguyen', N'Truc', N'https://robohash.org/estquiavel.png?size=50x50&set=set1', 2, 1)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
INSERT [dbo].[Tenants] ([TenantId], [Host], [DatabaseConnection], [Name], [Logo], [Favicon]) VALUES (1, N'https://localhost:5001', N'MultiTenant', N'Tenant', N'', N'')
INSERT [dbo].[Tenants] ([TenantId], [Host], [DatabaseConnection], [Name], [Logo], [Favicon]) VALUES (2, N'https://localhost:5002', N'MultiTenant', N'Tenant1', NULL, N'')
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Tenants_TenantId] FOREIGN KEY([TenantId])
REFERENCES [dbo].[Tenants] ([TenantId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Tenants_TenantId]
GO
