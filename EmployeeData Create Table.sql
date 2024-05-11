USE [Staging]
GO

/****** Object:  Table [dbo].[EmployeeData]    Script Date: 5/8/2024 3:26:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeData](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Employee First Name] [nvarchar](250) NOT NULL,
	[Employee Last Name] [nvarchar](250) NOT NULL,
	[Department] [nvarchar](500) NOT NULL,
	[Role] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_EmployeeData] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


