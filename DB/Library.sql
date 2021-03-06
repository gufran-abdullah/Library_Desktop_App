USE [Library]
GO
/****** Object:  Table [dbo].[books_info]    Script Date: 05-Sep-20 4:16:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books_info](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[book_name] [varchar](50) NULL,
	[book_author_name] [varchar](50) NULL,
	[book_publication_name] [varchar](50) NULL,
	[book_purchase_date] [date] NULL,
	[book_price] [int] NULL,
	[book_quantity] [int] NULL,
	[avaiable_qty] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[issue_books]    Script Date: 05-Sep-20 4:16:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[issue_books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[student_roll_no] [varchar](50) NULL,
	[student_name] [varchar](50) NULL,
	[student_dept] [varchar](50) NULL,
	[student_semester] [varchar](50) NULL,
	[student_contact] [varchar](50) NULL,
	[student_email] [varchar](50) NULL,
	[books_name] [varchar](50) NULL,
	[books_issue_date] [varchar](50) NULL,
	[books_return_date] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[library_person]    Script Date: 05-Sep-20 4:16:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[library_person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [varchar](50) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[contact] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[students_info]    Script Date: 05-Sep-20 4:16:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students_info](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[student_name] [varchar](50) NULL,
	[student_image] [varchar](50) NULL,
	[student_roll_no] [varchar](50) NULL,
	[student_department] [varchar](50) NULL,
	[studetnt_semester] [varchar](50) NULL,
	[student_contact] [varchar](50) NULL,
	[student_email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
