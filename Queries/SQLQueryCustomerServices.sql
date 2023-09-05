USE [ABS_Customers]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9/6/2023 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[CreatedBy] [nvarchar](100) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedBy] [nvarchar](100) NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK__Customer__A4AE64D8CC2CDF48] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
