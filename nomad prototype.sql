USE [master]
GO

/****** Object:  Database [DB_121607_nomad]    Script Date: 8/25/2020 2:39:50 PM ******/
CREATE DATABASE [DB_121607_nomad]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_121607_nomad_data', FILENAME = N'e:\sqldata\DB_121607_nomad_data.mdf' , SIZE = 8192KB , MAXSIZE = 25600KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB_121607_nomad_log', FILENAME = N'f:\sqllog\DB_121607_nomad_log.ldf' , SIZE = 73728KB , MAXSIZE = 1024000KB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_121607_nomad].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [DB_121607_nomad] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET ARITHABORT OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [DB_121607_nomad] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [DB_121607_nomad] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET  DISABLE_BROKER 
GO

ALTER DATABASE [DB_121607_nomad] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [DB_121607_nomad] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [DB_121607_nomad] SET  MULTI_USER 
GO

ALTER DATABASE [DB_121607_nomad] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [DB_121607_nomad] SET DB_CHAINING OFF 
GO

ALTER DATABASE [DB_121607_nomad] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [DB_121607_nomad] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [DB_121607_nomad] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [DB_121607_nomad] SET QUERY_STORE = ON
GO

ALTER DATABASE [DB_121607_nomad] SET QUERY_STORE (OPERATION_MODE = READ_ONLY, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 3), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 30, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [DB_121607_nomad] SET  READ_WRITE 
GO

USE [DB_121607_nomad]
GO

/****** Object:  Table [dbo].[cli]    Script Date: 8/25/2020 3:20:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cli](
	[cli] [varchar](80) NOT NULL,
	[pcode] [varchar](80) NOT NULL,
	[group_] [numeric](4, 0) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[cli] ADD  CONSTRAINT [DF_cli_cli]  DEFAULT ('') FOR [cli]
GO

ALTER TABLE [dbo].[cli] ADD  CONSTRAINT [DF_cli_pcode]  DEFAULT ('') FOR [pcode]
GO

ALTER TABLE [dbo].[cli] ADD  CONSTRAINT [DF_cli_group_]  DEFAULT ((0)) FOR [group_]
GO

USE [DB_121607_nomad]
GO

INSERT INTO [dbo].[cli]
           ([cli]
           ,[pcode]
           ,[group_])
     VALUES
           ('READ_NOMAD',		   
           'NOMAD',		   
           0
		   )
		   
GO

INSERT INTO [dbo].[cli]
           ([cli]
           ,[pcode]
           ,[group_])
     VALUES
           ('REVISE_NOMAD',	   
           '_NOMAD',   
           1
		   )
		   
GO

USE [DB_121607_nomad]
GO

/****** Object:  Table [dbo].[component]    Script Date: 8/25/2020 3:31:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[component](
	[ID] [numeric](8, 0) IDENTITY(1,1) NOT NULL,
	[name] [varchar](277) NOT NULL,
	[comp_type] [numeric](2, 0) NOT NULL,
	[super_comp] [numeric](8, 0) NOT NULL,
	[img] [varbinary](max) NOT NULL,
	[format] [varchar](8) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[component] ADD  CONSTRAINT [DF_components_name]  DEFAULT ('') FOR [name]
GO

ALTER TABLE [dbo].[component] ADD  CONSTRAINT [DF_components_comp_type]  DEFAULT ((0)) FOR [comp_type]
GO

ALTER TABLE [dbo].[component] ADD  CONSTRAINT [DF_components_super_comp]  DEFAULT ((0)) FOR [super_comp]
GO

ALTER TABLE [dbo].[component] ADD  CONSTRAINT [DF_component_img]  DEFAULT ((0)) FOR [img]
GO

ALTER TABLE [dbo].[component] ADD  CONSTRAINT [DF_component_format]  DEFAULT ('') FOR [format]
GO


USE [DB_121607_nomad]
GO

/****** Object:  Table [dbo].[group_]    Script Date: 8/25/2020 3:32:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[group_](
	[ID] [numeric](4, 0) NOT NULL,
	[group_] [varchar](80) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[group_] ADD  CONSTRAINT [DF_group__ID]  DEFAULT ((0)) FOR [ID]
GO

ALTER TABLE [dbo].[group_] ADD  CONSTRAINT [DF_group__group_]  DEFAULT ('') FOR [group_]
GO

USE [DB_121607_nomad]
GO

INSERT INTO [dbo].[group_]
           ([ID]
           ,[group_])
     VALUES
           (0,
           'read'
		   )
GO

INSERT INTO [dbo].[group_]
           ([ID]
           ,[group_])
     VALUES
           (1,
           'edit'
		   )
GO

USE [DB_121607_nomad]
GO

/****** Object:  Table [dbo].[img_stg]    Script Date: 8/25/2020 3:33:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[img_stg](
	[ID] [varchar](20) NOT NULL,
	[img] [varbinary](max) NOT NULL,
	[format] [varchar](8) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[img_stg] ADD  CONSTRAINT [DF_img_stg_ID]  DEFAULT ('') FOR [ID]
GO

ALTER TABLE [dbo].[img_stg] ADD  CONSTRAINT [DF_img_stg_img]  DEFAULT ((0)) FOR [img]
GO

ALTER TABLE [dbo].[img_stg] ADD  CONSTRAINT [DF_img_stg_format]  DEFAULT ('') FOR [format]
GO

USE [DB_121607_nomad]
GO

/****** Object:  Table [dbo].[type_]    Script Date: 8/25/2020 3:34:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[type_](
	[ID] [numeric](2, 0) NOT NULL,
	[type_] [varchar](77) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[type_] ADD  CONSTRAINT [DF_type__ID]  DEFAULT ((0)) FOR [ID]
GO

ALTER TABLE [dbo].[type_] ADD  CONSTRAINT [DF_type__type_]  DEFAULT ('') FOR [type_]
GO

USE [DB_121607_nomad]
GO

INSERT INTO [dbo].[type_]
           ([ID]
           ,[type_])
     VALUES
           (1,
           'Product'
		   )
GO

INSERT INTO [dbo].[type_]
           ([ID]
           ,[type_])
     VALUES
           (2
           'Sub Product'
		   )
GO


INSERT INTO [dbo].[type_]
           ([ID]
           ,[type_])
     VALUES
           (3,
           'Piece'
		   )
GO


INSERT INTO [dbo].[type_]
           ([ID]
           ,[type_])
     VALUES
           (4,
           'Stock'
		   )
GO
