
CREATE DATABASE [PPDBJohannesPosse]
GO
USE [PPDBJohannesPosse]
GO
/****** Object:  Table [dbo].[ParkingLog]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingLog](
	[ParkingLogID] [int] IDENTITY(1,1) NOT NULL,
	[RegNr] [nvarchar](10) NOT NULL,
	[Parkingspace] [int] NOT NULL,
	[VehicleType] [int] NOT NULL,
	[ParkedTime] [datetime] NOT NULL,
	[RetreiveTime] [datetime] NULL,
	[TotalTime] [int] NULL,
	[ParkingFee] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ParkingLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_ShowIncomePerDay]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[v_ShowIncomePerDay]
AS


SELECT CAST(RetreiveTime AS date) as Date , SUM(ParkingFee) as InCome
FROM ParkingLog
WHERE RetreiveTime BETWEEN (SELECT TOP 1 MIN(RetreiveTime) FROM ParkingLog) AND GETDATE()
GROUP BY CAST(RetreiveTime AS date) 

GO
/****** Object:  Table [dbo].[ParkingSpace]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingSpace](
	[ParkingSpaceID] [int] IDENTITY(1,1) NOT NULL,
	[Size] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ParkingSpaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[empty_parking_slots]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[empty_parking_slots] AS
Select ParkingSpaceID AS 'Parking Slot'
FROM ParkingSpace
WHERE Size = 0
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[RegNr] [nvarchar](10) NOT NULL,
	[VehicleType] [int] NOT NULL,
	[ParkedTime] [datetime] NOT NULL,
	[CurrentParkedTime]  AS (datediff(minute,[ParkedTime],getdate())),
	[ParkingFee]  AS (case when datediff(minute,[ParkedTime],getdate())<(5) then (0) when datediff(minute,[ParkedTime],getdate())>=(5) AND datediff(minute,[ParkedTime],getdate())<=(120) AND [VehicleType]=(2) then (40) when datediff(minute,[ParkedTime],getdate())>=(5) AND datediff(minute,[ParkedTime],getdate())<=(120) AND [VehicleType]=(1) then (20) when datediff(minute,[ParkedTime],getdate())>(120) AND [VehicleType]=(2) then (20)+(datediff(minute,[ParkedTime],getdate())/(60))*(20) when datediff(minute,[ParkedTime],getdate())>(120) AND [VehicleType]=(1) then (10)+(datediff(minute,[ParkedTime],getdate())/(60))*(10)  end),
PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_ParkedMoreThan48h]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[v_ParkedMoreThan48h] AS

SELECT RegNr, ParkedTime, NULL AS RetreiveTime FROM Vehicle
WHERE CurrentParkedTime > 2880
UNION
SELECT RegNr, ParkedTime, RetreiveTime FROM ParkingLog
WHERE TotalTime > 2880


GO
/****** Object:  Table [dbo].[ParkedVehicles]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkedVehicles](
	[ParkedVehiclesID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleID] [int] NOT NULL,
	[ParkingSpaceID] [int] NOT NULL,
	[Size] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ParkedVehiclesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ParkedVehicles] ON 

INSERT [dbo].[ParkedVehicles] ([ParkedVehiclesID], [VehicleID], [ParkingSpaceID], [Size]) VALUES (190, 165, 1, 2)
INSERT [dbo].[ParkedVehicles] ([ParkedVehiclesID], [VehicleID], [ParkingSpaceID], [Size]) VALUES (191, 166, 2, 2)
INSERT [dbo].[ParkedVehicles] ([ParkedVehiclesID], [VehicleID], [ParkingSpaceID], [Size]) VALUES (192, 167, 3, 2)
INSERT [dbo].[ParkedVehicles] ([ParkedVehiclesID], [VehicleID], [ParkingSpaceID], [Size]) VALUES (193, 168, 4, 2)
INSERT [dbo].[ParkedVehicles] ([ParkedVehiclesID], [VehicleID], [ParkingSpaceID], [Size]) VALUES (194, 169, 5, 2)
INSERT [dbo].[ParkedVehicles] ([ParkedVehiclesID], [VehicleID], [ParkingSpaceID], [Size]) VALUES (195, 170, 66, 1)
INSERT [dbo].[ParkedVehicles] ([ParkedVehiclesID], [VehicleID], [ParkingSpaceID], [Size]) VALUES (196, 171, 55, 1)
INSERT [dbo].[ParkedVehicles] ([ParkedVehiclesID], [VehicleID], [ParkingSpaceID], [Size]) VALUES (197, 172, 10, 1)
INSERT [dbo].[ParkedVehicles] ([ParkedVehiclesID], [VehicleID], [ParkingSpaceID], [Size]) VALUES (198, 173, 10, 1)
INSERT [dbo].[ParkedVehicles] ([ParkedVehiclesID], [VehicleID], [ParkingSpaceID], [Size]) VALUES (199, 174, 77, 1)
SET IDENTITY_INSERT [dbo].[ParkedVehicles] OFF
GO
SET IDENTITY_INSERT [dbo].[ParkingLog] ON 

INSERT [dbo].[ParkingLog] ([ParkingLogID], [RegNr], [Parkingspace], [VehicleType], [ParkedTime], [RetreiveTime], [TotalTime], [ParkingFee]) VALUES (92, N'CAR1', 1, 2, CAST(N'2021-02-04T19:42:19.127' AS DateTime), CAST(N'2021-02-04T21:18:59.153' AS DateTime), 96, 40)
INSERT [dbo].[ParkingLog] ([ParkingLogID], [RegNr], [Parkingspace], [VehicleType], [ParkedTime], [RetreiveTime], [TotalTime], [ParkingFee]) VALUES (93, N'CAR2', 2, 2, CAST(N'2021-02-04T19:42:23.150' AS DateTime), CAST(N'2021-02-04T21:19:04.287' AS DateTime), 97, 40)
INSERT [dbo].[ParkingLog] ([ParkingLogID], [RegNr], [Parkingspace], [VehicleType], [ParkedTime], [RetreiveTime], [TotalTime], [ParkingFee]) VALUES (94, N'CAR3', 3, 2, CAST(N'2021-02-05T19:42:27.100' AS DateTime), CAST(N'2021-02-05T21:19:10.440' AS DateTime), 97, 40)
INSERT [dbo].[ParkingLog] ([ParkingLogID], [RegNr], [Parkingspace], [VehicleType], [ParkedTime], [RetreiveTime], [TotalTime], [ParkingFee]) VALUES (95, N'CAR4', 4, 2, CAST(N'2021-02-05T19:42:31.247' AS DateTime), CAST(N'2021-02-05T21:19:16.253' AS DateTime), 97, 40)
INSERT [dbo].[ParkingLog] ([ParkingLogID], [RegNr], [Parkingspace], [VehicleType], [ParkedTime], [RetreiveTime], [TotalTime], [ParkingFee]) VALUES (96, N'CAR5', 5, 2, CAST(N'2021-02-05T19:42:36.703' AS DateTime), CAST(N'2021-02-05T21:19:21.527' AS DateTime), 97, 40)
INSERT [dbo].[ParkingLog] ([ParkingLogID], [RegNr], [Parkingspace], [VehicleType], [ParkedTime], [RetreiveTime], [TotalTime], [ParkingFee]) VALUES (97, N'MC1', 6, 1, CAST(N'2021-02-05T19:42:42.673' AS DateTime), CAST(N'2021-02-05T21:19:25.817' AS DateTime), 97, 20)
INSERT [dbo].[ParkingLog] ([ParkingLogID], [RegNr], [Parkingspace], [VehicleType], [ParkedTime], [RetreiveTime], [TotalTime], [ParkingFee]) VALUES (98, N'MC2', 6, 1, CAST(N'2021-02-05T19:42:45.897' AS DateTime), CAST(N'2021-02-05T21:19:30.653' AS DateTime), 97, 20)
INSERT [dbo].[ParkingLog] ([ParkingLogID], [RegNr], [Parkingspace], [VehicleType], [ParkedTime], [RetreiveTime], [TotalTime], [ParkingFee]) VALUES (99, N'MC3', 7, 1, CAST(N'2021-02-05T19:42:48.900' AS DateTime), CAST(N'2021-02-05T21:19:34.490' AS DateTime), 97, 20)
INSERT [dbo].[ParkingLog] ([ParkingLogID], [RegNr], [Parkingspace], [VehicleType], [ParkedTime], [RetreiveTime], [TotalTime], [ParkingFee]) VALUES (100, N'MC4', 7, 1, CAST(N'2021-02-05T19:42:52.290' AS DateTime), CAST(N'2021-02-05T21:19:43.600' AS DateTime), 97, 20)
INSERT [dbo].[ParkingLog] ([ParkingLogID], [RegNr], [Parkingspace], [VehicleType], [ParkedTime], [RetreiveTime], [TotalTime], [ParkingFee]) VALUES (101, N'MC5', 8, 1, CAST(N'2021-02-05T19:42:56.573' AS DateTime), CAST(N'2021-02-05T21:19:49.850' AS DateTime), 97, 20)
SET IDENTITY_INSERT [dbo].[ParkingLog] OFF
GO
SET IDENTITY_INSERT [dbo].[ParkingSpace] ON 

INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (1, 2)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (2, 2)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (3, 2)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (4, 2)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (5, 2)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (6, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (7, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (8, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (9, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (10, 2)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (11, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (12, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (13, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (14, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (15, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (16, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (17, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (18, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (19, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (20, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (21, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (22, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (23, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (24, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (25, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (26, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (27, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (28, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (29, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (30, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (31, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (32, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (33, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (34, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (35, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (36, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (37, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (38, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (39, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (40, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (41, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (42, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (43, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (44, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (45, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (46, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (47, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (48, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (49, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (50, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (51, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (52, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (53, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (54, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (55, 1)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (56, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (57, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (58, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (59, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (60, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (61, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (62, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (63, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (64, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (65, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (66, 1)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (67, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (68, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (69, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (70, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (71, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (72, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (73, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (74, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (75, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (76, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (77, 1)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (78, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (79, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (80, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (81, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (82, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (83, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (84, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (85, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (86, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (87, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (88, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (89, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (90, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (91, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (92, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (93, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (94, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (95, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (96, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (97, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (98, 0)
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (99, 0)
GO
INSERT [dbo].[ParkingSpace] ([ParkingSpaceID], [Size]) VALUES (100, 0)
SET IDENTITY_INSERT [dbo].[ParkingSpace] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicle] ON 

INSERT [dbo].[Vehicle] ([VehicleID], [RegNr], [VehicleType], [ParkedTime]) VALUES (165, N'CAR1', 2, CAST(N'2021-02-05T21:57:05.080' AS DateTime))
INSERT [dbo].[Vehicle] ([VehicleID], [RegNr], [VehicleType], [ParkedTime]) VALUES (166, N'CAR2', 2, CAST(N'2021-02-05T21:57:08.870' AS DateTime))
INSERT [dbo].[Vehicle] ([VehicleID], [RegNr], [VehicleType], [ParkedTime]) VALUES (167, N'CAR3', 2, CAST(N'2021-02-05T21:57:24.303' AS DateTime))
INSERT [dbo].[Vehicle] ([VehicleID], [RegNr], [VehicleType], [ParkedTime]) VALUES (168, N'CAR4', 2, CAST(N'2021-02-05T21:57:31.367' AS DateTime))
INSERT [dbo].[Vehicle] ([VehicleID], [RegNr], [VehicleType], [ParkedTime]) VALUES (169, N'CAR5', 2, CAST(N'2021-02-05T21:57:36.243' AS DateTime))
INSERT [dbo].[Vehicle] ([VehicleID], [RegNr], [VehicleType], [ParkedTime]) VALUES (170, N'MC1', 1, CAST(N'2021-02-05T21:57:40.710' AS DateTime))
INSERT [dbo].[Vehicle] ([VehicleID], [RegNr], [VehicleType], [ParkedTime]) VALUES (171, N'MC2', 1, CAST(N'2021-02-05T21:57:45.030' AS DateTime))
INSERT [dbo].[Vehicle] ([VehicleID], [RegNr], [VehicleType], [ParkedTime]) VALUES (172, N'MC3', 1, CAST(N'2021-02-05T21:57:48.627' AS DateTime))
INSERT [dbo].[Vehicle] ([VehicleID], [RegNr], [VehicleType], [ParkedTime]) VALUES (173, N'MC4', 1, CAST(N'2021-02-05T21:57:53.430' AS DateTime))
INSERT [dbo].[Vehicle] ([VehicleID], [RegNr], [VehicleType], [ParkedTime]) VALUES (174, N'MC5', 1, CAST(N'2021-02-05T21:57:57.283' AS DateTime))
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
GO
/****** Object:  Index [UC_VehicleID]    Script Date: 2021-02-05 22:02:44 ******/
ALTER TABLE [dbo].[ParkedVehicles] ADD  CONSTRAINT [UC_VehicleID] UNIQUE NONCLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CK_RegNr]    Script Date: 2021-02-05 22:02:44 ******/
ALTER TABLE [dbo].[Vehicle] ADD  CONSTRAINT [CK_RegNr] UNIQUE NONCLUSTERED 
(
	[RegNr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ParkingLog] ADD  DEFAULT ((0)) FOR [ParkingFee]
GO
ALTER TABLE [dbo].[ParkingSpace] ADD  DEFAULT ((0)) FOR [Size]
GO
ALTER TABLE [dbo].[Vehicle] ADD  DEFAULT (getdate()) FOR [ParkedTime]
GO
ALTER TABLE [dbo].[ParkedVehicles]  WITH CHECK ADD  CONSTRAINT [FK_ParkingSpace] FOREIGN KEY([ParkingSpaceID])
REFERENCES [dbo].[ParkingSpace] ([ParkingSpaceID])
GO
ALTER TABLE [dbo].[ParkedVehicles] CHECK CONSTRAINT [FK_ParkingSpace]
GO
ALTER TABLE [dbo].[ParkedVehicles]  WITH CHECK ADD  CONSTRAINT [FK_VehicleID_Cascade] FOREIGN KEY([VehicleID])
REFERENCES [dbo].[Vehicle] ([VehicleID])
GO
ALTER TABLE [dbo].[ParkedVehicles] CHECK CONSTRAINT [FK_VehicleID_Cascade]
GO
ALTER TABLE [dbo].[ParkedVehicles]  WITH CHECK ADD CHECK  (([ParkingSpaceID]>=(1) AND [ParkingSpaceID]<=(100)))
GO
ALTER TABLE [dbo].[ParkedVehicles]  WITH CHECK ADD CHECK  (([Size]>=(1) AND [Size]<=(2)))
GO
ALTER TABLE [dbo].[ParkingLog]  WITH CHECK ADD CHECK  (([Parkingspace]>=(1) AND [Parkingspace]<=(100)))
GO
ALTER TABLE [dbo].[ParkingLog]  WITH CHECK ADD CHECK  ((len([RegNr])>=(3)))
GO
ALTER TABLE [dbo].[ParkingLog]  WITH CHECK ADD CHECK  (([VehicleType]>=(1) AND [VehicleType]<=(2)))
GO
ALTER TABLE [dbo].[ParkingSpace]  WITH CHECK ADD CHECK  (([Size]>=(0) AND [Size]<=(2)))
GO
ALTER TABLE [dbo].[ParkingSpace]  WITH CHECK ADD  CONSTRAINT [CK_MaxSlots] CHECK  (([ParkingSpaceID]>=(1) AND [ParkingSpaceID]<=(100)))
GO
ALTER TABLE [dbo].[ParkingSpace] CHECK CONSTRAINT [CK_MaxSlots]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD CHECK  ((len([RegNr])>=(3)))
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD CHECK  (([VehicleType]>=(1) AND [VehicleType]<=(2)))
GO
/****** Object:  StoredProcedure [dbo].[GetParkedVehicleInfo]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetParkedVehicleInfo]
AS

BEGIN TRANSACTION[GetVehicles]
BEGIN TRY

	SELECT pv.ParkingSpaceID, v.RegNr, v.VehicleType, v.ParkedTime, v.CurrentParkedTime, v.ParkingFee
	FROM Vehicle v
	JOIN ParkedVehicles pv ON
	v.VehicleID = pv.VehicleID
	ORDER BY pv.ParkingSpaceID


COMMIT TRANSACTION[firstAvailable]

END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION[firstAvailable]
	SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_SEVERITY() AS ErrorSeverity,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[parkInFirstAvailable]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[parkInFirstAvailable] @RegNr nvarchar(30), @vehicleType int, @RegNrOut nvarchar(30) out, @ParkingSlotOut nvarchar(30) out
AS


BEGIN TRANSACTION[firstAvailable]
BEGIN TRY

	DECLARE @firstAvailableSpot int;
	DECLARE @VehicleID int;

	


	IF(@VehicleType = 2)
	BEGIN
		SET @firstAvailableSpot = (Select TOP(1) ParkingSpaceID From ParkingSpace WHERE Size = 0) 
	END

	IF (@VehicleType = 1)
	BEGIN
		SET @firstAvailableSpot = (Select TOP(1) ParkingSpaceID From ParkingSpace WHERE Size = 1 OR Size = 0) 
	END


	INSERT INTO Vehicle(RegNr,VehicleType)
	VALUES(@RegNr,@vehicleType)

	SET @VehicleID = (SELECT VehicleID FROM Vehicle WHERE RegNr = @RegNr)

	INSERT INTO ParkedVehicles(VehicleID,ParkingSpaceID,Size)
	VALUES(@VehicleID,@firstAvailableSpot,@vehicleType)

	SET @RegNrOut = @RegNr
	SET @ParkingSlotOut = @firstAvailableSpot

COMMIT TRANSACTION[firstAvailable]

END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION[firstAvailable]
	SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_SEVERITY() AS ErrorSeverity,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[RemoveVehicle]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveVehicle] @RegNr nvarchar(10)
AS

BEGIN TRANSACTION[DeleteVehicle]
BEGIN TRY
	
	DECLARE @VehicleID int 

	SET @VehicleID = (SELECT VehicleID FROM Vehicle WHERE RegNr = @RegNr)
	

	IF(@VehicleID IS NULL)
	BEGIN
		RAISERROR('Vehicle not found',18,1)
	END
	

	DELETE FROM ParkedVehicles
	WHERE VehicleID = @VehicleID


COMMIT TRANSACTION[DeleteVehicle]
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION[DeleteVehicle]

	SELECT
    ERROR_STATE() AS ErrorState,
    ERROR_SEVERITY() AS ErrorSeverity,
    ERROR_MESSAGE() AS ErrorMessage;

	THROW

END CATCH
GO
/****** Object:  StoredProcedure [dbo].[ReturnRemovedVehicleInfo]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ReturnRemovedVehicleInfo] @RegNr nvarchar(30), @ForFree int
AS

BEGIN TRANSACTION[ts_ReturnRemovedVehicleInfo]
BEGIN TRY
	
	DECLARE @ParkingLogID int

	SET @ParkingLogID = (SELECT  TOP(1) ParkingLogID FROM ParkingLog WHERE RegNr = @RegNr ORDER BY ParkingLogID DESC)

	IF(@ForFree = 2)
	BEGIN
		UPDATE ParkingLog
		SET ParkingFee = 0
		WHERE ParkingLogID = @ParkingLogID
	END

	SELECT TOP(1) RegNr, ParkedTime, RetreiveTime, TotalTime, ParkingFee
	FROM ParkingLog 
	WHERE RegNr = @RegNr
	ORDER BY RetreiveTime DESC

COMMIT TRANSACTION[ts_ReturnRemovedVehicleInfo]
END TRY

BEGIN CATCH
	ROLLBACK TRANSACTION[ts_ReturnRemovedVehicleInfo]
	SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_SEVERITY() AS ErrorSeverity,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sp_GetIncome]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetIncome] @StartDate datetime, @EndDate datetime AS


DECLARE dateCursor CURSOR READ_ONLY FOR SELECT ParkedTime, VehicleType FROM Vehicle WHERE ParkedTime BETWEEN @StartDate AND @EndDate
	
	DECLARE @ParkedAtTime datetime
	DECLARE @VehicleType int
	DECLARE @ParkedMinutes int
	DECLARE @Income int

	SET @Income = 0

	OPEN dateCursor
	FETCH NEXT FROM dateCursor INTO @ParkedAtTime, @VehicleType

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF(@EndDate > GETDATE())
		BEGIN
		SET @ParkedMinutes = DATEDIFF(MINUTE,@ParkedAtTime, GETDATE())
		END
		IF(@EndDate < GETDATE())
		BEGIN
		SET @ParkedMinutes = DATEDIFF(MINUTE,@ParkedAtTime, @EndDate)
		END

		IF(@ParkedMinutes < 5)
		BEGIN
			SET @Income = @Income + 0
		END
		IF(@ParkedMinutes BETWEEN 5 AND 120 AND @VehicleType = 2)
		BEGIN
			SET @Income = @Income + 40
		END
		IF(@ParkedMinutes BETWEEN 5 AND 120 AND @VehicleType = 1)
		BEGIN
			SET @Income = @Income + 20
		END
		IF(@ParkedMinutes > 120 AND @VehicleType = 2)
		BEGIN
			SET @Income = @Income + 20 + DATEDIFF(MINUTE,@ParkedAtTime,@EndDate) /60 * 20
		END
		IF(@ParkedMinutes > 120 AND @VehicleType = 1)
		BEGIN
			SET @Income = @Income + 10 + DATEDIFF(MINUTE,@ParkedAtTime,@EndDate) /60 * 10
		END

		FETCH NEXT FROM dateCursor INTO @ParkedAtTime, @VehicleType
	END

	SELECT @StartDate AS 'Date', @Income AS 'Income'

	CLOSE dateCursor
	DEALLOCATE dateCursor

	
GO
/****** Object:  StoredProcedure [dbo].[sp_GetIncomeInterval]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetIncomeInterval] @StartDate date, @EndDate date AS

DECLARE @Avg int
DECLARE @FromDate date
DECLARE @ToDate date

SET @Avg = 1


IF(@StartDate = @EndDate)
BEGIN
SELECT CAST(RetreiveTime AS date) as Date , SUM(ParkingFee) as Income
FROM ParkingLog
WHERE CAST(RetreiveTime AS date) BETWEEN @StartDate AND @EndDate
GROUP BY CAST(RetreiveTime AS date) 
END

IF(@StartDate != @EndDate)
BEGIN
	
	SET @FromDate = (SELECT TOP 1 MIN(CAST(RetreiveTime AS date)) as Date FROM ParkingLog WHERE CAST(RetreiveTime AS date) BETWEEN @StartDate AND @EndDate) 
	SET @ToDate = (SELECT TOP 1 MAX(CAST(RetreiveTime AS date)) as Date FROM ParkingLog WHERE CAST(RetreiveTime AS date) BETWEEN @StartDate AND @EndDate) 

	IF(@FromDate = @ToDate)
	BEGIN
		SET @ToDate = DATEADD(DAY,1,@ToDate)
	END

	print @fromdate
	print @todate

	print DATEDIFF(DAY,@StartDate,@EndDate)

	SET @Avg = (SELECT SUM(ParkingFee) FROM ParkingLog WHERE CAST(RetreiveTime AS date) BETWEEN @StartDate AND @EndDate)
	--IF(DATEDIFF(DAY,@StartDate,@EndDate) = 1)
	IF(DATEDIFF(DAY,@FromDate,@ToDate) = 1)
	BEGIN 
		SET @Avg = @Avg / 2
	END
	ELSE
	BEGIN
	SET @Avg = @AVG / DATEDIFF(DAY,@FromDate,@ToDate)
	END
	   
	SELECT CAST(RetreiveTime AS date) as Date , SUM(ParkingFee) as Income, @Avg as 'Average/Day'
	FROM ParkingLog
	WHERE CAST(RetreiveTime AS date) BETWEEN @StartDate AND @EndDate
	GROUP BY CAST(RetreiveTime AS date) 

END

GO
/****** Object:  StoredProcedure [dbo].[sp_OptimizeMcParking]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_OptimizeMcParking]
AS

BEGIN TRANSACTION[ts_OptimizeMcParking]
BEGIN TRY

	DECLARE mcCursor CURSOR READ_ONLY FOR SELECT VehicleID, RegNr FROM Vehicle WHERE VehicleType = 1
	
	DECLARE @VehicleID int
	DECLARE @RegNr nvarchar(10)
	DECLARE @firstAvailableSpot int
	DECLARE @fromParkingSlot int


	OPEN mcCursor
	FETCH NEXT FROM mcCursor INTO @VehicleID, @RegNr

	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		SET @firstAvailableSpot = (Select TOP(1) ParkingSpaceID From ParkingSpace WHERE Size = 1 OR Size = 0)
		SET @fromParkingSlot = (SELECT ParkingSpaceID FROM ParkedVehicles WHERE VehicleID = @VehicleID)

		UPDATE ParkedVehicles
		SET ParkingSpaceID = @firstAvailableSpot
		WHERE VehicleID = @VehicleID
		PRINT @Regnr + ' was moved from ' + CAST(@fromParkingSlot AS nvarchar(3)) + ' to ' + CAST(@firstAvailableSpot AS nvarchar(3))
		FETCH NEXT FROM mcCursor INTO @VehicleID, @RegNr
	END
	CLOSE mcCursor
	DEALLOCATE mcCursor


COMMIT TRANSACTION[ts_OptimizeMcParking]

END TRY

BEGIN CATCH
	CLOSE mcCursor
	DEALLOCATE mcCursor
	ROLLBACK TRANSACTION[ts_OptimizeMcParking]
	
	SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_SEVERITY() AS ErrorSeverity,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH
GO
/****** Object:  Trigger [dbo].[tr_CheckSize]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_CheckSize] ON [dbo].[ParkedVehicles] AFTER INSERT
AS
BEGIN
	UPDATE ParkingSpace
	SET Size += i.Size
	FROM ParkingSpace

	JOIN INSERTED i on ParkingSpace.ParkingSpaceID = i.ParkingSpaceID
	WHERE i.ParkingSpaceID = ParkingSpace.ParkingSpaceID

END
GO
ALTER TABLE [dbo].[ParkedVehicles] ENABLE TRIGGER [tr_CheckSize]
GO
/****** Object:  Trigger [dbo].[tr_RemoveSize]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tr_RemoveSize] ON [dbo].[ParkedVehicles] FOR DELETE
AS
BEGIN
	UPDATE ParkingSpace
	SET Size -= d.Size
	FROM ParkingSpace

	JOIN deleted d on ParkingSpace.ParkingSpaceID = d.ParkingSpaceID
	WHERE d.ParkingSpaceID = ParkingSpace.ParkingSpaceID

	INSERT INTO ParkingLog(RegNr,Parkingspace,VehicleType,ParkedTime,RetreiveTime,TotalTime,ParkingFee)
	SELECT v.RegNr,d.ParkingSpaceID,v.VehicleType,v.ParkedTime, GETDATE(),v.CurrentParkedTime,v.ParkingFee FROM deleted d
	JOIN Vehicle v ON
	d.VehicleID = v.VehicleID

	Delete FROM Vehicle 
	FROM deleted d
	JOIN Vehicle v ON
	v.VehicleID = d.VehicleID
	WHERE v.VehicleID = d.VehicleID
	

END
GO
ALTER TABLE [dbo].[ParkedVehicles] ENABLE TRIGGER [tr_RemoveSize]
GO
/****** Object:  Trigger [dbo].[tr_RemoveSizeUpdate]    Script Date: 2021-02-05 22:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_RemoveSizeUpdate] ON [dbo].[ParkedVehicles] FOR UPDATE
AS
BEGIN
	UPDATE ParkingSpace
	SET Size += i.Size
	FROM ParkingSpace

	JOIN inserted i on ParkingSpace.ParkingSpaceID = i.ParkingSpaceID
	WHERE i.ParkingSpaceID = ParkingSpace.ParkingSpaceID

	UPDATE ParkingSpace
	SET Size -= d.Size
	FROM ParkingSpace

	JOIN deleted d on ParkingSpace.ParkingSpaceID = d.ParkingSpaceID
	WHERE d.ParkingSpaceID = ParkingSpace.ParkingSpaceID

END
GO
ALTER TABLE [dbo].[ParkedVehicles] ENABLE TRIGGER [tr_RemoveSizeUpdate]
GO
USE [master]
GO
ALTER DATABASE [PPDBJohannesPosse] SET  READ_WRITE 
GO
