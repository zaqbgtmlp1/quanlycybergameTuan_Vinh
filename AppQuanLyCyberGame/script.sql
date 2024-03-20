USE [master]
GO
/****** Object:  Database [QuanLyCyberGame]    Script Date: 3/21/2024 1:46:13 AM ******/
CREATE DATABASE [QuanLyCyberGame]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyCyberGame', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyCyberGame.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyCyberGame_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyCyberGame_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyCyberGame] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyCyberGame].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyCyberGame] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyCyberGame] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyCyberGame] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyCyberGame] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyCyberGame] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyCyberGame] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyCyberGame] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyCyberGame] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyCyberGame] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyCyberGame] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyCyberGame] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLyCyberGame] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QuanLyCyberGame]
GO
/****** Object:  Table [dbo].[BasicChat]    Script Date: 3/21/2024 1:46:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasicChat](
	[message_id] [int] IDENTITY(1,1) NOT NULL,
	[sender_id] [int] NULL,
	[receiver_id] [int] NULL,
	[message_text] [nvarchar](max) NULL,
	[timestamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[message_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bill]    Script Date: 3/21/2024 1:46:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Total] [float] NULL,
	[IdUser] [int] NULL,
	[BillStatus] [nvarchar](max) NULL,
	[orderat] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillDetail]    Script Date: 3/21/2024 1:46:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetail](
	[BillId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Total] [float] NULL,
	[Number] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[BillId] ASC,
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Chat]    Script Date: 3/21/2024 1:46:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Mess] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClientComputer]    Script Date: 3/21/2024 1:46:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientComputer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CCStatus] [bit] NULL,
	[CCType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClientComputerType]    Script Date: 3/21/2024 1:46:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientComputerType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Cost] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Item]    Script Date: 3/21/2024 1:46:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Cost] [float] NULL,
	[Number] [int] NULL,
	[Itemstatus] [bit] NULL,
	[ordered] [int] NULL,
	[imagepath] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Test]    Script Date: 3/21/2024 1:46:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[id] [int] NOT NULL,
	[ngay_thang_nam] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 3/21/2024 1:46:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/21/2024 1:46:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[UserName] [nvarchar](20) NULL,
	[Password] [nvarchar](20) NULL,
	[IdRole] [int] NOT NULL,
	[CCCD] [nvarchar](20) NULL,
	[Phonenumber] [nvarchar](10) NULL,
	[Useraddress] [nvarchar](max) NULL,
	[Userstatus] [bit] NULL,
	[avatar] [varchar](500) NULL,
	[balance] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BasicChat] ON 

INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (4, 1, 2, N'abc', CAST(N'2024-03-05 18:05:13.607' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (5, 1, 2, N'def', CAST(N'2024-03-05 18:02:13.607' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (6, 1, 2, N'ghi', NULL)
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (7, 1, 2, N'a', NULL)
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (8, 1, 2, N'abc', NULL)
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (9, 1, 2, N'abc', NULL)
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (10, 2, 1, N'xyz', NULL)
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (11, 2, 1, N'qwe', NULL)
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (12, 1, 2, N'aaaa', CAST(N'2024-03-19 20:20:43.300' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (13, 2, 1, N'asdasd', CAST(N'2024-03-19 20:59:44.483' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (14, 2, 1, N'dasdas', CAST(N'2024-03-19 21:03:02.937' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (15, 2, 1, N'111', CAST(N'2024-03-19 21:06:54.920' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (16, 2, 1, N'111', CAST(N'2024-03-19 22:31:02.167' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (17, 2, 1, N'ádasdas', CAST(N'2024-03-19 22:31:08.133' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (18, 2, 1, N'Chào cậu', CAST(N'2024-03-19 22:48:15.737' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (19, 2, 1, N'Hello', CAST(N'2024-03-19 22:48:52.917' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (20, 2, 1, N'Hello', CAST(N'2024-03-19 23:44:12.250' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (21, 2, 1, N'Hello', CAST(N'2024-03-20 00:04:40.607' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (22, 2, 1, N'Hello', CAST(N'2024-03-20 00:16:52.430' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (23, 2, 1, N'2', CAST(N'2024-03-20 00:19:14.957' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (24, 2, 1, N'3', CAST(N'2024-03-20 00:24:48.337' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (25, 2, 1, N'chào', CAST(N'2024-03-20 00:40:08.523' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (26, 1, 1, N'b', CAST(N'2024-03-20 05:22:11.630' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (27, 1, 1, N'cc', CAST(N'2024-03-20 05:22:15.947' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (28, 1, 1, N'ee', CAST(N'2024-03-20 05:22:25.677' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (29, 1, 1, N'dd', CAST(N'2024-03-20 05:22:28.657' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (30, 2, 1, N'chaooooo', CAST(N'2024-03-20 12:06:25.870' AS DateTime))
INSERT [dbo].[BasicChat] ([message_id], [sender_id], [receiver_id], [message_text], [timestamp]) VALUES (31, 2, 1, N'aa', CAST(N'2024-03-20 13:30:32.883' AS DateTime))
SET IDENTITY_INSERT [dbo].[BasicChat] OFF
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (7, 656000, 1, N'0', CAST(N'2024-03-05 18:02:13.607' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (8, 15, 1, N'1', CAST(N'2001-02-10 00:00:00.000' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (9, 100, 1, N'1', CAST(N'2024-03-05 18:07:53.953' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (10, 15000, 1, N'0', CAST(N'2024-03-06 18:07:46.587' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (11, 150000, 1, N'1', CAST(N'2024-03-06 18:08:23.187' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (12, 35000, 2, N'2', CAST(N'2024-03-06 18:08:35.053' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (13, 360000, 2, N'1', CAST(N'2024-03-06 18:08:46.110' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (14, 55000, 1, N'1', CAST(N'2024-03-07 18:08:58.820' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (15, 35000, 1, N'1', CAST(N'2024-03-07 18:09:08.100' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (16, 12000, 1, N'1', CAST(N'2024-03-07 18:10:14.037' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (17, 17000, 1, N'0', CAST(N'2024-03-08 18:10:30.807' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (18, 22000, 1, N'1', CAST(N'2024-03-08 18:10:37.790' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (19, 35000, 1, N'1', CAST(N'2024-03-08 18:10:59.033' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (21, 100, 1, N'0', CAST(N'2024-03-14 02:12:12.823' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (27, 36000, 1, N'0', CAST(N'2024-03-14 02:31:50.260' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (28, 51000, 1, N'0', CAST(N'2024-03-14 11:40:28.367' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (29, 51000, 1, N'0', CAST(N'2024-03-14 11:40:36.127' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (30, 42000, 1, N'0', CAST(N'2024-03-14 17:02:28.517' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (31, 54000, 1, N'0', CAST(N'2024-03-14 17:04:16.630' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (32, 120000, 1, N'0', CAST(N'2024-03-14 17:27:48.833' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (33, 120000, 1, N'0', CAST(N'2024-03-14 17:28:34.030' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (34, 120000, 1, N'0', CAST(N'2024-03-14 17:37:23.043' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (35, 36000, 2, N'0', CAST(N'2024-03-14 17:46:42.873' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (36, 33000, 2, N'0', CAST(N'2024-03-15 17:33:35.870' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (37, 12000, 2, N'0', CAST(N'2024-03-15 18:55:01.260' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (38, 79000, 2, N'0', CAST(N'2024-03-16 09:34:12.030' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (39, 24000, 2, N'0', CAST(N'2024-03-16 09:55:33.533' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (40, 35000, 2, N'0', CAST(N'2024-03-16 11:27:33.277' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (41, 18000, 2, N'0', CAST(N'2024-03-16 11:28:15.407' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (42, 12000, 2, N'0', CAST(N'2024-03-16 11:30:37.470' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (43, 12000, 2, N'0', CAST(N'2024-03-16 11:31:22.483' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (44, 12000, 2, N'0', CAST(N'2024-03-16 11:32:44.797' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (45, 12000, 2, N'0', CAST(N'2024-03-16 11:33:21.190' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (46, 12000, 2, N'0', CAST(N'2024-03-16 11:34:09.893' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (47, 21000, 2, N'0', CAST(N'2024-03-16 11:34:19.267' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (48, 81000, 2, N'0', CAST(N'2024-03-16 11:37:08.257' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (49, 0, 2, N'0', CAST(N'2024-03-16 11:37:14.827' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (50, 16000, 2, N'0', CAST(N'2024-03-16 11:38:26.357' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (51, 13057000, 2, N'0', CAST(N'2024-03-16 11:43:50.110' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (52, 3500000, 2, N'0', CAST(N'2024-03-16 11:45:01.597' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (53, 1200000, 2, N'0', CAST(N'2024-03-16 11:47:09.243' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (54, 1188000, 2, N'0', CAST(N'2024-03-16 12:01:58.520' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (55, 1176000, 2, N'0', CAST(N'2024-03-16 12:02:21.440' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (56, 1164000, 2, N'0', CAST(N'2024-03-16 13:15:00.407' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (57, 1176000, 2, N'0', CAST(N'2024-03-16 14:28:49.377' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (58, 2379000, 2, N'0', CAST(N'2024-03-16 14:31:19.847' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (59, 1184000, 2, N'0', CAST(N'2024-03-16 14:31:37.770' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (60, 1164000, 2, N'0', CAST(N'2024-03-16 15:03:24.643' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (61, 1152000, 2, N'0', CAST(N'2024-03-20 02:13:05.557' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (62, 1140000, 2, N'0', CAST(N'2024-03-20 02:13:10.847' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (63, 48000, 2, N'0', CAST(N'2024-03-20 03:25:01.800' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (64, 0, 2, N'0', CAST(N'2024-03-20 03:35:25.337' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (65, 0, 2, N'0', CAST(N'2024-03-20 03:35:38.263' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (66, 60000, 2, N'0', CAST(N'2024-03-20 03:39:36.937' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (67, 36000, 2, N'0', CAST(N'2024-03-20 03:51:57.367' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (68, 36000, 2, N'0', CAST(N'2024-03-20 03:51:57.423' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (69, 120000, 2, N'0', CAST(N'2024-03-20 04:25:02.127' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (70, 120000, 2, N'0', CAST(N'2024-03-20 04:25:02.180' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (71, 12000, 2, N'0', CAST(N'2024-03-20 04:25:34.777' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (72, 12000, 2, N'0', CAST(N'2024-03-20 04:25:34.777' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (73, 12000, 2, N'0', CAST(N'2024-03-20 04:29:35.393' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (74, 12000, 2, N'0', CAST(N'2024-03-20 04:29:35.447' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (75, 120000, 2, N'0', CAST(N'2024-03-20 04:31:17.980' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (76, 120000, 2, N'0', CAST(N'2024-03-20 04:31:18.040' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (77, 12000, 2, N'0', CAST(N'2024-03-20 04:37:51.660' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (78, 12000, 2, N'0', CAST(N'2024-03-20 04:37:51.713' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (79, 24000, 2, N'0', CAST(N'2024-03-20 04:48:07.000' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (80, 24000, 2, N'0', CAST(N'2024-03-20 04:49:30.350' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (81, 24000, 2, N'0', CAST(N'2024-03-20 04:50:59.317' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (82, 12000, 2, N'0', CAST(N'2024-03-20 05:29:16.510' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (83, 12000, 2, N'0', CAST(N'2024-03-20 11:52:29.220' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (84, 12000, 2, N'0', CAST(N'2024-03-20 12:22:21.557' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (85, 12000, 2, N'0', CAST(N'2024-03-20 12:35:31.590' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (86, 12000, 2, N'0', CAST(N'2024-03-20 12:36:43.473' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (87, 12000, 2, N'0', CAST(N'2024-03-20 12:39:28.820' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (88, 12000, 2, N'0', CAST(N'2024-03-21 01:23:02.663' AS DateTime))
INSERT [dbo].[Bill] ([Id], [Total], [IdUser], [BillStatus], [orderat]) VALUES (89, 27000, 2, N'0', CAST(N'2024-03-21 01:42:19.807' AS DateTime))
SET IDENTITY_INSERT [dbo].[Bill] OFF
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (70, 2, 0, 0)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (72, 4, 0, 0)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (74, 17, 0, 0)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (76, 1, 0, 0)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (78, 1, 0, 0)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (78, 2, 24000, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (79, 1, 1, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (79, 2, 24000, 2)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (80, 3, 12000, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (80, 4, 12000, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (81, 2, 12000, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (81, 3, 12000, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (82, 2, 12000, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (83, 2, 12000, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (84, 3, 12000, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (85, 3, 12000, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (86, 2, 12000, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (87, 1, 12000, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (88, 2, 12000, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (89, 2, 12000, 1)
INSERT [dbo].[BillDetail] ([BillId], [ItemId], [Total], [Number]) VALUES (89, 23, 15000, 1)
SET IDENTITY_INSERT [dbo].[Chat] ON 

INSERT [dbo].[Chat] ([Id], [UserID], [Mess]) VALUES (1, 1, N'1asda')
INSERT [dbo].[Chat] ([Id], [UserID], [Mess]) VALUES (2, 5, N'1')
SET IDENTITY_INSERT [dbo].[Chat] OFF
SET IDENTITY_INSERT [dbo].[ClientComputer] ON 

INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (1, 0, 1)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (2, 0, 1)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (3, 0, 1)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (4, 0, 1)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (5, 0, 1)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (6, 0, 1)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (7, 0, 1)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (8, 0, 1)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (9, 0, 1)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (10, 0, 1)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (11, 0, 2)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (12, 0, 2)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (13, 0, 2)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (14, 0, 2)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (15, 0, 2)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (16, 0, 2)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (17, 0, 2)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (18, 0, 2)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (19, 0, 2)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (20, 0, 2)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (21, 0, 3)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (22, 0, 3)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (23, 0, 3)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (24, 0, 3)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (25, 0, 3)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (26, 0, 3)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (27, 0, 3)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (28, 0, 3)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (29, 0, 3)
INSERT [dbo].[ClientComputer] ([Id], [CCStatus], [CCType]) VALUES (30, 0, 3)
SET IDENTITY_INSERT [dbo].[ClientComputer] OFF
SET IDENTITY_INSERT [dbo].[ClientComputerType] ON 

INSERT [dbo].[ClientComputerType] ([Id], [DisplayName], [Cost]) VALUES (1, N'VIP', 10000)
INSERT [dbo].[ClientComputerType] ([Id], [DisplayName], [Cost]) VALUES (2, N'VIP1', 12000)
INSERT [dbo].[ClientComputerType] ([Id], [DisplayName], [Cost]) VALUES (3, N'VIP2', 15000)
SET IDENTITY_INSERT [dbo].[ClientComputerType] OFF
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (1, N'Pepsi', 12000, 0, 1, 119, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\1.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (2, N'Coca', 12000, 92, 1, 118, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\2.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (3, N'Sting', 12000, 96, 1, 106, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\3.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (4, N'C2', 12000, 99, 1, 102, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\4.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (5, N'Trà xanh 0 độ', 12000, 0, 1, 100, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\5.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (6, N'Cà phê sữa', 18000, 0, 1, 100, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\6.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (7, N'Cà phê đá', 15000, 0, 1, 100, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\7.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (8, N'Mì gói nước', 15000, 0, 1, 100, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\8.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (9, N'Mì gói khô', 16000, 0, 1, 100, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\9.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (10, N'Mì gói nước trứng', 20000, 0, 1, 110, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\10.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (11, N'Mì gói khô trứng', 21000, 0, 1, 100, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\11.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (12, N'Mì gói nước bò viên', 25000, 0, 1, 100, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\12.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (13, N'Mì gói khô bò viên', 26000, 0, 1, 100, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\13.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (14, N'Cơm gà xối mỡ', 35000, 0, 1, 100, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\14.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (15, N'Cơm xào thịt bò', 35000, 0, 1, 100, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\15.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (16, N'Hủ tiếu bò viên', 35000, 0, 1, 100, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\16.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (17, N'Warrior', 12000, 0, 0, 101, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\17.jpg')
INSERT [dbo].[Item] ([Id], [DisplayName], [Cost], [Number], [Itemstatus], [ordered], [imagepath]) VALUES (23, N'Bia', 15000, 999, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Item] OFF
INSERT [dbo].[Test] ([id], [ngay_thang_nam]) VALUES (1, CAST(N'2024-03-05 18:05:48.220' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (2, N'Nhân viên')
INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (3, N'Khách hàng')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole], [CCCD], [Phonenumber], [Useraddress], [Userstatus], [avatar], [balance]) VALUES (1, N'Le Tuan 1', N'letuan1', N'1', 1, N'123456789', N'1', N'1', 1, N'C:\Users\hi\Pictures\Screenshots\Screenshot 2024-01-12 002943.png', 540000)
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole], [CCCD], [Phonenumber], [Useraddress], [Userstatus], [avatar], [balance]) VALUES (2, N'Nguyen Phuoc Vinh', N'vinh1', N'1', 3, N'1', N'1', N'1', 1, N'F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\1.jpg', 45655137488)
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole], [CCCD], [Phonenumber], [Useraddress], [Userstatus], [avatar], [balance]) VALUES (3, N'Nguyen van A', N'vana', N'1', 3, N'1', N'1', N'1', 1, NULL, -1660)
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole], [CCCD], [Phonenumber], [Useraddress], [Userstatus], [avatar], [balance]) VALUES (4, N'1', N'letuan2', N'1', 3, N'1', N'1', NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole], [CCCD], [Phonenumber], [Useraddress], [Userstatus], [avatar], [balance]) VALUES (5, N'Nguyen Van B', N'nguyenvanb', N'1', 3, N'25546', NULL, NULL, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[BasicChat]  WITH CHECK ADD FOREIGN KEY([receiver_id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[BasicChat]  WITH CHECK ADD FOREIGN KEY([sender_id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD FOREIGN KEY([BillId])
REFERENCES [dbo].[Bill] ([Id])
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ClientComputer]  WITH CHECK ADD FOREIGN KEY([CCType])
REFERENCES [dbo].[ClientComputerType] ([Id])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([IdRole])
REFERENCES [dbo].[UserRole] ([Id])
GO
USE [master]
GO
ALTER DATABASE [QuanLyCyberGame] SET  READ_WRITE 
GO
