USE [master]
GO

/****** Object:  Database [StudentManagementSystemDB]    Script Date: 11/27/2020 7:09:05 PM ******/
CREATE DATABASE [StudentManagementSystemDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentPortalSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StudentPortalSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentPortalSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\StudentPortalSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentManagementSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [StudentManagementSystemDB] SET ANSI_NULL_DEFAULT ON 
GO

ALTER DATABASE [StudentManagementSystemDB] SET ANSI_NULLS ON 
GO

ALTER DATABASE [StudentManagementSystemDB] SET ANSI_PADDING ON 
GO

ALTER DATABASE [StudentManagementSystemDB] SET ANSI_WARNINGS ON 
GO

ALTER DATABASE [StudentManagementSystemDB] SET ARITHABORT ON 
GO

ALTER DATABASE [StudentManagementSystemDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [StudentManagementSystemDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [StudentManagementSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [StudentManagementSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [StudentManagementSystemDB] SET CURSOR_DEFAULT  LOCAL 
GO

ALTER DATABASE [StudentManagementSystemDB] SET CONCAT_NULL_YIELDS_NULL ON 
GO

ALTER DATABASE [StudentManagementSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [StudentManagementSystemDB] SET QUOTED_IDENTIFIER ON 
GO

ALTER DATABASE [StudentManagementSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [StudentManagementSystemDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [StudentManagementSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [StudentManagementSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [StudentManagementSystemDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [StudentManagementSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [StudentManagementSystemDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [StudentManagementSystemDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [StudentManagementSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [StudentManagementSystemDB] SET RECOVERY FULL 
GO

ALTER DATABASE [StudentManagementSystemDB] SET  MULTI_USER 
GO

ALTER DATABASE [StudentManagementSystemDB] SET PAGE_VERIFY NONE  
GO

ALTER DATABASE [StudentManagementSystemDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [StudentManagementSystemDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [StudentManagementSystemDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [StudentManagementSystemDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [StudentManagementSystemDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [StudentManagementSystemDB] SET  READ_WRITE 
GO


