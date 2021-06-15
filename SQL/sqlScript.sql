USE [DeliveryService ]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 15.06.2021 20:28:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Address_Id] [bigint] NOT NULL,
	[Streer_Id] [bigint] NOT NULL,
	[House_Number] [int] NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Address_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 15.06.2021 20:28:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Client_Id] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Second_Name] [nvarchar](50) NOT NULL,
	[Phone] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Client_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryMans]    Script Date: 15.06.2021 20:28:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryMans](
	[DeliveryMan_Id] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Second_Name] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_DeliveryMans] PRIMARY KEY CLUSTERED 
(
	[DeliveryMan_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 15.06.2021 20:28:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foods](
	[Food_id] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Type_Id] [bigint] NOT NULL,
	[Price] [money] NOT NULL,
	[Manufacturer_Id] [bigint] NOT NULL,
	[Weight] [float] NOT NULL,
 CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED 
(
	[Food_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodTypes]    Script Date: 15.06.2021 20:28:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodTypes](
	[FoodType_Id] [bigint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_FoodTypes] PRIMARY KEY CLUSTERED 
(
	[FoodType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturers]    Script Date: 15.06.2021 20:28:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturers](
	[Manufacturer_Id] [bigint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](10) NOT NULL,
	[Address_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[Manufacturer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Food]    Script Date: 15.06.2021 20:28:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Food](
	[Food_id] [bigint] NOT NULL,
	[Order_id] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 15.06.2021 20:28:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Order_Id] [bigint] NOT NULL,
	[Client_Id] [bigint] NOT NULL,
	[Address_Id] [bigint] NOT NULL,
	[Status_Id] [bigint] NOT NULL,
	[Date] [datetime] NOT NULL,
	[DeliveryMan_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Order_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatuses]    Script Date: 15.06.2021 20:28:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatuses](
	[OrderStatus_Id] [bigint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OrderStatuses] PRIMARY KEY CLUSTERED 
(
	[OrderStatus_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Streets]    Script Date: 15.06.2021 20:28:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Streets](
	[Street_Id] [bigint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_Streets] PRIMARY KEY CLUSTERED 
(
	[Street_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Streets] FOREIGN KEY([Streer_Id])
REFERENCES [dbo].[Streets] ([Street_Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Streets]
GO
ALTER TABLE [dbo].[Foods]  WITH CHECK ADD  CONSTRAINT [FK_Foods_FoodTypes] FOREIGN KEY([Type_Id])
REFERENCES [dbo].[FoodTypes] ([FoodType_Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Foods] CHECK CONSTRAINT [FK_Foods_FoodTypes]
GO
ALTER TABLE [dbo].[Foods]  WITH CHECK ADD  CONSTRAINT [FK_Foods_Manufacturers] FOREIGN KEY([Manufacturer_Id])
REFERENCES [dbo].[Manufacturers] ([Manufacturer_Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Foods] CHECK CONSTRAINT [FK_Foods_Manufacturers]
GO
ALTER TABLE [dbo].[Manufacturers]  WITH CHECK ADD  CONSTRAINT [FK_Manufacturers_Addresses] FOREIGN KEY([Address_Id])
REFERENCES [dbo].[Addresses] ([Address_Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Manufacturers] CHECK CONSTRAINT [FK_Manufacturers_Addresses]
GO
ALTER TABLE [dbo].[Order_Food]  WITH CHECK ADD  CONSTRAINT [FK_Order_Food_Foods] FOREIGN KEY([Food_id])
REFERENCES [dbo].[Foods] ([Food_id])
GO
ALTER TABLE [dbo].[Order_Food] CHECK CONSTRAINT [FK_Order_Food_Foods]
GO
ALTER TABLE [dbo].[Order_Food]  WITH CHECK ADD  CONSTRAINT [FK_Order_Food_Orders] FOREIGN KEY([Order_id])
REFERENCES [dbo].[Orders] ([Order_Id])
GO
ALTER TABLE [dbo].[Order_Food] CHECK CONSTRAINT [FK_Order_Food_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Addresses] FOREIGN KEY([Address_Id])
REFERENCES [dbo].[Addresses] ([Address_Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Addresses]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Clients] FOREIGN KEY([Client_Id])
REFERENCES [dbo].[Clients] ([Client_Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Clients]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_DeliveryMans] FOREIGN KEY([DeliveryMan_Id])
REFERENCES [dbo].[DeliveryMans] ([DeliveryMan_Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_DeliveryMans]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderStatuses1] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[OrderStatuses] ([OrderStatus_Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_OrderStatuses1]
GO
