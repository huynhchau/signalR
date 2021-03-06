USE [BNI]
GO
/****** Object:  Table [dbo].[HD_EmailNotification]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_EmailNotification](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[From] [varchar](100) NOT NULL,
	[To] [varchar](1000) NOT NULL,
	[Subject] [varchar](500) NOT NULL,
	[Body] [varchar](8000) NOT NULL,
	[Sent] [bit] NOT NULL,
	[SentDate] [smalldatetime] NULL,
 CONSTRAINT [PK_HD_EmailNotification] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_EmailExtract2]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_EmailExtract2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RFPCode] [varchar](50) NOT NULL,
	[UserName] [varchar](500) NOT NULL,
	[Role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_HD_EmailExtract2] PRIMARY KEY CLUSTERED 
(
	[RFPCode] ASC,
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_EmailExtract_Event_Obselete]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_EmailExtract_Event_Obselete](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserFormSubmissionsId] [int] NULL,
	[DaySeqNumber] [int] NULL,
	[EventDate] [datetime] NULL,
	[StartTime] [varchar](20) NULL,
	[EndTime] [varchar](20) NULL,
	[EventSetup] [varchar](100) NULL,
	[EventType] [varchar](100) NULL,
	[Attendees] [int] NULL,
	[EventName] [varchar](100) NULL,
	[EmailExtractID] [int] NULL,
 CONSTRAINT [PK_HD_EmailExtract_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_EmailExtract_Attachment]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_EmailExtract_Attachment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](255) NULL,
	[UserFormSubmissionsID] [int] NULL,
	[EmailExtractID] [int] NULL,
	[RFPCode] [varchar](100) NULL,
 CONSTRAINT [PK_HD_EmailExtract_Attachment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_EmailExtract]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_EmailExtract](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RFPCode] [varchar](100) NOT NULL,
	[RFPName] [varchar](100) NULL,
	[SPR] [varchar](100) NULL,
	[Account] [varchar](100) NULL,
	[AccountID] [varchar](50) NULL,
	[AccountContact] [varchar](100) NULL,
	[Agency] [varchar](100) NULL,
	[AgencyID] [varchar](100) NULL,
	[AgencyContact] [varchar](100) NULL,
	[JobStatus] [varchar](50) NULL,
	[FailureReason] [varchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[MachineName] [varchar](50) NULL,
	[IsAccNotFromMasterAccList] [bit] NULL,
	[Admin1] [varchar](100) NULL,
	[Admin2] [varchar](100) NULL,
	[Admin3] [varchar](100) NULL,
	[Admin4] [varchar](100) NULL,
	[Admin5] [varchar](100) NULL,
	[Admin6] [varchar](100) NULL,
	[Admin7] [varchar](100) NULL,
	[Admin8] [varchar](100) NULL,
	[Admin9] [varchar](100) NULL,
	[Admin10] [varchar](100) NULL,
	[CventRFPUrl] [varchar](255) NULL,
	[ExistingLeadID] [varchar](100) NULL,
	[ServiceManager] [varchar](100) NULL,
	[SalesAssistant] [varchar](100) NULL,
	[SharedBkgSPRFullName] [varchar](100) NULL,
	[SharedBookingOffice] [varchar](100) NULL,
	[PartnerSPRFullName] [varchar](100) NULL,
	[PartnerOffice] [varchar](100) NULL,
	[SharedPartnerPercent] [int] NULL,
	[AuthorLocation] [varchar](100) NULL,
	[StaffLocation] [varchar](100) NULL,
	[SpecialtyMarkets] [varchar](100) NULL,
	[MultilYearEventLead] [varchar](10) NULL,
	[IsCommissionable] [bit] NULL,
	[CommissionRate] [varchar](20) NULL,
	[FollowUpActivity] [varchar](20) NULL,
	[MeetingClass] [varchar](100) NULL,
	[SubmittedDate] [datetime] NULL,
	[DecisionDue] [datetime] NULL,
	[Activity] [varchar](100) NULL,
	[CollaborationLetter] [varchar](max) NULL,
	[CollaborationAuthor] [varchar](100) NULL,
	[CollaborationStaff] [varchar](100) NULL,
	[IsCreateTask] [bit] NULL,
	[TaskDueDate] [datetime] NULL,
 CONSTRAINT [PK_HD_EmailExtract_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_EmailAddresses]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_EmailAddresses](
	[First Name] [varchar](50) NOT NULL,
	[Last Name] [varchar](50) NOT NULL,
	[Email Address] [varchar](100) NOT NULL,
	[Phone Number] [varchar](50) NULL,
	[OfficeLocation] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[LastUpdatedBy] [varchar](100) NULL,
	[LastUpdatedDate] [varchar](100) NULL,
 CONSTRAINT [PK_HD_EmailAddresses] PRIMARY KEY CLUSTERED 
(
	[Email Address] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_EmailAddress_Temp]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_EmailAddress_Temp](
	[First Name] [nvarchar](255) NULL,
	[Last Name] [nvarchar](255) NULL,
	[Email Address] [nvarchar](255) NULL,
	[Phone Number] [nvarchar](255) NULL,
	[Office location] [nvarchar](255) NULL,
	[IsActive] [nvarchar](255) NULL,
	[LastUpdatedBy] [nvarchar](255) NULL,
	[LastUpdatedDate] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_DirectLeadVRLog]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_DirectLeadVRLog](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[JobID] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[DebugLevel] [varchar](50) NOT NULL,
	[LogMessage] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_HD_DirectLeadVRLog] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_DirectLead_SleepingRoom]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_DirectLead_SleepingRoom](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NumOfRooms] [int] NOT NULL,
	[Guests] [int] NOT NULL,
	[NightSeqNumber] [int] NOT NULL,
	[UserFormSubmissionsID] [int] NOT NULL,
	[DirectLeadID] [int] NULL,
	[NumOfPeoplePerRoom] [int] NULL,
 CONSTRAINT [PK_DirectLead_SleepingRoom] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_DirectLead_HotelsSourced]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_DirectLead_HotelsSourced](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserFormSubmissionsID] [int] NOT NULL,
	[InnCode] [varchar](10) NULL,
	[PropertyName] [varchar](100) NULL,
	[DirectLeadID] [int] NULL,
 CONSTRAINT [PK_DirectLead_HotelsSourced] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_DirectLead_HiltonLink]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_DirectLead_HiltonLink](
	[JobID] [int] NULL,
	[InputModule] [nvarchar](255) NULL,
	[Ctyhocn] [nvarchar](7) NULL,
	[IATA] [nvarchar](10) NULL,
	[SRP] [nvarchar](10) NULL,
	[ArrivalDate] [date] NULL,
	[DepartureDate] [date] NULL,
	[CID] [nvarchar](255) NULL,
	[FromID] [nvarchar](255) NULL,
	[HiltonLink] [nvarchar](1000) NULL,
	[LeadStatus] [nvarchar](100) NULL,
	[EmailSent] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_DirectLead_EventType]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_DirectLead_EventType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_HD_DirectLead_EventType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_DirectLead_EventSetup]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_DirectLead_EventSetup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_HD_DirectLead_EventSetup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_DirectLead_Event]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_DirectLead_Event](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserFormSubmissionsId] [int] NULL,
	[DaySeqNumber] [int] NULL,
	[EventDate] [datetime] NULL,
	[StartTime] [varchar](20) NULL,
	[EndTime] [varchar](20) NULL,
	[EventSetup] [varchar](100) NULL,
	[EventType] [varchar](100) NULL,
	[Attendees] [int] NULL,
	[EventName] [varchar](100) NULL,
	[DirectLeadID] [int] NULL,
 CONSTRAINT [PK_HD_DirectLead_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_DirectLead_Attachment]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_DirectLead_Attachment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](255) NULL,
	[UserFormSubmissionsID] [int] NULL,
	[DirectLeadID] [int] NULL,
 CONSTRAINT [PK_HD_DirectLead_Attachment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_DirectLead]    Script Date: 09/12/2017 09:48:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_DirectLead](
	[JobID] [int] IDENTITY(1,1) NOT NULL,
	[JobStatus] [varchar](50) NULL,
	[StepCompleted] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[FailureReason] [varchar](50) NULL,
	[MachineName] [varchar](50) NULL,
	[HQUsername] [varchar](50) NULL,
	[CreatedLeadID] [int] NULL,
	[FollowUpActivityCreated] [bit] NULL,
	[InnCodesNotFound] [varchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[SPR] [varchar](100) NULL,
	[Admin1] [varchar](100) NULL,
	[IsRMCC] [bit] NULL,
	[ExistingLeadID] [varchar](100) NULL,
	[AccountName] [varchar](100) NULL,
	[ClientName] [varchar](100) NULL,
	[ClientPhone] [varchar](100) NULL,
	[ClientTitle] [varchar](40) NULL,
	[ClientEmail] [varchar](100) NULL,
	[IsNewContact] [bit] NULL,
	[AgencyName] [varchar](100) NULL,
	[AgencyContact] [varchar](100) NULL,
	[AgencyPhone] [varchar](100) NULL,
	[AgencyTitle] [varchar](40) NULL,
	[AgencyEmail] [varchar](100) NULL,
	[IsNewAgencyContact] [bit] NULL,
	[ServiceManager] [varchar](100) NULL,
	[SalesAssistant] [varchar](100) NULL,
	[SharedBkgSPRFullName] [varchar](100) NULL,
	[SharedBookingOffice] [varchar](100) NULL,
	[PartnerSPRFullName] [varchar](100) NULL,
	[PartnerOffice] [varchar](100) NULL,
	[SharedPartnerPercent] [int] NULL,
	[SpecialtyMarkets] [varchar](100) NULL,
	[MultiYearEventLead] [varchar](100) NULL,
	[PostAs] [varchar](100) NULL,
	[PreferredDate] [datetime] NULL,
	[PreferredNights] [int] NULL,
	[AlternateDate] [datetime] NULL,
	[AlternateNights] [int] NULL,
	[DecisionDue] [datetime] NULL,
	[FollowUpActivity] [varchar](20) NULL,
	[GuestroomComments] [varchar](8000) NULL,
	[IsVariableRoomCountsByNight] [bit] NULL,
	[BudgetedRate] [money] NULL,
	[HousingMethod] [varchar](100) NULL,
	[FoodBeverage] [bit] NULL,
	[IsCommissionable] [bit] NULL,
	[Commission] [varchar](100) NULL,
	[LeadSource] [varchar](100) NULL,
	[LeadType] [varchar](100) NULL,
	[MeetingClass] [varchar](100) NULL,
	[MeetingProfile] [varchar](100) NULL,
	[IsNSOLeadCmt] [bit] NULL,
	[ResourcesBudget] [varchar](8000) NULL,
	[History] [varchar](8000) NULL,
	[HotButtons] [varchar](8000) NULL,
	[Competition] [varchar](8000) NULL,
	[DecisionMaker] [varchar](8000) NULL,
	[NextSteps] [varchar](8000) NULL,
	[RemarksNextAction] [varchar](8000) NULL,
	[Notes] [varchar](8000) NULL,
	[LeadComments] [varchar](max) NULL,
	[IsBusinessDev] [bit] NULL,
	[NumOfEventPlan] [int] NULL,
	[AreEventsSameOrg] [varchar](20) NULL,
	[NumOfPeopleEvent] [int] NULL,
	[NumOfRoomRequired] [int] NULL,
	[RequireMeetingSpace] [varchar](20) NULL,
	[EventLocation] [varchar](100) NULL,
	[IsPersonMakeDecision] [varchar](20) NULL,
	[MakeDecisionNote] [varchar](1000) NULL,
	[IsInvolvedEvent] [varchar](20) NULL,
	[InvolvedEventNote] [varchar](1000) NULL,
	[NeedIndividualTravel] [varchar](20) NULL,
	[NeedIndividualTravelNote] [varchar](1000) NULL,
	[PersonManageTravelReq] [varchar](20) NULL,
	[PersonManageTravelReqNote] [varchar](1000) NULL,
	[SendLeadImmediately] [bit] NULL,
	[IsCreateTask] [bit] NULL,
	[TaskDueDate] [datetime] NULL,
 CONSTRAINT [PK_HD_CVentExtract] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_HD_DirectLead_SendImmediately]    Script Date: 09/12/2017 09:48:34 ******/
ALTER TABLE [dbo].[HD_DirectLead] ADD  CONSTRAINT [DF_HD_DirectLead_SendImmediately]  DEFAULT ((0)) FOR [SendLeadImmediately]
GO
/****** Object:  Default [DF_HD_EmailExtract_IsAccNotFromMasterAccList]    Script Date: 09/12/2017 09:48:34 ******/
ALTER TABLE [dbo].[HD_EmailExtract] ADD  CONSTRAINT [DF_HD_EmailExtract_IsAccNotFromMasterAccList]  DEFAULT ((0)) FOR [IsAccNotFromMasterAccList]
GO
/****** Object:  Default [DF_HD_EmailNotification_Sent]    Script Date: 09/12/2017 09:48:34 ******/
ALTER TABLE [dbo].[HD_EmailNotification] ADD  CONSTRAINT [DF_HD_EmailNotification_Sent]  DEFAULT ((0)) FOR [Sent]
GO
