USE [master]
GO
/****** Object:  Database [Netflix]    Script Date: 1/2/2024 12:33:55 PM ******/
CREATE DATABASE [Netflix]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Netflix', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Netflix.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Netflix_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Netflix_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Netflix] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Netflix].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Netflix] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Netflix] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Netflix] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Netflix] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Netflix] SET ARITHABORT OFF 
GO
ALTER DATABASE [Netflix] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Netflix] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Netflix] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Netflix] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Netflix] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Netflix] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Netflix] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Netflix] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Netflix] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Netflix] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Netflix] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Netflix] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Netflix] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Netflix] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Netflix] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Netflix] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Netflix] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Netflix] SET RECOVERY FULL 
GO
ALTER DATABASE [Netflix] SET  MULTI_USER 
GO
ALTER DATABASE [Netflix] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Netflix] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Netflix] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Netflix] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Netflix] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Netflix] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Netflix', N'ON'
GO
ALTER DATABASE [Netflix] SET QUERY_STORE = ON
GO
ALTER DATABASE [Netflix] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Netflix]
GO
/****** Object:  User [TonySmehrik]    Script Date: 1/2/2024 12:33:55 PM ******/
CREATE USER [TonySmehrik] FOR LOGIN [TonySmehrik] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [HideoKojimbus]    Script Date: 1/2/2024 12:33:55 PM ******/
CREATE USER [HideoKojimbus] FOR LOGIN [HideoKojimbus] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [BobsonDugnutt]    Script Date: 1/2/2024 12:33:55 PM ******/
CREATE USER [BobsonDugnutt] FOR LOGIN [BobsonDugnutt] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [APIUser]    Script Date: 1/2/2024 12:33:55 PM ******/
CREATE USER [APIUser] FOR LOGIN [APIUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [db_viewer]    Script Date: 1/2/2024 12:33:56 PM ******/
CREATE ROLE [db_viewer]
GO
/****** Object:  DatabaseRole [db_senior]    Script Date: 1/2/2024 12:33:56 PM ******/
CREATE ROLE [db_senior]
GO
/****** Object:  DatabaseRole [db_medior]    Script Date: 1/2/2024 12:33:56 PM ******/
CREATE ROLE [db_medior]
GO
/****** Object:  DatabaseRole [db_junior]    Script Date: 1/2/2024 12:33:56 PM ******/
CREATE ROLE [db_junior]
GO
ALTER ROLE [db_junior] ADD MEMBER [TonySmehrik]
GO
ALTER ROLE [db_senior] ADD MEMBER [HideoKojimbus]
GO
ALTER ROLE [db_medior] ADD MEMBER [BobsonDugnutt]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[blocked] [bit] NULL,
	[email] [varchar](50) NULL,
	[password_hash] [varchar](72) NOT NULL,
	[activated] [bit] NULL,
	[blocked_until] [datetime] NULL,
	[language_id] [int] NOT NULL,
 CONSTRAINT [PK__User__46A222CD879216CC] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__User__AB6E61641FCEDEC6] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscription](
	[subscription_id] [int] IDENTITY(1,1) NOT NULL,
	[subscription_name] [varchar](50) NULL,
	[subscription_cost] [float] NULL,
	[quality_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[subscription_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubscriptionUser]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionUser](
	[subscription_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[date_acquired] [date] NULL,
	[price_paid] [float] NOT NULL,
	[duration_in_days] [int] NULL,
 CONSTRAINT [PK_SubscriptionUser] PRIMARY KEY CLUSTERED 
(
	[subscription_id] ASC,
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SubscriptionUserView]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SubscriptionUserView]
AS
SELECT
    SU.[user_id],
    SU.subscription_id,
    S.subscription_name,
    SU.date_acquired,
    SU.duration,
    SU.price_paid
FROM
    SubscriptionUser SU
JOIN
    [User] U ON SU.[user_id] = U.[user_id]
JOIN
    Subscription S ON SU.subscription_id = S.subscription_id;

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[employee_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password_hash] [varchar](50) NOT NULL,
	[role] [char](1) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[db_senior_User_Employee_View]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- For db_senior
CREATE VIEW [dbo].[db_senior_User_Employee_View] AS
SELECT
    'User' AS source_table,
    blocked,
    email AS user_email,
    activated,
    blocked_until,
    NULL AS name,
    NULL AS employee_email,
    NULL AS role
FROM dbo.[User]
WHERE 1 = 0 -- Exclude all rows

UNION ALL

SELECT
    'Employee' AS source_table,
    NULL AS blocked,
    NULL AS user_email,
    NULL AS activated,
    NULL AS blocked_until,
    name,
    email AS employee_email,
    role
FROM dbo.Employee
WHERE 1 = 0; -- Exclude all rows

GO
/****** Object:  Table [dbo].[Classification]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classification](
	[description] [varchar](50) NOT NULL,
	[age_rating] [int] NULL,
	[classification_id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[classification_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentClassification]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentClassification](
	[content_id] [int] NOT NULL,
	[classification_id] [int] NOT NULL,
 CONSTRAINT [PK_ContentClassification] PRIMARY KEY CLUSTERED 
(
	[content_id] ASC,
	[classification_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentGenre]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentGenre](
	[content_id] [int] NOT NULL,
	[genre_id] [int] NOT NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[content_id] ASC,
	[genre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentSession]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentSession](
	[profile_id] [int] NOT NULL,
	[episode_id] [int] NOT NULL,
	[active] [bit] NULL,
	[left_off_at] [timestamp] NULL,
	[time_watched] [float] NULL,
 CONSTRAINT [PK_ContentSession] PRIMARY KEY CLUSTERED 
(
	[profile_id] ASC,
	[episode_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentType]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentType](
	[description] [varchar](50) NULL,
	[content_type_id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[content_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Episode]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Episode](
	[length] [float] NOT NULL,
	[content_index] [int] NOT NULL,
	[episode_name] [varchar](50) NOT NULL,
	[episode_id] [int] IDENTITY(1,1) NOT NULL,
	[content_id] [int] NOT NULL,
	[season_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[episode_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EpisodeQuality]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EpisodeQuality](
	[episode_id] [int] NOT NULL,
	[quality_id] [int] NOT NULL,
 CONSTRAINT [PK_EpisodeQuality] PRIMARY KEY CLUSTERED 
(
	[episode_id] ASC,
	[quality_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FailedLoginAttempt]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FailedLoginAttempt](
	[date] [date] NOT NULL,
	[time] [time](7) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[genre] [varchar](50) NOT NULL,
	[genre_id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[genre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[language_id] [int] IDENTITY(1,1) NOT NULL,
	[language] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[language_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[profile_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[profile_image] [varchar](50) NULL,
	[profile_child] [bit] NOT NULL,
	[date_of_birth] [date] NOT NULL,
	[user_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[profile_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileClassification]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileClassification](
	[profile_id] [int] NOT NULL,
	[classification_id] [int] NOT NULL,
 CONSTRAINT [PK_ProfileClassification] PRIMARY KEY CLUSTERED 
(
	[profile_id] ASC,
	[classification_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileContentType]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileContentType](
	[profile_id] [int] NOT NULL,
	[content_type_id] [int] NOT NULL,
 CONSTRAINT [PK_ProfileContentType] PRIMARY KEY CLUSTERED 
(
	[profile_id] ASC,
	[content_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileGenre]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileGenre](
	[profile_id] [int] NOT NULL,
	[genre_id] [int] NOT NULL,
 CONSTRAINT [PK_ProfileGenre] PRIMARY KEY CLUSTERED 
(
	[profile_id] ASC,
	[genre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quality]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quality](
	[quality_id] [int] IDENTITY(1,1) NOT NULL,
	[quality_name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[quality_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Season]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Season](
	[director] [varchar](50) NULL,
	[release_date] [date] NULL,
	[season_id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[season_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubtitleContent]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubtitleContent](
	[subtitle_id] [int] NOT NULL,
	[subtitle_location] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SubtitleContent] PRIMARY KEY CLUSTERED 
(
	[subtitle_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TextItem]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TextItem](
	[text_item_id] [int] NOT NULL,
	[on_page_text_id] [int] NULL,
 CONSTRAINT [PK_TextItem] PRIMARY KEY CLUSTERED 
(
	[text_item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TextItemLanguage]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TextItemLanguage](
	[language_id] [int] NOT NULL,
	[text_item_id] [int] NOT NULL,
	[content] [varchar](50) NULL,
 CONSTRAINT [PK_TextItemLanguage] PRIMARY KEY CLUSTERED 
(
	[language_id] ASC,
	[text_item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserHasInvited]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserHasInvited](
	[user_id] [int] NOT NULL,
	[invited_user_id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WantToWatch]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WantToWatch](
	[profile_id] [int] NOT NULL,
	[content_id] [int] NOT NULL,
	[watched] [bit] NULL,
 CONSTRAINT [PK_WantToWatch] PRIMARY KEY CLUSTERED 
(
	[profile_id] ASC,
	[content_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WatchableContent]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WatchableContent](
	[title] [varchar](50) NOT NULL,
	[description] [varchar](50) NOT NULL,
	[release_date] [date] NOT NULL,
	[age_rating] [int] NOT NULL,
	[episodes] [int] NULL,
	[director] [varchar](50) NOT NULL,
	[cover_image] [varchar](50) NOT NULL,
	[content_type_id] [int] NOT NULL,
	[content_id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[content_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ContentClassification]  WITH CHECK ADD  CONSTRAINT [FK_Content_Classification_Classification] FOREIGN KEY([classification_id])
REFERENCES [dbo].[Classification] ([classification_id])
GO
ALTER TABLE [dbo].[ContentClassification] CHECK CONSTRAINT [FK_Content_Classification_Classification]
GO
ALTER TABLE [dbo].[ContentGenre]  WITH CHECK ADD  CONSTRAINT [FK_Content_Genre_Genre] FOREIGN KEY([genre_id])
REFERENCES [dbo].[Genre] ([genre_id])
GO
ALTER TABLE [dbo].[ContentGenre] CHECK CONSTRAINT [FK_Content_Genre_Genre]
GO
ALTER TABLE [dbo].[ContentSession]  WITH CHECK ADD  CONSTRAINT [FK_Content_Session_Profile] FOREIGN KEY([profile_id])
REFERENCES [dbo].[Profile] ([profile_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContentSession] CHECK CONSTRAINT [FK_Content_Session_Profile]
GO
ALTER TABLE [dbo].[Episode]  WITH CHECK ADD  CONSTRAINT [FK_Episode_Content] FOREIGN KEY([content_id])
REFERENCES [dbo].[WatchableContent] ([content_id])
GO
ALTER TABLE [dbo].[Episode] CHECK CONSTRAINT [FK_Episode_Content]
GO
ALTER TABLE [dbo].[Episode]  WITH CHECK ADD  CONSTRAINT [FK_Episode_Season] FOREIGN KEY([season_id])
REFERENCES [dbo].[Season] ([season_id])
GO
ALTER TABLE [dbo].[Episode] CHECK CONSTRAINT [FK_Episode_Season]
GO
ALTER TABLE [dbo].[EpisodeQuality]  WITH CHECK ADD  CONSTRAINT [FK_Episode_Quality_Quality] FOREIGN KEY([quality_id])
REFERENCES [dbo].[Quality] ([quality_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EpisodeQuality] CHECK CONSTRAINT [FK_Episode_Quality_Quality]
GO
ALTER TABLE [dbo].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Profile] CHECK CONSTRAINT [FK_Profile_User]
GO
ALTER TABLE [dbo].[ProfileClassification]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Classification_Classification] FOREIGN KEY([classification_id])
REFERENCES [dbo].[Classification] ([classification_id])
GO
ALTER TABLE [dbo].[ProfileClassification] CHECK CONSTRAINT [FK_Profile_Classification_Classification]
GO
ALTER TABLE [dbo].[ProfileClassification]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Classification_Profile] FOREIGN KEY([profile_id])
REFERENCES [dbo].[Profile] ([profile_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProfileClassification] CHECK CONSTRAINT [FK_Profile_Classification_Profile]
GO
ALTER TABLE [dbo].[ProfileContentType]  WITH CHECK ADD  CONSTRAINT [FK_Profile_ContentType_ContentType] FOREIGN KEY([content_type_id])
REFERENCES [dbo].[ContentType] ([content_type_id])
GO
ALTER TABLE [dbo].[ProfileContentType] CHECK CONSTRAINT [FK_Profile_ContentType_ContentType]
GO
ALTER TABLE [dbo].[ProfileContentType]  WITH CHECK ADD  CONSTRAINT [FK_Profile_ContentType_Profile] FOREIGN KEY([profile_id])
REFERENCES [dbo].[Profile] ([profile_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProfileContentType] CHECK CONSTRAINT [FK_Profile_ContentType_Profile]
GO
ALTER TABLE [dbo].[ProfileGenre]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Genre_Genre] FOREIGN KEY([genre_id])
REFERENCES [dbo].[Genre] ([genre_id])
GO
ALTER TABLE [dbo].[ProfileGenre] CHECK CONSTRAINT [FK_Profile_Genre_Genre]
GO
ALTER TABLE [dbo].[ProfileGenre]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Genre_Profile] FOREIGN KEY([profile_id])
REFERENCES [dbo].[Profile] ([profile_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProfileGenre] CHECK CONSTRAINT [FK_Profile_Genre_Profile]
GO
ALTER TABLE [dbo].[Subscription]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_Quality] FOREIGN KEY([quality_id])
REFERENCES [dbo].[Quality] ([quality_id])
GO
ALTER TABLE [dbo].[Subscription] CHECK CONSTRAINT [FK_Subscription_Quality]
GO
ALTER TABLE [dbo].[SubscriptionUser]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_User_Subscription] FOREIGN KEY([subscription_id])
REFERENCES [dbo].[Subscription] ([subscription_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubscriptionUser] CHECK CONSTRAINT [FK_Subscription_User_Subscription]
GO
ALTER TABLE [dbo].[SubscriptionUser]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_User_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubscriptionUser] CHECK CONSTRAINT [FK_Subscription_User_User]
GO
ALTER TABLE [dbo].[SubtitleContent]  WITH CHECK ADD  CONSTRAINT [FK_SubtitleContent_Language] FOREIGN KEY([subtitle_id])
REFERENCES [dbo].[Language] ([language_id])
GO
ALTER TABLE [dbo].[SubtitleContent] CHECK CONSTRAINT [FK_SubtitleContent_Language]
GO
ALTER TABLE [dbo].[TextItemLanguage]  WITH CHECK ADD  CONSTRAINT [FK_TextItem_Language_Language] FOREIGN KEY([language_id])
REFERENCES [dbo].[Language] ([language_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TextItemLanguage] CHECK CONSTRAINT [FK_TextItem_Language_Language]
GO
ALTER TABLE [dbo].[TextItemLanguage]  WITH CHECK ADD  CONSTRAINT [FK_TextItem_Language_TextItem] FOREIGN KEY([text_item_id])
REFERENCES [dbo].[TextItem] ([text_item_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TextItemLanguage] CHECK CONSTRAINT [FK_TextItem_Language_TextItem]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Language] FOREIGN KEY([language_id])
REFERENCES [dbo].[Language] ([language_id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Language]
GO
ALTER TABLE [dbo].[UserHasInvited]  WITH CHECK ADD  CONSTRAINT [FK_Invitee_User] FOREIGN KEY([invited_user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[UserHasInvited] CHECK CONSTRAINT [FK_Invitee_User]
GO
ALTER TABLE [dbo].[UserHasInvited]  WITH CHECK ADD  CONSTRAINT [FK_Inviter_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[UserHasInvited] CHECK CONSTRAINT [FK_Inviter_User]
GO
ALTER TABLE [dbo].[WantToWatch]  WITH CHECK ADD  CONSTRAINT [FK_WantToWatch_Profile_Profile] FOREIGN KEY([profile_id])
REFERENCES [dbo].[Profile] ([profile_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WantToWatch] CHECK CONSTRAINT [FK_WantToWatch_Profile_Profile]
GO
ALTER TABLE [dbo].[WatchableContent]  WITH CHECK ADD  CONSTRAINT [FK_WatchableContent_ContentType] FOREIGN KEY([content_type_id])
REFERENCES [dbo].[ContentType] ([content_type_id])
GO
ALTER TABLE [dbo].[WatchableContent] CHECK CONSTRAINT [FK_WatchableContent_ContentType]
GO
/****** Object:  StoredProcedure [dbo].[BackupNetflixDatabaseFullCompressed]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BackupNetflixDatabaseFullCompressed]
AS
BEGIN
	ALTER DATABASE Netflix SET RECOVERY FULL;
	BACKUP DATABASE Netflix 
		TO DISK = 'C:\SQLBackup\Netflix\NetflixFull_Compressed.bak'
		WITH INIT, COMPRESSION;
	BACKUP LOG Netflix
		TO DISK = 'C:\SQLBackup\Netflix\NetflixFull_Compressed.bak';
END;

GO
/****** Object:  StoredProcedure [dbo].[GetUserEmployeeView]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserEmployeeView]
    @inputEmail NVARCHAR(255),
    @inputPasswordHash NVARCHAR(255),
    @outputFormat NVARCHAR(10) = 'JSON' -- Default to JSON
AS
BEGIN
    SET NOCOUNT ON;

    IF @outputFormat = 'JSON'
    BEGIN
        SELECT
            email AS name,
            password_hash,
            role
        FROM
            (
                SELECT
                    email,
                    password_hash,
                    'Employee' AS role
                FROM
                    Employee
                WHERE
                    email = @inputEmail AND password_hash = @inputPasswordHash
            
                UNION ALL
            
                SELECT
                    email,
                    password_hash,
                    NULL AS role
                FROM
                    [User]
                WHERE
                    email = @inputEmail AND password_hash = @inputPasswordHash
            ) AS CombinedData
        FOR JSON AUTO;
    END
    ELSE IF @outputFormat = 'XML'
    BEGIN
        SELECT
            email AS 'name',
            password_hash,
            role
        FROM
            (
                SELECT
                    email,
                    password_hash,
                    'Employee' AS role
                FROM
                    Employee
                WHERE
                    email = @inputEmail AND password_hash = @inputPasswordHash
            
                UNION ALL
            
                SELECT
                    email,
                    password_hash,
                    NULL AS role
                FROM
                    [User]
                WHERE
                    email = @inputEmail AND password_hash = @inputPasswordHash
            ) AS CombinedData
        FOR XML AUTO, ROOT('Root');
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[RestoreNetflixDatabase]    Script Date: 1/2/2024 12:33:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RestoreNetflixDatabase]
AS
BEGIN
    RESTORE DATABASE YourDatabase FROM DISK = 'C:\SQLBackup\Netflix\NetflixFull_Compressed.bak' WITH REPLACE;
END;

GO
USE [master]
GO
ALTER DATABASE [Netflix] SET  READ_WRITE 
GO
