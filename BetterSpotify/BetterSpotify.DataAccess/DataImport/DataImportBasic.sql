use dbBetterSpotify

INSERT [dbo].[TbCategory] ([IdCategory], [Name], [ColorHex], [ImageFile]) VALUES (1, N'Pop', N'1ed760', NULL)
GO
INSERT [dbo].[TbCategory] ([IdCategory], [Name], [ColorHex], [ImageFile]) VALUES (2, N'Electronic', N'5474b6', NULL)
GO
INSERT [dbo].[TbCategory] ([IdCategory], [Name], [ColorHex], [ImageFile]) VALUES (3, N'Rock', N'e05861', NULL)
GO

INSERT [dbo].[tbUsers] ([IdUser], [IdRole], [IdArtist], [IdUserProfile], [IdTokenWallet], [FirstName], [LastName], [NickName], [Email], [Country], [AddId], [DateOfBirth], [DateOfRegistration], [Password], [ActiveAccount], [Verified], [ImageFile]) VALUES (1, NULL, NULL, NULL, NULL, N'Jakub', N'Bohácek', N'Jbohacek', N'jbohacek@email.cz', N'Czech Republic', N'1111', CAST(N'2004-02-24' AS Date), CAST(N'2023-03-07' AS Date), N'123456', 1, 1, N'Null')
GO

INSERT [dbo].[TbSong] ([IdSong], [IdAlbum], [IdUser], [Title], [DiscNo], [TrackNo], [Duration], [ImageFile], [DateOfRelease], [IdCategory], [SongFile]) VALUES (1, NULL, 1, N'A World Away', NULL, NULL, 202, N'Electronic/AWorldAway.png', CAST(N'2016-02-13' AS Date), 2, N'Electronic/AWorldAway.mp3')
GO
INSERT [dbo].[TbSong] ([IdSong], [IdAlbum], [IdUser], [Title], [DiscNo], [TrackNo], [Duration], [ImageFile], [DateOfRelease], [IdCategory], [SongFile]) VALUES (2, NULL, 1, N'Memories', NULL, NULL, 173, N'Pop/BEAUZMemories.png', CAST(N'2020-03-10' AS Date), 1, N'Pop/BEAUZMemories.mp3')
GO
INSERT [dbo].[TbSong] ([IdSong], [IdAlbum], [IdUser], [Title], [DiscNo], [TrackNo], [Duration], [ImageFile], [DateOfRelease], [IdCategory], [SongFile]) VALUES (3, NULL, 1, N'Dissipate', NULL, NULL, 199, N'Rock/EvertideDissipate.png', CAST(N'2021-02-25' AS Date), 3, N'Rock/EvertideDissipate.mp3')
GO