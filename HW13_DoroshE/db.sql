USE [master]
GO
/****** Object:  Database [SigmaCinemaDB]    Script Date: 1/17/2023 4:49:03 PM ******/
CREATE DATABASE [SigmaCinemaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SigmaCinemaDB', FILENAME = N'E:\MSSQLSERVER\MSSQL16.MSSQLSERVER\MSSQL\DATA\SigmaCinemaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SigmaCinemaDB_log', FILENAME = N'E:\MSSQLSERVER\MSSQL16.MSSQLSERVER\MSSQL\DATA\SigmaCinemaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SigmaCinemaDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SigmaCinemaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SigmaCinemaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SigmaCinemaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SigmaCinemaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SigmaCinemaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SigmaCinemaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET RECOVERY FULL 
GO
ALTER DATABASE [SigmaCinemaDB] SET  MULTI_USER 
GO
ALTER DATABASE [SigmaCinemaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SigmaCinemaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SigmaCinemaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SigmaCinemaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SigmaCinemaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SigmaCinemaDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SigmaCinemaDB', N'ON'
GO
ALTER DATABASE [SigmaCinemaDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [SigmaCinemaDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SigmaCinemaDB]
GO
/****** Object:  Table [dbo].[CinemaHalls]    Script Date: 1/17/2023 4:49:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CinemaHalls](
	[CinemaHallGuid] [uniqueidentifier] NOT NULL,
	[Address] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CinemaHalls] PRIMARY KEY CLUSTERED 
(
	[CinemaHallGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 1/17/2023 4:49:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[UserGuid] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hall]    Script Date: 1/17/2023 4:49:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hall](
	[HallGuid] [uniqueidentifier] NOT NULL,
	[FK_CinemaHallId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Hall] PRIMARY KEY CLUSTERED 
(
	[HallGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 1/17/2023 4:49:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieGuid] [uniqueidentifier] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seats]    Script Date: 1/17/2023 4:49:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seats](
	[SeatGuid] [uniqueidentifier] NOT NULL,
	[seatNumber] [int] NOT NULL,
	[HallGuid] [uniqueidentifier] NOT NULL,
	[SeatPriceCoef] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Seats] PRIMARY KEY CLUSTERED 
(
	[SeatGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Showtimes]    Script Date: 1/17/2023 4:49:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Showtimes](
	[ShowtimeGuid] [uniqueidentifier] NOT NULL,
	[DataTime] [smalldatetime] NOT NULL,
	[HallGuid] [uniqueidentifier] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[MovieGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Showtimes] PRIMARY KEY CLUSTERED 
(
	[ShowtimeGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 1/17/2023 4:49:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[TicketGuid] [uniqueidentifier] NOT NULL,
	[ShowtimeGuid] [uniqueidentifier] NOT NULL,
	[SeatGuid] [uniqueidentifier] NOT NULL,
	[UserGuid] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[CinemaHalls] ([CinemaHallGuid], [Address]) VALUES (N'907fc288-42d7-458e-9be2-a00f29494916', N'st. Topolna 23')
INSERT [dbo].[CinemaHalls] ([CinemaHallGuid], [Address]) VALUES (N'477b81d5-2c53-4693-a86e-d4389d3bf692', N'st. Shevchenka 78')
INSERT [dbo].[CinemaHalls] ([CinemaHallGuid], [Address]) VALUES (N'c5d2e18e-d9a5-479e-b985-d923c1d6a0cb', N'st. Pid Dybom')
GO
INSERT [dbo].[Customers] ([UserGuid], [FirstName], [LastName]) VALUES (N'ecdc6ff3-ad0b-4cef-a096-3e12183f9e74', N'123', N'321')
INSERT [dbo].[Customers] ([UserGuid], [FirstName], [LastName]) VALUES (N'eec7e18a-9fd7-441a-bab3-bce74620e1fe', N'Mark', N'Sviriduk')
INSERT [dbo].[Customers] ([UserGuid], [FirstName], [LastName]) VALUES (N'1ee69c1f-c4a3-45ff-b532-d20d4c37d6ca', N'Sara', N'Konor')
GO
INSERT [dbo].[Hall] ([HallGuid], [FK_CinemaHallId]) VALUES (N'c07f6b1b-f3bd-4b19-9427-4068fd858815', N'c5d2e18e-d9a5-479e-b985-d923c1d6a0cb')
INSERT [dbo].[Hall] ([HallGuid], [FK_CinemaHallId]) VALUES (N'682ddf6a-d2c3-4c3c-9798-a081ce7cc085', N'907fc288-42d7-458e-9be2-a00f29494916')
GO
INSERT [dbo].[Movies] ([MovieGuid], [Name], [Description]) VALUES (N'1d8f37de-291c-427f-a630-78deef10c9e3', N'Shutter Island', NULL)
INSERT [dbo].[Movies] ([MovieGuid], [Name], [Description]) VALUES (N'7cb7cb70-5e56-44cc-9944-81c067069b52', N'A Clockwork Orange', NULL)
INSERT [dbo].[Movies] ([MovieGuid], [Name], [Description]) VALUES (N'726028a7-67c8-4888-8d21-c69447a81fb3', N'Berserk', NULL)
GO
INSERT [dbo].[Seats] ([SeatGuid], [seatNumber], [HallGuid], [SeatPriceCoef]) VALUES (N'68cff528-74c8-488b-b895-0c50d9b516be', 4, N'682ddf6a-d2c3-4c3c-9798-a081ce7cc085', CAST(0.75 AS Decimal(18, 2)))
INSERT [dbo].[Seats] ([SeatGuid], [seatNumber], [HallGuid], [SeatPriceCoef]) VALUES (N'acb28b56-b8c2-4a80-8916-536467459bb0', 3, N'682ddf6a-d2c3-4c3c-9798-a081ce7cc085', CAST(0.75 AS Decimal(18, 2)))
INSERT [dbo].[Seats] ([SeatGuid], [seatNumber], [HallGuid], [SeatPriceCoef]) VALUES (N'c29af305-464c-4853-8a16-d0da97438685', 1, N'682ddf6a-d2c3-4c3c-9798-a081ce7cc085', CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[Seats] ([SeatGuid], [seatNumber], [HallGuid], [SeatPriceCoef]) VALUES (N'1ffdfda1-5821-4dfe-8188-d97a133468e4', 2, N'682ddf6a-d2c3-4c3c-9798-a081ce7cc085', CAST(1.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Showtimes] ([ShowtimeGuid], [DataTime], [HallGuid], [Price], [MovieGuid]) VALUES (N'13dee353-4856-4444-9317-098c1fb708e5', CAST(N'2023-01-07T16:00:00' AS SmallDateTime), N'682ddf6a-d2c3-4c3c-9798-a081ce7cc085', CAST(34.00 AS Decimal(18, 2)), N'1d8f37de-291c-427f-a630-78deef10c9e3')
INSERT [dbo].[Showtimes] ([ShowtimeGuid], [DataTime], [HallGuid], [Price], [MovieGuid]) VALUES (N'a3bc632b-2303-44ea-baab-3c66e8b23d1b', CAST(N'2023-12-12T22:00:00' AS SmallDateTime), N'682ddf6a-d2c3-4c3c-9798-a081ce7cc085', CAST(75.00 AS Decimal(18, 2)), N'726028a7-67c8-4888-8d21-c69447a81fb3')
INSERT [dbo].[Showtimes] ([ShowtimeGuid], [DataTime], [HallGuid], [Price], [MovieGuid]) VALUES (N'f100e1a9-135d-49ab-9799-5665c4626f06', CAST(N'2023-01-16T16:00:00' AS SmallDateTime), N'682ddf6a-d2c3-4c3c-9798-a081ce7cc085', CAST(100.00 AS Decimal(18, 2)), N'726028a7-67c8-4888-8d21-c69447a81fb3')
INSERT [dbo].[Showtimes] ([ShowtimeGuid], [DataTime], [HallGuid], [Price], [MovieGuid]) VALUES (N'8c4b4ef6-90c9-4dab-b3af-60888e40e2f7', CAST(N'2023-01-11T20:00:00' AS SmallDateTime), N'682ddf6a-d2c3-4c3c-9798-a081ce7cc085', CAST(150.00 AS Decimal(18, 2)), N'7cb7cb70-5e56-44cc-9944-81c067069b52')
INSERT [dbo].[Showtimes] ([ShowtimeGuid], [DataTime], [HallGuid], [Price], [MovieGuid]) VALUES (N'ef485e5b-fee6-4696-9fcb-6ee32321a86c', CAST(N'2023-01-18T18:00:00' AS SmallDateTime), N'682ddf6a-d2c3-4c3c-9798-a081ce7cc085', CAST(80.00 AS Decimal(18, 2)), N'1d8f37de-291c-427f-a630-78deef10c9e3')
INSERT [dbo].[Showtimes] ([ShowtimeGuid], [DataTime], [HallGuid], [Price], [MovieGuid]) VALUES (N'45c6c80c-af11-4510-8025-c4816de4e15b', CAST(N'2023-01-07T16:00:00' AS SmallDateTime), N'682ddf6a-d2c3-4c3c-9798-a081ce7cc085', CAST(342.00 AS Decimal(18, 2)), N'7cb7cb70-5e56-44cc-9944-81c067069b52')
GO
INSERT [dbo].[Tickets] ([TicketGuid], [ShowtimeGuid], [SeatGuid], [UserGuid]) VALUES (N'6d103fe5-cc84-4223-9750-93e184b92f11', N'a3bc632b-2303-44ea-baab-3c66e8b23d1b', N'68cff528-74c8-488b-b895-0c50d9b516be', N'1ee69c1f-c4a3-45ff-b532-d20d4c37d6ca')
INSERT [dbo].[Tickets] ([TicketGuid], [ShowtimeGuid], [SeatGuid], [UserGuid]) VALUES (N'18672304-be96-4f6f-b2a4-be3f61dbef5b', N'f100e1a9-135d-49ab-9799-5665c4626f06', N'c29af305-464c-4853-8a16-d0da97438685', N'eec7e18a-9fd7-441a-bab3-bce74620e1fe')
INSERT [dbo].[Tickets] ([TicketGuid], [ShowtimeGuid], [SeatGuid], [UserGuid]) VALUES (N'fdede4ea-83e7-4845-9efc-7214a0e28efb', N'f100e1a9-135d-49ab-9799-5665c4626f06', N'acb28b56-b8c2-4a80-8916-536467459bb0', N'ecdc6ff3-ad0b-4cef-a096-3e12183f9e74')
INSERT [dbo].[Tickets] ([TicketGuid], [ShowtimeGuid], [SeatGuid], [UserGuid]) VALUES (N'6282003e-26ff-42ef-adf7-7aea3154c59f', N'ef485e5b-fee6-4696-9fcb-6ee32321a86c', N'68cff528-74c8-488b-b895-0c50d9b516be', N'68cff528-74c8-488b-b895-0c50d9b516be')
INSERT [dbo].[Tickets] ([TicketGuid], [ShowtimeGuid], [SeatGuid], [UserGuid]) VALUES (N'd63140e4-109c-42ac-94b7-b5949c6c6801', N'45c6c80c-af11-4510-8025-c4816de4e15b', N'68cff528-74c8-488b-b895-0c50d9b516be', N'1ee69c1f-c4a3-45ff-b532-d20d4c37d6ca')
INSERT [dbo].[Tickets] ([TicketGuid], [ShowtimeGuid], [SeatGuid], [UserGuid]) VALUES (N'98caf323-682c-405d-926d-4156e347b426', N'45c6c80c-af11-4510-8025-c4816de4e15b', N'acb28b56-b8c2-4a80-8916-536467459bb0', N'1ee69c1f-c4a3-45ff-b532-d20d4c37d6ca')
INSERT [dbo].[Tickets] ([TicketGuid], [ShowtimeGuid], [SeatGuid], [UserGuid]) VALUES (N'e9f20292-9aa4-4881-b42f-a4819e7779b0', N'45c6c80c-af11-4510-8025-c4816de4e15b', N'68cff528-74c8-488b-b895-0c50d9b516be', N'1ee69c1f-c4a3-45ff-b532-d20d4c37d6ca')
INSERT [dbo].[Tickets] ([TicketGuid], [ShowtimeGuid], [SeatGuid], [UserGuid]) VALUES (N'3acdfe4e-097e-4c20-9fc8-9e189c957cfd', N'45c6c80c-af11-4510-8025-c4816de4e15b', N'c29af305-464c-4853-8a16-d0da97438685', N'1ee69c1f-c4a3-45ff-b532-d20d4c37d6ca')
GO
ALTER TABLE [dbo].[Hall]  WITH CHECK ADD  CONSTRAINT [FK_CinemaHallid_CinemaHalls] FOREIGN KEY([FK_CinemaHallId])
REFERENCES [dbo].[CinemaHalls] ([CinemaHallGuid])
GO
ALTER TABLE [dbo].[Hall] CHECK CONSTRAINT [FK_CinemaHallid_CinemaHalls]
GO
ALTER TABLE [dbo].[Seats]  WITH CHECK ADD  CONSTRAINT [FK_SeatHallGuid_HallGuid] FOREIGN KEY([HallGuid])
REFERENCES [dbo].[Hall] ([HallGuid])
GO
ALTER TABLE [dbo].[Seats] CHECK CONSTRAINT [FK_SeatHallGuid_HallGuid]
GO
ALTER TABLE [dbo].[Showtimes]  WITH CHECK ADD  CONSTRAINT [FK_Showtimes_Hall] FOREIGN KEY([HallGuid])
REFERENCES [dbo].[Hall] ([HallGuid])
GO
ALTER TABLE [dbo].[Showtimes] CHECK CONSTRAINT [FK_Showtimes_Hall]
GO
ALTER TABLE [dbo].[Showtimes]  WITH CHECK ADD  CONSTRAINT [FK_Showtimes_Movies] FOREIGN KEY([MovieGuid])
REFERENCES [dbo].[Movies] ([MovieGuid])
GO
ALTER TABLE [dbo].[Showtimes] CHECK CONSTRAINT [FK_Showtimes_Movies]
GO
USE [master]
GO
ALTER DATABASE [SigmaCinemaDB] SET  READ_WRITE 
GO
