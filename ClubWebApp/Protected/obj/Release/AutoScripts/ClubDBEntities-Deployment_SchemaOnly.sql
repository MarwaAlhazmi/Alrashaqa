SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[SecondName] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[LastName] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[FamilyName] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[DOB] [int] NULL,
	[Nationality] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[IDNumber] [bigint] NULL,
	[Phone] [bigint] NULL,
	[Marital] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[RefferedFrom] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[RefferedDate] [date] NULL,
	[Status] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashMov](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[PreBalance] [money] NOT NULL,
	[InvIncome] [money] NOT NULL,
	[BuffetIncome] [money] NOT NULL,
	[Balance] [money] NOT NULL,
	[Expenses] [money] NOT NULL,
	[Bank] [money] NOT NULL,
	[MigBalance] [money] NOT NULL,
 CONSTRAINT [PK_CashMov] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_CashMov] ON [dbo].[CashMov] 
(
	[Date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuffetMov](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PreBalance] [money] NOT NULL,
	[Balance] [money] NOT NULL,
	[Purchase] [money] NOT NULL,
	[Sales] [money] NOT NULL,
	[MigBalance] [money] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_BuffetMov] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_BuffetMov] ON [dbo].[BuffetMov] 
(
	[Date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) COLLATE Arabic_CI_AS NOT NULL,
	[PhoneNum] [bigint] NULL,
	[Type] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[UserName] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpensesMov](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[PreBalance] [money] NOT NULL,
	[PlusBalance] [money] NOT NULL,
	[Balance] [money] NOT NULL,
	[Expenses] [money] NOT NULL,
	[MigBalance] [money] NOT NULL,
 CONSTRAINT [PK_ExpensesMov] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_ExpensesMov] ON [dbo].[ExpensesMov] 
(
	[Date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Withdraw](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [int] NOT NULL,
	[ToPerson] [nvarchar](100) COLLATE Arabic_CI_AS NOT NULL,
	[Date] [date] NOT NULL,
	[Notes] [nvarchar](150) COLLATE Arabic_CI_AS NULL,
	[Amount] [money] NOT NULL,
	[AmountW] [nvarchar](100) COLLATE Arabic_CI_AS NULL,
	[Bank] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[CheckNum] [bigint] NULL,
 CONSTRAINT [PK_Withdraw] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[Price] [money] NOT NULL,
	[DepID] [int] NOT NULL,
	[Sub] [bit] NOT NULL,
	[TotalDays] [int] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TReaquest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Diagnosis] [text] COLLATE Arabic_CI_AS NULL,
	[Goals] [text] COLLATE Arabic_CI_AS NULL,
	[Precautions] [text] COLLATE Arabic_CI_AS NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_TReaquest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceHeader](
	[InvID] [int] IDENTITY(100,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[RecepName] [nvarchar](150) COLLATE Arabic_CI_AS NULL,
	[TotalAmount] [money] NOT NULL,
	[Discount] [int] NULL,
	[FinalAmount] [money] NOT NULL,
	[Status] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[DocID] [int] NULL,
	[Notes] [nvarchar](150) COLLATE Arabic_CI_AS NULL,
	[Dep] [int] NULL,
	[Type] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_InvoiceHeader] PRIMARY KEY CLUSTERED 
(
	[InvID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Diagnosis] [text] COLLATE Arabic_CI_AS NULL,
	[History] [text] COLLATE Arabic_CI_AS NULL,
	[Objective] [text] COLLATE Arabic_CI_AS NULL,
	[Assessment] [text] COLLATE Arabic_CI_AS NULL,
	[Goals] [text] COLLATE Arabic_CI_AS NULL,
	[Treatment] [text] COLLATE Arabic_CI_AS NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Evaluation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepDoc](
	[DocID] [int] NOT NULL,
	[DepID] [int] NOT NULL,
 CONSTRAINT [PK_DepDoc] PRIMARY KEY CLUSTERED 
(
	[DocID] ASC,
	[DepID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discharge](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Diagnosis] [text] COLLATE Arabic_CI_AS NULL,
	[PreReferral] [text] COLLATE Arabic_CI_AS NULL,
	[InitialSession] [date] NOT NULL,
	[FinalSession] [date] NOT NULL,
	[TotalNSession] [nvarchar](150) COLLATE Arabic_CI_AS NULL,
	[Treatment] [text] COLLATE Arabic_CI_AS NULL,
	[Discharge] [text] COLLATE Arabic_CI_AS NULL,
	[Goals] [text] COLLATE Arabic_CI_AS NULL,
	[GoalsBool] [varchar](50) COLLATE Arabic_CI_AS NULL,
	[Comments] [text] COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_Discharge] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deposit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvID] [int] NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[Notes] [nvarchar](150) COLLATE Arabic_CI_AS NULL,
	[CheckNum] [bigint] NULL,
	[Bank] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Date] [date] NOT NULL,
	[Employee] [nvarchar](150) COLLATE Arabic_CI_AS NOT NULL,
	[AmountW] [nvarchar](150) COLLATE Arabic_CI_AS NULL,
	[FromPerson] [nvarchar](150) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_Deposit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceServices](
	[InvID] [int] NOT NULL,
	[ServiceID] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceServices] PRIMARY KEY CLUSTERED 
