USE [master]
GO
/****** Object:  Database [StaffordUniversity]    Script Date: 7/1/2018 6:29:16 AM ******/
CREATE DATABASE [StaffordUniversity]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StaffordUniversity', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StaffordUniversity.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StaffordUniversity_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StaffordUniversity_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StaffordUniversity] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StaffordUniversity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StaffordUniversity] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StaffordUniversity] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StaffordUniversity] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StaffordUniversity] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StaffordUniversity] SET ARITHABORT OFF 
GO
ALTER DATABASE [StaffordUniversity] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StaffordUniversity] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StaffordUniversity] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StaffordUniversity] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StaffordUniversity] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StaffordUniversity] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StaffordUniversity] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StaffordUniversity] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StaffordUniversity] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StaffordUniversity] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StaffordUniversity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StaffordUniversity] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StaffordUniversity] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StaffordUniversity] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StaffordUniversity] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StaffordUniversity] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StaffordUniversity] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StaffordUniversity] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StaffordUniversity] SET  MULTI_USER 
GO
ALTER DATABASE [StaffordUniversity] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StaffordUniversity] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StaffordUniversity] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StaffordUniversity] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StaffordUniversity] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StaffordUniversity] SET QUERY_STORE = OFF
GO
USE [StaffordUniversity]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [StaffordUniversity]
GO
/****** Object:  Table [dbo].[AssignModule]    Script Date: 7/1/2018 6:29:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignModule](
	[MId] [varchar](50) NULL,
	[Programme] [varchar](50) NULL,
	[Faculty] [varchar](50) NULL,
	[ModuleFee] [varchar](50) NULL,
	[Duration] [varchar](50) NULL,
	[StartDate] [varchar](50) NULL,
	[EndDate] [varchar](50) NULL,
	[pId] [varchar](50) NULL,
	[sid] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 7/1/2018 6:29:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BId] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [int] NULL,
	[sid] [varchar](50) NULL,
	[mid] [varchar](50) NULL,
	[PaymentMethod] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[BId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 7/1/2018 6:29:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[MId] [varchar](50) NOT NULL,
	[Programme] [varchar](100) NULL,
	[Faculty] [varchar](100) NULL,
	[Semester] [varchar](50) NULL,
	[Duration] [varchar](50) NULL,
	[ModuleFee] [varchar](50) NULL,
	[ModuleDescription] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[MId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModuleRegistration]    Script Date: 7/1/2018 6:29:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleRegistration](
	[sid] [varchar](50) NOT NULL,
	[mid] [varchar](50) NOT NULL,
	[bid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sid] ASC,
	[mid] ASC,
	[bid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professor]    Script Date: 7/1/2018 6:29:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor](
	[PId] [varchar](50) NOT NULL,
	[FirstName] [varchar](20) NULL,
	[LastName] [varchar](20) NULL,
	[DOB] [varchar](50) NULL,
	[PhoneNo] [varchar](10) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Gender] [varchar](10) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfessorModule]    Script Date: 7/1/2018 6:29:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessorModule](
	[pId] [varchar](50) NOT NULL,
	[mid] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pId] ASC,
	[mid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registar]    Script Date: 7/1/2018 6:29:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registar](
	[RId] [varchar](50) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 7/1/2018 6:29:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[SId] [varchar](50) NOT NULL,
	[FirstName] [varchar](20) NULL,
	[LastName] [varchar](20) NULL,
	[DOB] [varchar](50) NULL,
	[PhoneNo] [varchar](10) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Gender] [varchar](10) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentModule]    Script Date: 7/1/2018 6:29:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentModule](
	[sid] [varchar](50) NOT NULL,
	[mid] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sid] ASC,
	[mid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ModuleRegistration]  WITH CHECK ADD FOREIGN KEY([bid])
REFERENCES [dbo].[Bill] ([BId])
GO
ALTER TABLE [dbo].[ModuleRegistration]  WITH CHECK ADD FOREIGN KEY([mid])
REFERENCES [dbo].[Module] ([MId])
GO
ALTER TABLE [dbo].[ModuleRegistration]  WITH CHECK ADD FOREIGN KEY([sid])
REFERENCES [dbo].[Student] ([SId])
GO
ALTER TABLE [dbo].[ProfessorModule]  WITH CHECK ADD FOREIGN KEY([mid])
REFERENCES [dbo].[Module] ([MId])
GO
ALTER TABLE [dbo].[ProfessorModule]  WITH CHECK ADD FOREIGN KEY([pId])
REFERENCES [dbo].[Professor] ([PId])
GO
ALTER TABLE [dbo].[StudentModule]  WITH CHECK ADD FOREIGN KEY([mid])
REFERENCES [dbo].[Module] ([MId])
GO
ALTER TABLE [dbo].[StudentModule]  WITH CHECK ADD FOREIGN KEY([sid])
REFERENCES [dbo].[Student] ([SId])
GO
USE [master]
GO
ALTER DATABASE [StaffordUniversity] SET  READ_WRITE 
GO
