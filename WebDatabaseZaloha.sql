USE [master]
GO
/****** Object:  Database [dbBetterSpotify]    Script Date: 17.01.2024 19:38:25 ******/
CREATE DATABASE [dbBetterSpotify]

ALTER DATABASE [dbBetterSpotify] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbBetterSpotify].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbBetterSpotify] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbBetterSpotify] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbBetterSpotify] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbBetterSpotify] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbBetterSpotify] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET RECOVERY FULL 
GO
ALTER DATABASE [dbBetterSpotify] SET  MULTI_USER 
GO
ALTER DATABASE [dbBetterSpotify] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbBetterSpotify] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbBetterSpotify] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbBetterSpotify] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbBetterSpotify] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbBetterSpotify] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbBetterSpotify] SET QUERY_STORE = OFF
GO
USE [dbBetterSpotify]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17.01.2024 19:38:26 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbAlbum]    Script Date: 17.01.2024 19:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbAlbum](
	[IdAlbum] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](2000) NULL,
	[ImageFile] [varchar](500) NOT NULL,
	[DateOfPublish] [date] NOT NULL,
 CONSTRAINT [PK_TbAlbum] PRIMARY KEY CLUSTERED 
(
	[IdAlbum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbArtist]    Script Date: 17.01.2024 19:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbArtist](
	[IdArtist] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Description] [varchar](5000) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[ActiveFrom] [date] NOT NULL,
	[ActiveTo] [date] NULL,
	[ImageFile] [varchar](100) NOT NULL,
	[WikiLink] [varchar](500) NULL,
 CONSTRAINT [PK_TbArtist] PRIMARY KEY CLUSTERED 
(
	[IdArtist] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbCategory]    Script Date: 17.01.2024 19:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbCategory](
	[IdCategory] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ColorHex] [varchar](6) NOT NULL,
	[ImageFile] [varchar](500) NULL,
 CONSTRAINT [PK_TbCategory] PRIMARY KEY CLUSTERED 
(
	[IdCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbRoles]    Script Date: 17.01.2024 19:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbRoles](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ColorHex] [varchar](6) NOT NULL,
	[Prefix] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tbRoles] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TbSong]    Script Date: 17.01.2024 19:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TbSong](
	[IdSong] [int] IDENTITY(1,1) NOT NULL,
	[IdAlbum] [int] NULL,
	[IdUser] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[DiscNo] [int] NULL,
	[TrackNo] [int] NULL,
	[Duration] [int] NOT NULL,
	[ImageFile] [varchar](500) NOT NULL,
	[DateOfRelease] [date] NOT NULL,
	[IdCategory] [int] NOT NULL,
	[SongFile] [varchar](500) NOT NULL,
	[NoCopyRight] [bit] NOT NULL,
	[Verified] [bit] NOT NULL,
 CONSTRAINT [PK_TbSong] PRIMARY KEY CLUSTERED 
(
	[IdSong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbUsers]    Script Date: 17.01.2024 19:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUsers](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[IdRole] [int] NULL,
	[IdArtist] [int] NULL,
	[IdUserProfile] [int] NULL,
	[IdTokenWallet] [int] NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[NickName] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Country] [varchar](50) NULL,
	[AddId] [varchar](4) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[DateOfRegistration] [date] NOT NULL,
	[Password] [varchar](1000) NOT NULL,
	[ActiveAccount] [bit] NOT NULL,
	[Verified] [bit] NOT NULL,
	[ImageFile] [varchar](500) NOT NULL,
 CONSTRAINT [PK_tbUsers] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230218110403_Inital', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230218111840_AddCategoryAndModefiedSong', N'7.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230222083126_FixesOnCategoriesAddSongFile', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230312194144_LongerPictureFiles', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230315142339_addSongValidationAndCopyRight', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230320200217_LongerPasswordsUser', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230612174445_AddRoles', N'7.0.3')
GO
SET IDENTITY_INSERT [dbo].[TbAlbum] ON 

