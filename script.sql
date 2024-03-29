USE [master]
GO
/****** Object:  Database [Market]    Script Date: 5.01.2024 23:54:25 ******/
CREATE DATABASE [Market]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Market', FILENAME = N'D:\Program Files\MsSQL\MSSQL14.SQLEXPRESS\MSSQL\DATA\Market.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Market_log', FILENAME = N'D:\Program Files\MsSQL\MSSQL14.SQLEXPRESS\MSSQL\DATA\Market_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Market] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Market].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Market] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Market] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Market] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Market] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Market] SET ARITHABORT OFF 
GO
ALTER DATABASE [Market] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Market] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Market] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Market] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Market] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Market] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Market] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Market] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Market] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Market] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Market] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Market] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Market] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Market] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Market] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Market] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Market] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Market] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Market] SET  MULTI_USER 
GO
ALTER DATABASE [Market] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Market] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Market] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Market] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Market] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Market] SET QUERY_STORE = OFF
GO
USE [Market]
GO
/****** Object:  Table [dbo].[LoginTbl]    Script Date: 5.01.2024 23:54:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginTbl](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[authority] [varchar](50) NOT NULL,
	[email] [varchar](50) NULL,
	[securityQuestion] [varchar](200) NULL,
	[securityAnswer] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5.01.2024 23:54:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(100,1) NOT NULL,
	[barcode] [varchar](50) NOT NULL,
	[createdDate] [datetime] NULL,
	[updateDate] [datetime] NULL,
	[name] [varchar](50) NULL,
	[stock] [int] NULL,
	[price] [int] NULL,
	[revenue] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LoginTbl] ON 

INSERT [dbo].[LoginTbl] ([id], [username], [password], [authority], [email], [securityQuestion], [securityAnswer]) VALUES (1, N'burak', N'123', N'admin', N'burak459@outlook.com', N'En sevdiğiniz renk?', N'mavi')
INSERT [dbo].[LoginTbl] ([id], [username], [password], [authority], [email], [securityQuestion], [securityAnswer]) VALUES (2, N'ahmet', N'12345', N'staff', N'kasiyer987@outlook.com', N'İlk evcil hayvanının ismi?', N'hera')
INSERT [dbo].[LoginTbl] ([id], [username], [password], [authority], [email], [securityQuestion], [securityAnswer]) VALUES (1013, N'fatma', N'333', N'staff', N'fatma@gmail.com', N'İlk öğretmeninizin ismi?', N'kenan')
INSERT [dbo].[LoginTbl] ([id], [username], [password], [authority], [email], [securityQuestion], [securityAnswer]) VALUES (1014, N'sıla', N'444', N'staff', N'sıla@hotmail.com', N'İlk evcil hayvanının ismi?', N'ışıltı')
SET IDENTITY_INSERT [dbo].[LoginTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [barcode], [createdDate], [updateDate], [name], [stock], [price], [revenue]) VALUES (100, N'2552441210', CAST(N'2023-05-18T00:00:00.000' AS DateTime), CAST(N'2023-05-18T00:00:00.000' AS DateTime), N'banana', 172, 8, 0)
INSERT [dbo].[Product] ([id], [barcode], [createdDate], [updateDate], [name], [stock], [price], [revenue]) VALUES (101, N'2552441211', CAST(N'2023-05-18T00:00:00.000' AS DateTime), CAST(N'2023-05-18T00:00:00.000' AS DateTime), N'apple', 87, 2, 0)
INSERT [dbo].[Product] ([id], [barcode], [createdDate], [updateDate], [name], [stock], [price], [revenue]) VALUES (104, N'2552441212', CAST(N'2023-05-18T00:00:00.000' AS DateTime), CAST(N'2023-05-18T00:00:00.000' AS DateTime), N'orange', 276, 6, 0)
INSERT [dbo].[Product] ([id], [barcode], [createdDate], [updateDate], [name], [stock], [price], [revenue]) VALUES (105, N'2552441213', CAST(N'2023-05-18T00:00:00.000' AS DateTime), CAST(N'2023-05-18T00:00:00.000' AS DateTime), N'broccoli', 130, 10, 0)
INSERT [dbo].[Product] ([id], [barcode], [createdDate], [updateDate], [name], [stock], [price], [revenue]) VALUES (106, N'2552441214', CAST(N'2023-05-18T00:00:00.000' AS DateTime), CAST(N'2023-05-18T00:00:00.000' AS DateTime), N'strawberry', 340, 7, 0)
INSERT [dbo].[Product] ([id], [barcode], [createdDate], [updateDate], [name], [stock], [price], [revenue]) VALUES (107, N'2552441215', CAST(N'2023-05-18T00:00:00.000' AS DateTime), CAST(N'2023-05-18T00:00:00.000' AS DateTime), N'cabbage', 82, 15, 0)
INSERT [dbo].[Product] ([id], [barcode], [createdDate], [updateDate], [name], [stock], [price], [revenue]) VALUES (108, N'2552441216', CAST(N'2023-05-18T00:00:00.000' AS DateTime), CAST(N'2023-05-19T18:00:35.710' AS DateTime), N'grape', 230, 9, 0)
INSERT [dbo].[Product] ([id], [barcode], [createdDate], [updateDate], [name], [stock], [price], [revenue]) VALUES (111, N'3423423', CAST(N'2023-05-18T21:25:03.570' AS DateTime), CAST(N'2023-05-18T21:38:31.257' AS DateTime), N'armut', 119, 31, 0)
INSERT [dbo].[Product] ([id], [barcode], [createdDate], [updateDate], [name], [stock], [price], [revenue]) VALUES (114, N'356543457', CAST(N'2023-05-19T17:36:05.007' AS DateTime), CAST(N'2023-05-19T17:59:36.843' AS DateTime), N'kiraz', 20, 3554, 0)
INSERT [dbo].[Product] ([id], [barcode], [createdDate], [updateDate], [name], [stock], [price], [revenue]) VALUES (115, N'45645657', CAST(N'2023-05-19T17:45:53.550' AS DateTime), CAST(N'2023-05-19T17:45:53.550' AS DateTime), N'ejder meyvesi', 90, 25, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [uniqueEmail]    Script Date: 5.01.2024 23:54:25 ******/
ALTER TABLE [dbo].[LoginTbl] ADD  CONSTRAINT [uniqueEmail] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [uniqueUserEmail]    Script Date: 5.01.2024 23:54:25 ******/
ALTER TABLE [dbo].[LoginTbl] ADD  CONSTRAINT [uniqueUserEmail] UNIQUE NONCLUSTERED 
(
	[username] ASC,
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [uniqueUsername]    Script Date: 5.01.2024 23:54:25 ******/
ALTER TABLE [dbo].[LoginTbl] ADD  CONSTRAINT [uniqueUsername] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Product__C16E36F8C371BE16]    Script Date: 5.01.2024 23:54:25 ******/
ALTER TABLE [dbo].[Product] ADD UNIQUE NONCLUSTERED 
(
	[barcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LoginTbl] ADD  CONSTRAINT [DF_LoginTbl_authority]  DEFAULT ('staff') FOR [authority]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [con_defaultCreated]  DEFAULT (getdate()) FOR [createdDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [def_update]  DEFAULT (getdate()) FOR [updateDate]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [stock]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [revenue]
GO
/****** Object:  StoredProcedure [dbo].[sp_getSecurityQue]    Script Date: 5.01.2024 23:54:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_getSecurityQue]
as
begin
	SELECT * FROM LoginTbl
end
GO
/****** Object:  StoredProcedure [dbo].[sp_login]    Script Date: 5.01.2024 23:54:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_login]
(
@username varchar(50),
@passwd varchar(50)
)
as
begin
	SELECT COUNT(*) FROM LoginTbl WHERE username=@username and password = @passwd 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_passwordUpdate]    Script Date: 5.01.2024 23:54:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_passwordUpdate] (
@email varchar(50),@password varchar(50))
as
begin
	UPDATE LoginTbl set password=@password WHERE email =@email
end
GO
USE [master]
GO
ALTER DATABASE [Market] SET  READ_WRITE 
GO
