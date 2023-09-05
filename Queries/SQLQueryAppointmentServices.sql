USE [ABS_Appointments]
GO
/****** Object:  Table [dbo].[AppointmentConfiguration]    Script Date: 9/6/2023 1:10:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentConfiguration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaxPerDay] [int] NOT NULL,
	[PrefixToken] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AppointmentConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 9/6/2023 1:10:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[TokenId] [int] NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedBy] [nvarchar](100) NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK__Appointm__8ECDFCC238920A07] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tokens]    Script Date: 9/6/2023 1:10:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tokens](
	[TokenId] [int] IDENTITY(1,1) NOT NULL,
	[TokenNumber] [varchar](20) NULL,
	[Status] [varchar](20) NULL,
 CONSTRAINT [PK__Tokens__658FEEEAA10B4E82] PRIMARY KEY CLUSTERED 
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Tokens__435734E1C30C3D72] UNIQUE NONCLUSTERED 
(
	[TokenNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK__Appointme__Token__35BCFE0A] FOREIGN KEY([TokenId])
REFERENCES [dbo].[Tokens] ([TokenId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK__Appointme__Token__35BCFE0A]
GO