INSERT [dbo].[TbAlbum] ([IdAlbum], [IdUser], [Title], [Description], [ImageFile], [DateOfPublish]) VALUES (1, 2, N'Super Duper', N'Nejlepsi album', N'neco', CAST(N'2023-03-14' AS Date))
INSERT [dbo].[TbAlbum] ([IdAlbum], [IdUser], [Title], [Description], [ImageFile], [DateOfPublish]) VALUES (2, 2, N'Neni Super Duper', N'Ale je jeste lepsi jak super duper', N'neco', CAST(N'2023-03-14' AS Date))
INSERT [dbo].[TbAlbum] ([IdAlbum], [IdUser], [Title], [Description], [ImageFile], [DateOfPublish]) VALUES (3, 2, N'Super NCS', NULL, N'\images\AlbumPics\Album_8f448339-4d4d-4045-85b4-c6b727236e03.jpg', CAST(N'2023-03-18' AS Date))
SET IDENTITY_INSERT [dbo].[TbAlbum] OFF
GO
SET IDENTITY_INSERT [dbo].[TbCategory] ON 

INSERT [dbo].[TbCategory] ([IdCategory], [Name], [ColorHex], [ImageFile]) VALUES (1, N'Pop', N'1ed760', NULL)
INSERT [dbo].[TbCategory] ([IdCategory], [Name], [ColorHex], [ImageFile]) VALUES (2, N'Electronic', N'5474b6', NULL)
INSERT [dbo].[TbCategory] ([IdCategory], [Name], [ColorHex], [ImageFile]) VALUES (3, N'Rock', N'e05861', NULL)
INSERT [dbo].[TbCategory] ([IdCategory], [Name], [ColorHex], [ImageFile]) VALUES (4, N'Oliver Hruban', N'111111', N'\images\CategoryPics\caa85715-8381-4235-930c-9f1e52bf867dCategoryPics.png')
SET IDENTITY_INSERT [dbo].[TbCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[TbSong] ON 

INSERT [dbo].[TbSong] ([IdSong], [IdAlbum], [IdUser], [Title], [DiscNo], [TrackNo], [Duration], [ImageFile], [DateOfRelease], [IdCategory], [SongFile], [NoCopyRight], [Verified]) VALUES (4, NULL, 2, N'A World Away', NULL, NULL, 202, N'Electronic/AWorldAway.png', CAST(N'2016-02-13' AS Date), 2, N'Electronic/AWorldAway.mp3', 0, 0)
INSERT [dbo].[TbSong] ([IdSong], [IdAlbum], [IdUser], [Title], [DiscNo], [TrackNo], [Duration], [ImageFile], [DateOfRelease], [IdCategory], [SongFile], [NoCopyRight], [Verified]) VALUES (6, NULL, 2, N'Memories', NULL, NULL, 173, N'Pop/BEAUZMemories.png', CAST(N'2020-03-10' AS Date), 1, N'Pop/BEAUZMemories.mp3', 0, 0)
INSERT [dbo].[TbSong] ([IdSong], [IdAlbum], [IdUser], [Title], [DiscNo], [TrackNo], [Duration], [ImageFile], [DateOfRelease], [IdCategory], [SongFile], [NoCopyRight], [Verified]) VALUES (7, NULL, 2, N'Dissipate', NULL, NULL, 199, N'Rock/EvertideDissipate.png', CAST(N'2021-02-25' AS Date), 3, N'Rock/EvertideDissipate.mp3', 0, 0)
INSERT [dbo].[TbSong] ([IdSong], [IdAlbum], [IdUser], [Title], [DiscNo], [TrackNo], [Duration], [ImageFile], [DateOfRelease], [IdCategory], [SongFile], [NoCopyRight], [Verified]) VALUES (11, NULL, 2, N'C U Again (feat. Mikk Mae)', NULL, NULL, 203, N'\images\SongPics\Song_502ffcaa-37ce-4011-a729-c30e5705aaad.jpg', CAST(N'2023-03-15' AS Date), 2, N'Electronic/Electronic_e80a897a-1184-48c4-ad56-a6ef97525f58.mp3', 1, 1)
INSERT [dbo].[TbSong] ([IdSong], [IdAlbum], [IdUser], [Title], [DiscNo], [TrackNo], [Duration], [ImageFile], [DateOfRelease], [IdCategory], [SongFile], [NoCopyRight], [Verified]) VALUES (12, 3, 2, N'Imma Killa', NULL, NULL, 0, N'', CAST(N'2023-03-15' AS Date), 2, N'', 1, 1)
SET IDENTITY_INSERT [dbo].[TbSong] OFF
GO
SET IDENTITY_INSERT [dbo].[tbUsers] ON 

INSERT [dbo].[tbUsers] ([IdUser], [IdRole], [IdArtist], [IdUserProfile], [IdTokenWallet], [FirstName], [LastName], [NickName], [Email], [Country], [AddId], [DateOfBirth], [DateOfRegistration], [Password], [ActiveAccount], [Verified], [ImageFile]) VALUES (2, NULL, NULL, NULL, NULL, N'Jakub', N'Boháček', N'Jbohacek', N'jbohacek@email.cz', N'Czech', N'4635', CAST(N'2004-02-12' AS Date), CAST(N'2023-03-19' AS Date), N'123456', 1, 0, N'path')
INSERT [dbo].[tbUsers] ([IdUser], [IdRole], [IdArtist], [IdUserProfile], [IdTokenWallet], [FirstName], [LastName], [NickName], [Email], [Country], [AddId], [DateOfBirth], [DateOfRegistration], [Password], [ActiveAccount], [Verified], [ImageFile]) VALUES (1006, NULL, NULL, NULL, NULL, N'Daniel', N'Panáček', N'Daniel1313', N'panacekdaniel@sssvt.cz', N'Czech', N'1000', CAST(N'2004-04-29' AS Date), CAST(N'2023-03-14' AS Date), N'Y3JAw2CrmzUIbLJknI4F81fJ+FrYzRl3iOE+LjXyxLk=', 0, 0, N'\images\ProfilePics\fd1e610e-734b-4b7e-ad88-d3a8fbbff9cfProfilePic.jpg')
INSERT [dbo].[tbUsers] ([IdUser], [IdRole], [IdArtist], [IdUserProfile], [IdTokenWallet], [FirstName], [LastName], [NickName], [Email], [Country], [AddId], [DateOfBirth], [DateOfRegistration], [Password], [ActiveAccount], [Verified], [ImageFile]) VALUES (1012, NULL, NULL, NULL, NULL, N'Adam', N'Kouzelník', N'jupik12', N'kouz@neco.cz', N'Germany', N'2751', CAST(N'1998-01-25' AS Date), CAST(N'2023-05-30' AS Date), N'gqhlFu1Skvnngbzhy+utdfhdRabcVUg9nL8EN/L+AvA=:mvYKfN5VQbeTCdiVrmBmog==:+7MN67WH5pnQaIPCOctayHIUnSbSBu3QUa5DxeMUxDfc4lMCG7PuSqg23jEI6KKgrtq4FY3WYhZEfpLFnn07k62HkyD1hWM8DPeWuHTUUE/84RuUObRte9laVAJ+LSHn', 1, 0, N'\images\ProfilePics\6f9d3404-e73f-40b2-96e2-1ca9e41034b7ProfilePic.jpg')
INSERT [dbo].[tbUsers] ([IdUser], [IdRole], [IdArtist], [IdUserProfile], [IdTokenWallet], [FirstName], [LastName], [NickName], [Email], [Country], [AddId], [DateOfBirth], [DateOfRegistration], [Password], [ActiveAccount], [Verified], [ImageFile]) VALUES (1013, NULL, NULL, NULL, NULL, N'dsaf', N'fdsa', N'dd', N'aaaaaaaaaaaaaaaaaa@fdsa.cz', N'eff', N'8684', CAST(N'0001-01-01' AS Date), CAST(N'2023-06-13' AS Date), N'2DXObpl6NHDHSLSIwrIAGSb9P71NO7HErwmLC9qw65A=:jEHX3RsRfjrMnvqhAcfbyQ==:j+ilpssMYadBrk81zlpETdUfA8iJY2rDhCU3nmGng4zmTvtTQ7wShm5ItfGfOW7BMxTMiU1/YaNrY2U0Dxh5V/hbwCPQhMpxLxckfrxD+owGWtCskdiOKTeaiPwFjC4I', 0, 0, N'Resources/Image/DefaultUserPic')
SET IDENTITY_INSERT [dbo].[tbUsers] OFF
GO
/****** Object:  Index [IX_TbAlbum_IdUser]    Script Date: 17.01.2024 19:38:27 ******/
CREATE NONCLUSTERED INDEX [IX_TbAlbum_IdUser] ON [dbo].[TbAlbum]
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TbArtist_IdUser]    Script Date: 17.01.2024 19:38:27 ******/
CREATE NONCLUSTERED INDEX [IX_TbArtist_IdUser] ON [dbo].[TbArtist]
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TbSong_IdAlbum]    Script Date: 17.01.2024 19:38:27 ******/
CREATE NONCLUSTERED INDEX [IX_TbSong_IdAlbum] ON [dbo].[TbSong]
(
	[IdAlbum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TbSong_IdCategory]    Script Date: 17.01.2024 19:38:27 ******/
CREATE NONCLUSTERED INDEX [IX_TbSong_IdCategory] ON [dbo].[TbSong]
(
	[IdCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TbSong_IdUser]    Script Date: 17.01.2024 19:38:27 ******/
CREATE NONCLUSTERED INDEX [IX_TbSong_IdUser] ON [dbo].[TbSong]
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbUsers_IdArtist]    Script Date: 17.01.2024 19:38:27 ******/
CREATE NONCLUSTERED INDEX [IX_tbUsers_IdArtist] ON [dbo].[tbUsers]
(
	[IdArtist] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_tbUsers_IdRole]    Script Date: 17.01.2024 19:38:27 ******/
CREATE NONCLUSTERED INDEX [IX_tbUsers_IdRole] ON [dbo].[tbUsers]
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TbSong] ADD  DEFAULT (CONVERT([bit],(0))) FOR [NoCopyRight]
GO
ALTER TABLE [dbo].[TbSong] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Verified]
GO
ALTER TABLE [dbo].[TbAlbum]  WITH CHECK ADD  CONSTRAINT [FK_TbAlbum_tbUsers_IdUser] FOREIGN KEY([IdUser])
REFERENCES [dbo].[tbUsers] ([IdUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TbAlbum] CHECK CONSTRAINT [FK_TbAlbum_tbUsers_IdUser]
GO
ALTER TABLE [dbo].[TbArtist]  WITH CHECK ADD  CONSTRAINT [FK_TbArtist_tbUsers_IdUser] FOREIGN KEY([IdUser])
REFERENCES [dbo].[tbUsers] ([IdUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TbArtist] CHECK CONSTRAINT [FK_TbArtist_tbUsers_IdUser]
GO
ALTER TABLE [dbo].[TbSong]  WITH CHECK ADD  CONSTRAINT [FK_TbSong_TbAlbum_IdAlbum] FOREIGN KEY([IdAlbum])
REFERENCES [dbo].[TbAlbum] ([IdAlbum])
GO
ALTER TABLE [dbo].[TbSong] CHECK CONSTRAINT [FK_TbSong_TbAlbum_IdAlbum]
GO
ALTER TABLE [dbo].[TbSong]  WITH CHECK ADD  CONSTRAINT [FK_TbSong_TbCategory_IdCategory] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[TbCategory] ([IdCategory])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TbSong] CHECK CONSTRAINT [FK_TbSong_TbCategory_IdCategory]
GO
ALTER TABLE [dbo].[TbSong]  WITH CHECK ADD  CONSTRAINT [FK_TbSong_tbUsers_IdUser] FOREIGN KEY([IdUser])
REFERENCES [dbo].[tbUsers] ([IdUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TbSong] CHECK CONSTRAINT [FK_TbSong_tbUsers_IdUser]
GO
ALTER TABLE [dbo].[tbUsers]  WITH CHECK ADD  CONSTRAINT [FK_tbUsers_TbArtist_IdArtist] FOREIGN KEY([IdArtist])
REFERENCES [dbo].[TbArtist] ([IdArtist])
GO
ALTER TABLE [dbo].[tbUsers] CHECK CONSTRAINT [FK_tbUsers_TbArtist_IdArtist]
GO
ALTER TABLE [dbo].[tbUsers]  WITH CHECK ADD  CONSTRAINT [FK_tbUsers_tbRoles_IdRole] FOREIGN KEY([IdRole])
REFERENCES [dbo].[tbRoles] ([IdRole])
GO
ALTER TABLE [dbo].[tbUsers] CHECK CONSTRAINT [FK_tbUsers_tbRoles_IdRole]
GO
USE [master]
GO
ALTER DATABASE [dbBetterSpotify] SET  READ_WRITE 
GO
