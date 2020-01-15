USE [master]
GO
/****** Object:  Database [ChessGame]    Script Date: 1/15/2020 7:14:34 AM ******/
CREATE DATABASE [ChessGame]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChessGame', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\ChessGame.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChessGame_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\ChessGame_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[DirectionDescription]    Script Date: 1/15/2020 7:14:34 AM ******/
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
/****** Object:  Table [dbo].[Directions]    Script Date: 1/15/2020 7:14:35 AM ******/
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
/****** Object:  Table [dbo].[DirectionToDescription]    Script Date: 1/15/2020 7:14:35 AM ******/
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
/****** Object:  Table [dbo].[Figures]    Script Date: 1/15/2020 7:14:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Figures](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Photo] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FigureToDirections]    Script Date: 1/15/2020 7:14:35 AM ******/
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
SET IDENTITY_INSERT [dbo].[DirectionDescription] ON 

INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (2, 1, 0, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (3, -1, 0, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (4, 0, 1, 0, 0)
INSERT [dbo].[DirectionDescription] ([Id], [RowStep], [ColumnStep], [DiagonalMovement], [PerpendicularMovement]) VALUES (5, 0, -1, 0, 0)
SET IDENTITY_INSERT [dbo].[DirectionDescription] OFF
SET IDENTITY_INSERT [dbo].[Directions] ON 

INSERT [dbo].[Directions] ([Id], [Name]) VALUES (2, N'OneStepWrite')
INSERT [dbo].[Directions] ([Id], [Name]) VALUES (4, N'OneStepLeft')
INSERT [dbo].[Directions] ([Id], [Name]) VALUES (5, N'TwoStepUpOneStepWrite')
SET IDENTITY_INSERT [dbo].[Directions] OFF
SET IDENTITY_INSERT [dbo].[DirectionToDescription] ON 

INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (3, 2, 4)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (4, 2, 3)
INSERT [dbo].[DirectionToDescription] ([Id], [DirectionId], [DescriptionId]) VALUES (6, 2, 5)
SET IDENTITY_INSERT [dbo].[DirectionToDescription] OFF
SET IDENTITY_INSERT [dbo].[Figures] ON 

INSERT [dbo].[Figures] ([Id], [Name], [Photo]) VALUES (3, N'Pawns', N'2020.1.8.17.33.24.312.png')
INSERT [dbo].[Figures] ([Id], [Name], [Photo]) VALUES (4, N'Rooks ', N'2020.1.8.17.27.20.260.png')
INSERT [dbo].[Figures] ([Id], [Name], [Photo]) VALUES (5, N'Knights ', N'2020.1.8.17.31.13.238.png')
INSERT [dbo].[Figures] ([Id], [Name], [Photo]) VALUES (11, N'King', N'2020.1.8.17.35.50.392.png')
INSERT [dbo].[Figures] ([Id], [Name], [Photo]) VALUES (12, N'Queen', N'2020.1.8.15.29.27.127.png')
INSERT [dbo].[Figures] ([Id], [Name], [Photo]) VALUES (13, N'Bishops', N'2020.1.8.15.26.45.379.png')
SET IDENTITY_INSERT [dbo].[Figures] OFF
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
ALTER TABLE [dbo].[DirectionToDescription]  WITH CHECK ADD FOREIGN KEY([DirectionId])
REFERENCES [dbo].[Directions] ([Id])
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
USE [master]
GO
ALTER DATABASE [ChessGame] SET  READ_WRITE 
GO
