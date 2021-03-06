USE [master]
GO
/****** Object:  Database [ChessGame]    Script Date: 1/31/2020 9:12:48 AM ******/
CREATE DATABASE [ChessGame]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChessGame', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ChessGame.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChessGame_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ChessGame_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ChessGame] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChessGame].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChessGame] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChessGame] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChessGame] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChessGame] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChessGame] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChessGame] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChessGame] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChessGame] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChessGame] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChessGame] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChessGame] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChessGame] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChessGame] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChessGame] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChessGame] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChessGame] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChessGame] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChessGame] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChessGame] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChessGame] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChessGame] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChessGame] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChessGame] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ChessGame] SET  MULTI_USER 
GO
ALTER DATABASE [ChessGame] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChessGame] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChessGame] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChessGame] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ChessGame] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ChessGame] SET QUERY_STORE = OFF
GO
USE [ChessGame]
GO
/****** Object:  Table [dbo].[DirectionDescription]    Script Date: 1/31/2020 9:12:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DirectionDescription](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RowStep] [smallint] NULL,
	[ColumnStep] [smallint] NULL,
	[DiagonalMovement] [bit] NOT NULL,
	[PerpendicularMovement] [bit] NOT NULL,
 CONSTRAINT [PK__Directio__3214EC07F5597F66] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Directions]    Script Date: 1/31/2020 9:12:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DirectionToDescription]    Script Date: 1/31/2020 9:12:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DirectionToDescription](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DirectionId] [int] NOT NULL,
	[DescriptionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Figures]    Script Date: 1/31/2020 9:12:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Figures](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Photo] [nvarchar](300) NULL,
	[WhiteOrBlack] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FigureToDirections]    Script Date: 1/31/2020 9:12:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FigureToDirections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FigureId] [tinyint] NULL,
	[DirectionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FigureToIndex]    Script Date: 1/31/2020 9:12:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FigureToIndex](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FigureId] [tinyint] NULL,
	[IndexId] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableIndexes]    Script Date: 1/31/2020 9:12:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableIndexes](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[RowIndex] [smallint] NOT NULL,
	[ColumnIndex] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DirectionDescription] ON 

INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (2, 1, 0, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (3, -1, 0, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (4, 0, 1, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (5, 0, -1, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (7, 2, 1, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (8, 2, -1, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (9, -2, -1, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (10, -2, 1, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (11, 1, 2, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (12, -1, 2, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (13, 1, -2, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (14, -1, -2, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (16, 1, 1, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (17, 1, -1, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (18, -1, 1, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (19, -1, -1, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (20, 0, 0, 1, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (23, 0, 0, 0, 1)
SET IDENTITY_INSERT [dbo].[DirectionDescription] OFF
SET IDENTITY_INSERT [dbo].[Directions] ON 

INSERT [dbo].[Directions] ([Id], [Name]) VALUES (6, N'BishopDirection')
INSERT [dbo].[Directions] ([Id], [Name]) VALUES (10, N'KnightDirection')
INSERT [dbo].[Directions] ([Id], [Name]) VALUES (12, N'PawnsDirection')
INSERT [dbo].[Directions] ([Id], [Name]) VALUES (13, N'QueenDirection')
INSERT [dbo].[Directions] ([Id], [Name]) VALUES (14, N'RockDirection')
INSERT [dbo].[Directions] ([Id], [Name]) VALUES (15, N'BlackPownDirection')
SET IDENTITY_INSERT [dbo].[Directions] OFF
SET IDENTITY_INSERT [dbo].[DirectionToDescription] ON 

INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (12, 10, 7)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (13, 10, 8)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (14, 10, 9)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (15, 10, 10)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (16, 10, 11)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (17, 10, 12)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (18, 10, 13)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (19, 10, 14)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (21, 12, 2)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (22, 12, 16)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (23, 12, 17)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (24, 13, 2)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (25, 13, 3)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (26, 13, 4)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (27, 13, 5)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (28, 13, 16)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (29, 13, 19)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (30, 13, 18)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (31, 13, 17)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (32, 6, 20)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (33, 14, 23)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (34, 15, 3)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (35, 15, 18)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (36, 15, 19)
SET IDENTITY_INSERT [dbo].[DirectionToDescription] OFF
SET IDENTITY_INSERT [dbo].[Figures] ON 

INSERT [dbo].[Figures] ([Id], [Name], [Photo], [WhiteOrBlack]) VALUES (3, N'Pawns', N'2020.1.8.17.33.24.312.png', 1)
INSERT [dbo].[Figures] ([Id], [Name], [Photo], [WhiteOrBlack]) VALUES (4, N'Rooks ', N'2020.1.8.17.27.20.260.png', 1)
INSERT [dbo].[Figures] ([Id], [Name], [Photo], [WhiteOrBlack]) VALUES (5, N'Knights ', N'2020.1.8.17.31.13.238.png', 1)
INSERT [dbo].[Figures] ([Id], [Name], [Photo], [WhiteOrBlack]) VALUES (11, N'King', N'2020.1.8.17.35.50.392.png', 1)
INSERT [dbo].[Figures] ([Id], [Name], [Photo], [WhiteOrBlack]) VALUES (12, N'Queen', N'2020.1.8.15.29.27.127.png', 1)
INSERT [dbo].[Figures] ([Id], [Name], [Photo], [WhiteOrBlack]) VALUES (13, N'Bishops', N'2020.1.8.15.26.45.379.png', 1)
INSERT [dbo].[Figures] ([Id], [Name], [Photo], [WhiteOrBlack]) VALUES (18, N'Pawns Black', N'2020.1.23.17.34.12.807.png', 0)
INSERT [dbo].[Figures] ([Id], [Name], [Photo], [WhiteOrBlack]) VALUES (19, N'Rooks Black', N'2020.1.23.17.37.11.511.png', 0)
INSERT [dbo].[Figures] ([Id], [Name], [Photo], [WhiteOrBlack]) VALUES (20, N'Knights Black', N'2020.1.23.17.36.22.105.png', 0)
INSERT [dbo].[Figures] ([Id], [Name], [Photo], [WhiteOrBlack]) VALUES (21, N'Bishops Black', N'2020.1.23.17.40.16.631.png', 0)
INSERT [dbo].[Figures] ([Id], [Name], [Photo], [WhiteOrBlack]) VALUES (22, N'King Black', N'2020.1.23.17.43.0.575.png', 0)
INSERT [dbo].[Figures] ([Id], [Name], [Photo], [WhiteOrBlack]) VALUES (23, N'Queen Black', N'2020.1.23.17.44.5.456.png', 0)
SET IDENTITY_INSERT [dbo].[Figures] OFF
SET IDENTITY_INSERT [dbo].[FigureToDirections] ON 

INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (1, 13, 6)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (6, 5, 10)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (8, 3, 12)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (9, 12, 13)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (11, 4, 14)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (12, 12, 14)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (13, 12, 6)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (14, 11, 14)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (15, 11, 6)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (16, 23, 13)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (18, 21, 6)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (19, 20, 10)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (20, 19, 14)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (21, 18, 15)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (22, 22, 6)
INSERT [dbo].[FigureToDirections] ([Id], [FigureId], [DirectionId]) VALUES (23, 22, 14)
SET IDENTITY_INSERT [dbo].[FigureToDirections] OFF
SET IDENTITY_INSERT [dbo].[FigureToIndex] ON 

INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (14, 3, 9)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (15, 3, 10)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (16, 3, 11)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (17, 3, 12)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (18, 3, 13)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (19, 3, 14)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (20, 3, 15)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (21, 3, 16)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (22, 4, 1)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (23, 4, 8)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (24, 5, 2)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (25, 5, 7)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (26, 13, 3)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (27, 13, 6)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (28, 11, 5)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (29, 12, 4)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (30, 18, 49)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (31, 18, 50)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (32, 18, 51)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (33, 18, 52)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (34, 18, 53)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (35, 18, 54)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (36, 18, 55)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (37, 18, 56)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (38, 19, 57)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (39, 19, 64)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (40, 20, 58)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (41, 20, 63)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (42, 21, 59)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (43, 21, 62)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (45, 23, 61)
INSERT [dbo].[FigureToIndex] ([Id], [FigureId], [IndexId]) VALUES (46, 22, 60)
SET IDENTITY_INSERT [dbo].[FigureToIndex] OFF
SET IDENTITY_INSERT [dbo].[TableIndexes] ON 

INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (1, 1, 1)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (2, 1, 2)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (3, 1, 3)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (4, 1, 4)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (5, 1, 5)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (6, 1, 6)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (7, 1, 7)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (8, 1, 8)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (9, 2, 1)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (10, 2, 2)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (11, 2, 3)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (12, 2, 4)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (13, 2, 5)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (14, 2, 6)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (15, 2, 7)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (16, 2, 8)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (17, 3, 1)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (18, 3, 2)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (19, 3, 3)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (20, 3, 4)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (21, 3, 5)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (22, 3, 6)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (23, 3, 7)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (24, 3, 8)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (25, 4, 1)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (26, 4, 2)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (27, 4, 3)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (28, 4, 4)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (29, 4, 5)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (30, 4, 6)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (31, 4, 7)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (32, 4, 8)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (33, 5, 1)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (34, 5, 2)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (35, 5, 3)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (36, 5, 4)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (37, 5, 5)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (38, 5, 6)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (39, 5, 7)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (40, 5, 8)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (41, 6, 1)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (42, 6, 2)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (43, 6, 3)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (44, 6, 4)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (45, 6, 5)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (46, 6, 6)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (47, 6, 7)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (48, 6, 8)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (49, 7, 1)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (50, 7, 2)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (51, 7, 3)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (52, 7, 4)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (53, 7, 5)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (54, 7, 6)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (55, 7, 7)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (56, 7, 8)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (57, 8, 1)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (58, 8, 2)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (59, 8, 3)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (60, 8, 4)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (61, 8, 5)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (62, 8, 6)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (63, 8, 7)
INSERT [dbo].[TableIndexes] ([Id], [RowIndex], [ColumnIndex]) VALUES (64, 8, 8)
SET IDENTITY_INSERT [dbo].[TableIndexes] OFF
/****** Object:  Index [uniqueIndexForEachFigure]    Script Date: 1/31/2020 9:12:51 AM ******/
ALTER TABLE [dbo].[FigureToIndex] ADD  CONSTRAINT [uniqueIndexForEachFigure] UNIQUE NONCLUSTERED 
(
	[IndexId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [uniqueIndexes]    Script Date: 1/31/2020 9:12:51 AM ******/
ALTER TABLE [dbo].[TableIndexes] ADD  CONSTRAINT [uniqueIndexes] UNIQUE NONCLUSTERED 
(
	[RowIndex] ASC,
	[ColumnIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DirectionDescription] ADD  CONSTRAINT [DF__Direction__RowSt__48CFD27E]  DEFAULT ((0)) FOR [RowStep]
GO
ALTER TABLE [dbo].[DirectionDescription] ADD  CONSTRAINT [DF__Direction__Colum__49C3F6B7]  DEFAULT ((0)) FOR [ColumnStep]
GO
ALTER TABLE [dbo].[Directions]  WITH CHECK ADD  CONSTRAINT [FK_Directions_Directions] FOREIGN KEY([Id])
REFERENCES [dbo].[Directions] ([Id])
GO
ALTER TABLE [dbo].[Directions] CHECK CONSTRAINT [FK_Directions_Directions]
GO
ALTER TABLE [dbo].[DirectionToDescription]  WITH CHECK ADD  CONSTRAINT [FK__Direction__Descr__534D60F1] FOREIGN KEY([DescriptionId])
REFERENCES [dbo].[DirectionDescription] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DirectionToDescription] CHECK CONSTRAINT [FK__Direction__Descr__534D60F1]
GO
ALTER TABLE [dbo].[DirectionToDescription]  WITH CHECK ADD  CONSTRAINT [FK__Direction__Direc__4316F928] FOREIGN KEY([DirectionId])
REFERENCES [dbo].[Directions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DirectionToDescription] CHECK CONSTRAINT [FK__Direction__Direc__4316F928]
GO
ALTER TABLE [dbo].[FigureToDirections]  WITH CHECK ADD  CONSTRAINT [FK__FigureToD__Direc__440B1D61] FOREIGN KEY([DirectionId])
REFERENCES [dbo].[Directions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FigureToDirections] CHECK CONSTRAINT [FK__FigureToD__Direc__440B1D61]
GO
ALTER TABLE [dbo].[FigureToDirections]  WITH CHECK ADD FOREIGN KEY([FigureId])
REFERENCES [dbo].[Figures] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FigureToIndex]  WITH CHECK ADD  CONSTRAINT [FK__FigureToI__Figur__5DCAEF64] FOREIGN KEY([FigureId])
REFERENCES [dbo].[Figures] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FigureToIndex] CHECK CONSTRAINT [FK__FigureToI__Figur__5DCAEF64]
GO
ALTER TABLE [dbo].[FigureToIndex]  WITH CHECK ADD  CONSTRAINT [FK__FigureToI__Index__5EBF139D] FOREIGN KEY([IndexId])
REFERENCES [dbo].[TableIndexes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FigureToIndex] CHECK CONSTRAINT [FK__FigureToI__Index__5EBF139D]
GO
USE [master]
GO
ALTER DATABASE [ChessGame] SET  READ_WRITE 
GO
