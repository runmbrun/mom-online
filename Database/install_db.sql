-- This is the database install script
USE [mom]
GO
/****** Object:  Table [dbo].[players]    Script Date: 02/25/2009 10:12:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[players](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NOT NULL,
	[password] [nchar](10) NOT NULL,
	[admin] [smallint] NOT NULL CONSTRAINT [DF_players_admin]  DEFAULT ((0)),	
	[online] [smallint] NOT NULL CONSTRAINT [DF_players_online]  DEFAULT ((0)),
 CONSTRAINT [PK_players] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