(
	[InvID] ASC,
	[ServiceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscribtion](
	[SubID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[ClientID] [int] NOT NULL,
	[ServiceID] [int] NOT NULL,
	[SubDays] [int] NULL,
	[AttDays] [int] NULL,
	[LeftDays] [int] NULL,
	[Measurements] [nvarchar](150) COLLATE Arabic_CI_AS NULL,
	[Diagnosis] [nvarchar](150) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_Subscribtion] PRIMARY KEY CLUSTERED 
(
	[SubID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visit](
	[VisitID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[SubID] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[SizeBefore] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[SizeAfter] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[SigninTime] [time](7) NULL,
	[Signouttime] [time](7) NULL,
 CONSTRAINT [PK_Visit] PRIMARY KEY CLUSTERED 
(
	[VisitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NutSub](
	[SubID] [int] NOT NULL,
	[Fat] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Weight] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[Hight] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_NutSub] PRIMARY KEY CLUSTERED 
(
	[SubID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IntSub](
	[SubID] [int] NOT NULL,
	[BloodPressure] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[BloodSugar] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_IntSub] PRIMARY KEY CLUSTERED 
(
	[SubID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)

GO
ALTER TABLE [dbo].[Withdraw]  WITH CHECK ADD  CONSTRAINT [FK_Withdraw_Employee] FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employee] ([EmpID])
GO
ALTER TABLE [dbo].[Withdraw] CHECK CONSTRAINT [FK_Withdraw_Employee]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Service] FOREIGN KEY([DepID])
REFERENCES [dbo].[Department] ([DepID])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Service]
GO
ALTER TABLE [dbo].[TReaquest]  WITH CHECK ADD  CONSTRAINT [FK_TReaquest_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[TReaquest] CHECK CONSTRAINT [FK_TReaquest_Client]
GO
ALTER TABLE [dbo].[TReaquest]  WITH CHECK ADD  CONSTRAINT [FK_TReaquest_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmpID])
GO
ALTER TABLE [dbo].[TReaquest] CHECK CONSTRAINT [FK_TReaquest_Employee]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_Client]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_Department] FOREIGN KEY([Dep])
REFERENCES [dbo].[Department] ([DepID])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_Department]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_Employee] FOREIGN KEY([DocID])
REFERENCES [dbo].[Employee] ([EmpID])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_Employee]
GO
ALTER TABLE [dbo].[Evaluation]  WITH CHECK ADD  CONSTRAINT [FK_Evaluation_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Evaluation] CHECK CONSTRAINT [FK_Evaluation_Client]
GO
ALTER TABLE [dbo].[Evaluation]  WITH CHECK ADD  CONSTRAINT [FK_Evaluation_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmpID])
GO
ALTER TABLE [dbo].[Evaluation] CHECK CONSTRAINT [FK_Evaluation_Employee]
GO
ALTER TABLE [dbo].[DepDoc]  WITH CHECK ADD  CONSTRAINT [FK_DepDoc_Department] FOREIGN KEY([DepID])
REFERENCES [dbo].[Department] ([DepID])
GO
ALTER TABLE [dbo].[DepDoc] CHECK CONSTRAINT [FK_DepDoc_Department]
GO
ALTER TABLE [dbo].[DepDoc]  WITH CHECK ADD  CONSTRAINT [FK_DepDoc_Employee] FOREIGN KEY([DocID])
REFERENCES [dbo].[Employee] ([EmpID])
GO
ALTER TABLE [dbo].[DepDoc] CHECK CONSTRAINT [FK_DepDoc_Employee]
GO
ALTER TABLE [dbo].[Discharge]  WITH CHECK ADD  CONSTRAINT [FK_Discharge_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Discharge] CHECK CONSTRAINT [FK_Discharge_Client]
GO
ALTER TABLE [dbo].[Discharge]  WITH CHECK ADD  CONSTRAINT [FK_Discharge_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmpID])
GO
ALTER TABLE [dbo].[Discharge] CHECK CONSTRAINT [FK_Discharge_Employee]
GO
ALTER TABLE [dbo].[Deposit]  WITH CHECK ADD  CONSTRAINT [FK_Deposit_InvoiceHeader] FOREIGN KEY([InvID])
REFERENCES [dbo].[InvoiceHeader] ([InvID])
GO
ALTER TABLE [dbo].[Deposit] CHECK CONSTRAINT [FK_Deposit_InvoiceHeader]
GO
ALTER TABLE [dbo].[InvoiceServices]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceServices_InvoiceHeader] FOREIGN KEY([InvID])
REFERENCES [dbo].[InvoiceHeader] ([InvID])
GO
ALTER TABLE [dbo].[InvoiceServices] CHECK CONSTRAINT [FK_InvoiceServices_InvoiceHeader]
GO
ALTER TABLE [dbo].[InvoiceServices]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceServices_Service] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ServiceID])
GO
ALTER TABLE [dbo].[InvoiceServices] CHECK CONSTRAINT [FK_InvoiceServices_Service]
GO
ALTER TABLE [dbo].[Subscribtion]  WITH CHECK ADD  CONSTRAINT [FK_Subscribtion_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Subscribtion] CHECK CONSTRAINT [FK_Subscribtion_Client]
GO
ALTER TABLE [dbo].[Subscribtion]  WITH CHECK ADD  CONSTRAINT [FK_Subscribtion_Service] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ServiceID])
GO
ALTER TABLE [dbo].[Subscribtion] CHECK CONSTRAINT [FK_Subscribtion_Service]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [FK_Visit_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [FK_Visit_Client]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [FK_Visit_Subscribtion] FOREIGN KEY([SubID])
REFERENCES [dbo].[Subscribtion] ([SubID])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [FK_Visit_Subscribtion]
GO
ALTER TABLE [dbo].[NutSub]  WITH CHECK ADD  CONSTRAINT [FK_NutSub_Subscribtion] FOREIGN KEY([SubID])
REFERENCES [dbo].[Subscribtion] ([SubID])
GO
ALTER TABLE [dbo].[NutSub] CHECK CONSTRAINT [FK_NutSub_Subscribtion]
GO
ALTER TABLE [dbo].[IntSub]  WITH CHECK ADD  CONSTRAINT [FK_IntSub_IntSub] FOREIGN KEY([SubID])
REFERENCES [dbo].[Subscribtion] ([SubID])
GO
ALTER TABLE [dbo].[IntSub] CHECK CONSTRAINT [FK_IntSub_IntSub]
GO
