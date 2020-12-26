
------------------------------------------

CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](200) NULL,
	[Email] [varchar](1000) NULL,
	[Alias] [varchar](1000) NULL,
	[FirstName] [varchar](1000) NULL,
	[LastName] [varchar](1000) NULL,
	[Position] [varchar](1000) NULL,
	[Level] [int] NULL,
	[MgrId] [int] NULL,
 CONSTRAINT [PK_Domain.Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-------------------------------------------------------
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Alias], [FirstName], [LastName], [Position], [Level], [MgrId]) VALUES (1, N'Karthik', N'karthikyanamala5@gmail.com', N'karthi', N'Karthik', N'Reddy', N'Junior', 0, 0)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Alias], [FirstName], [LastName], [Position], [Level], [MgrId]) VALUES (2, N'manager2', N'karthik@gmail.com', N'karthi', N'Karthik', N'Y', N'Senior', 0, 0)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Alias], [FirstName], [LastName], [Position], [Level], [MgrId]) VALUES (3, N'Client1', N'Client1@gmail.com', N'Client', N'Client1', N'Y', NULL, 1, 1)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Alias], [FirstName], [LastName], [Position], [Level], [MgrId]) VALUES (4, N'Client2', N'Client2@gmail.com', N'Client', N'Client2', N'Y', NULL, 2, 2)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Alias], [FirstName], [LastName], [Position], [Level], [MgrId]) VALUES (5, N'Client3', N'Client3@gmail.com', N'Client', N'Client3', N'Y', NULL, 2, 1)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Alias], [FirstName], [LastName], [Position], [Level], [MgrId]) VALUES (6, N'Clint4', N'Clint4@gmail.com', N'Clint', N'Clint4', N'C', NULL, 2, 2)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Alias], [FirstName], [LastName], [Position], [Level], [MgrId]) VALUES (8, N'Client5', N'Client5@gmail.com', N'Client5', N'Client5', N'Y', NULL, 3, 2)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
-----------------------------------------------------------
