USE [CoffeeLovers]
GO
/****** Object:  Table [dbo].[tCoffee]    Script Date: 04-Feb-21 21:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tCoffee](
	[CoffeeID] [int] IDENTITY(1,1) NOT NULL,
	[CoffeeName] [varchar](50) NOT NULL,
	[CoffeeBrand] [varchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CoffeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tComment]    Script Date: 04-Feb-21 21:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tComment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [varchar](200) NOT NULL,
	[CoffeeID] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[RatingID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tLog]    Script Date: 04-Feb-21 21:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tLog](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[LogDetail] [varchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tRating]    Script Date: 04-Feb-21 21:46:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tRating](
	[RatingID] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [tinyint] NOT NULL,
	[CoffeeID] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tCoffee] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[tCoffee] ADD  CONSTRAINT [DF_tCoffee_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tComment] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[tComment] ADD  CONSTRAINT [DF_tComment_RatingID]  DEFAULT ((0)) FOR [RatingID]
GO
ALTER TABLE [dbo].[tLog] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[tRating] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[tComment]  WITH CHECK ADD  CONSTRAINT [FK_Coffee_Comment] FOREIGN KEY([CoffeeID])
REFERENCES [dbo].[tCoffee] ([CoffeeID])
GO
ALTER TABLE [dbo].[tComment] CHECK CONSTRAINT [FK_Coffee_Comment]
GO
ALTER TABLE [dbo].[tComment]  WITH CHECK ADD  CONSTRAINT [FK_tComment_tRating] FOREIGN KEY([RatingID])
REFERENCES [dbo].[tRating] ([RatingID])
GO
ALTER TABLE [dbo].[tComment] CHECK CONSTRAINT [FK_tComment_tRating]
GO
ALTER TABLE [dbo].[tRating]  WITH CHECK ADD  CONSTRAINT [FK_Coffee_Rating] FOREIGN KEY([CoffeeID])
REFERENCES [dbo].[tCoffee] ([CoffeeID])
GO
ALTER TABLE [dbo].[tRating] CHECK CONSTRAINT [FK_Coffee_Rating]
GO
