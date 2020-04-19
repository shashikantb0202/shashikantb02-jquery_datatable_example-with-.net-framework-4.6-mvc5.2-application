USE [master]
GO
/****** Object:  Database [EmpAssignment]    Script Date: 4/19/2020 2:48:15 PM ******/
CREATE DATABASE [EmpAssignment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmpAssignment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EmpAssignment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmpAssignment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EmpAssignment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EmpAssignment] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmpAssignment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmpAssignment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmpAssignment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmpAssignment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmpAssignment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmpAssignment] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmpAssignment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmpAssignment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmpAssignment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmpAssignment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmpAssignment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmpAssignment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmpAssignment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmpAssignment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmpAssignment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmpAssignment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmpAssignment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmpAssignment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmpAssignment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmpAssignment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmpAssignment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmpAssignment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmpAssignment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmpAssignment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmpAssignment] SET  MULTI_USER 
GO
ALTER DATABASE [EmpAssignment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmpAssignment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmpAssignment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmpAssignment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmpAssignment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmpAssignment] SET QUERY_STORE = OFF
GO
USE [EmpAssignment]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 4/19/2020 2:48:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Age] [int] NULL,
	[Salary] [float] NULL,
	[MaritalStatus] [varchar](100) NULL,
	[Location] [varchar](100) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([Id], [Name], [Age], [Salary], [MaritalStatus], [Location]) VALUES (25, N'john', 20, 30000, N'Married', N'pune')
GO
INSERT [dbo].[Employee] ([Id], [Name], [Age], [Salary], [MaritalStatus], [Location]) VALUES (26, N'shashikant', 22, 300000, N'Married', N'pune')
GO
INSERT [dbo].[Employee] ([Id], [Name], [Age], [Salary], [MaritalStatus], [Location]) VALUES (28, N'ravi', 22, 30000, N'Married', N'pune')
GO
INSERT [dbo].[Employee] ([Id], [Name], [Age], [Salary], [MaritalStatus], [Location]) VALUES (29, N'ankit', 20, 40000, N'Unmarried', N'mumbai')
GO
INSERT [dbo].[Employee] ([Id], [Name], [Age], [Salary], [MaritalStatus], [Location]) VALUES (34, N'Samir', 26, 76000, N'Married', N'pune')
GO
INSERT [dbo].[Employee] ([Id], [Name], [Age], [Salary], [MaritalStatus], [Location]) VALUES (35, N'Rohan', 30, 64890, N'Married', N'mumbai')
GO
INSERT [dbo].[Employee] ([Id], [Name], [Age], [Salary], [MaritalStatus], [Location]) VALUES (36, N'Ashish', 28, 30000, N'Married', N'Pune')
GO
INSERT [dbo].[Employee] ([Id], [Name], [Age], [Salary], [MaritalStatus], [Location]) VALUES (37, N'Rohit', 30, 58000, N'Married', N'Mumbai')
GO
INSERT [dbo].[Employee] ([Id], [Name], [Age], [Salary], [MaritalStatus], [Location]) VALUES (38, N'shashi', 21, 20000, N'Unmarried', N'pune')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
USE [master]
GO
ALTER DATABASE [EmpAssignment] SET  READ_WRITE 
GO
