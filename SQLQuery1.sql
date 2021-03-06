
USE [CricketTicketSystem]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 02/27/2020 10:20:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[MobileNumber] [nvarchar](50) NOT NULL,
	[EmailID] [nvarchar](50) NOT NULL,
	[TicketID] [int] NOT NULL,
	[SeatID] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seat]    Script Date: 02/27/2020 10:20:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SeatNumber] [int] NOT NULL,
	[SeatSide] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Seat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 02/27/2020 10:20:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 02/27/2020 10:20:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([ID], [Name], [MobileNumber], [EmailID], [TicketID], [SeatID]) VALUES (1, N'asd', N'8427268694', N'assss', 1, 0)
GO
INSERT [dbo].[Customer] ([ID], [Name], [MobileNumber], [EmailID], [TicketID], [SeatID]) VALUES (2, N'Harshit', N'8427268694', N'assss', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Seat] ON 
GO
INSERT [dbo].[Seat] ([ID], [SeatNumber], [SeatSide]) VALUES (0, 104, N'East')
GO
INSERT [dbo].[Seat] ([ID], [SeatNumber], [SeatSide]) VALUES (1, 2, N'West')
GO
SET IDENTITY_INSERT [dbo].[Seat] OFF
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON 
GO
INSERT [dbo].[Ticket] ([ID], [Number], [Price]) VALUES (1, 5, 43)
GO
SET IDENTITY_INSERT [dbo].[Ticket] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([ID], [Name], [Email], [Password]) VALUES (1, N'admin', N'admin@gmail.com', N'admin')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Seat] FOREIGN KEY([SeatID])
REFERENCES [dbo].[Seat] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Seat]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Ticket] FOREIGN KEY([TicketID])
REFERENCES [dbo].[Ticket] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Ticket]
GO
USE [master]
GO
ALTER DATABASE [CricketTicketSystem] SET  READ_WRITE 
GO
