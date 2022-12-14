USE [master]
GO
/****** Object:  Database [WebsiteBanHangOnline]    Script Date: 8/29/2022 3:27:39 AM ******/
CREATE DATABASE [WebsiteBanHangOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebsiteBanHangOnline_Data', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\WebsiteBanHangOnline.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WebsiteBanHangOnline_Log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\WebsiteBanHangOnline.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WebsiteBanHangOnline] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebsiteBanHangOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebsiteBanHangOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET  MULTI_USER 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebsiteBanHangOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [WebsiteBanHangOnline] SET DELAYED_DURABILITY = DISABLED 
GO
USE [WebsiteBanHangOnline]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 8/29/2022 3:27:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Avatar] [nvarchar](100) NULL,
	[Slug] [varchar](100) NULL,
	[ShowOnHomePage] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[CreatedOnUtc] [datetime] NULL,
	[UpdateOnUtc] [datetime] NULL,
	[DeteleId] [bit] NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 8/29/2022 3:27:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Avatar] [nvarchar](100) NULL,
	[Slug] [nvarchar](100) NULL,
	[ShowOnHomePage] [bit] NULL,
	[DisplayOnUtc] [int] NULL,
	[CreatedOnUtc] [datetime] NULL,
	[UpdatedOnUtc] [datetime] NULL,
	[DeleteId] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 8/29/2022 3:27:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[UserId] [int] NULL,
	[Status] [int] NULL,
	[CreatedOnUtc] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 8/29/2022 3:27:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/29/2022 3:27:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Avatar] [nchar](100) NULL,
	[CategoryId] [int] NULL,
	[ShortDes] [nvarchar](100) NULL,
	[FullDescription] [nvarchar](100) NULL,
	[Price] [float] NULL,
	[PriceDiscount] [float] NULL,
	[TypeId] [int] NULL,
	[Slug] [varchar](50) NULL,
	[BrandId] [int] NULL,
	[DeleteId] [bit] NULL,
	[ShowOnHomePage] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[CreatedOnUtc] [datetime] NULL,
	[UpdatedOnUtc] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/29/2022 3:27:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [WebsiteBanHangOnline] SET  READ_WRITE 
GO
