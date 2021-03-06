USE [master]
GO
/****** Object:  Database [CreditCalculationDB]    Script Date: 12/29/2019 5:01:55 PM ******/
CREATE DATABASE [CreditCalculationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CreditCalculationDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CreditCalculationDB.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CreditCalculationDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CreditCalculationDB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CreditCalculationDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CreditCalculationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CreditCalculationDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CreditCalculationDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CreditCalculationDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CreditCalculationDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CreditCalculationDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CreditCalculationDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CreditCalculationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CreditCalculationDB] SET  MULTI_USER 
GO
ALTER DATABASE [CreditCalculationDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CreditCalculationDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CreditCalculationDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CreditCalculationDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CreditCalculationDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CreditCalculationDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/29/2019 5:01:55 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerInfo]    Script Date: 12/29/2019 5:01:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TCKN] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[CreditApprovalStatus] [nvarchar](max) NULL,
	[CreditAmount] [float] NOT NULL,
 CONSTRAINT [PK_CustomerInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191228201748_FirstMigration', N'2.2.6-servicing-10079')
SET IDENTITY_INSERT [dbo].[CustomerInfo] ON 

INSERT [dbo].[CustomerInfo] ([ID], [TCKN], [FirstName], [LastName], [Phone], [CreditApprovalStatus], [CreditAmount]) VALUES (1, N'24755338232', N'Selma', N'Öztaşkın', N'05445803889', N'Positive', 10000)
INSERT [dbo].[CustomerInfo] ([ID], [TCKN], [FirstName], [LastName], [Phone], [CreditApprovalStatus], [CreditAmount]) VALUES (2, N'24755338232', N'Selma', N'Öztaşkın', N'05445803889', N'Positive', 10000)
INSERT [dbo].[CustomerInfo] ([ID], [TCKN], [FirstName], [LastName], [Phone], [CreditApprovalStatus], [CreditAmount]) VALUES (3, N'24755338232', N'Selma', N'Öztaşkın', N'05445803889', NULL, 0)
INSERT [dbo].[CustomerInfo] ([ID], [TCKN], [FirstName], [LastName], [Phone], [CreditApprovalStatus], [CreditAmount]) VALUES (4, N'24755338232', N'Selma', N'Öztaşkın', N'05445803889', N'Positive', 18000)
INSERT [dbo].[CustomerInfo] ([ID], [TCKN], [FirstName], [LastName], [Phone], [CreditApprovalStatus], [CreditAmount]) VALUES (5, N'24755338232', N'Selma', N'Öztaşkın', N'05445803889', N'Negative', 0)
SET IDENTITY_INSERT [dbo].[CustomerInfo] OFF
USE [master]
GO
ALTER DATABASE [CreditCalculationDB] SET  READ_WRITE 
GO
