/****** Object:  Table [dbo].[Feedback]    Script Date: 2/18/2016 8:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[Id] [bigint] NOT NULL,
	[TalkId] [bigint] NOT NULL,
	[Summary] [nvarchar](100) NOT NULL,
	[Comments] [nvarchar](200) NULL,
	[EntryDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Presentation]    Script Date: 2/18/2016 8:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presentation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[User] [nvarchar](100) NULL,
	[DateCreated] [datetime] NOT NULL CONSTRAINT [DF_Presentation_DateCreated]  DEFAULT (getdate()),
 CONSTRAINT [PK_Presentation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Talk]    Script Date: 2/18/2016 8:42:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Talk](
	[Id] [bigint] NOT NULL,
	[PresentationId] [bigint] NOT NULL,
	[Code] [nvarchar](5) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Lecture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Lecture] FOREIGN KEY([TalkId])
REFERENCES [dbo].[Talk] ([Id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Lecture]
GO
ALTER TABLE [dbo].[Talk]  WITH CHECK ADD  CONSTRAINT [FK_Lecture_Presentation] FOREIGN KEY([PresentationId])
REFERENCES [dbo].[Presentation] ([Id])
GO
ALTER TABLE [dbo].[Talk] CHECK CONSTRAINT [FK_Lecture_Presentation]
GO
