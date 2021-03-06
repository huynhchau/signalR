USE [BNI]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_NoteHistory]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_NoteHistory](
	[JobID] [int] IDENTITY(1,1) NOT NULL,
	[JobStatus] [varchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[MachineName] [varchar](50) NULL,
	[HQUsername] [varchar](50) NULL,
	[FailureReason] [varchar](50) NULL,
	[UserFormSubmissionsID] [int] NULL,
	[GSELeadID] [int] NULL,
	[RFPID] [int] NULL,
	[PropertyName] [nvarchar](100) NULL,
	[Note] [nvarchar](500) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedWhen] [datetime] NULL,
	[ID] [int] NULL,
	[InnCode] [varchar](10) NULL,
	[NewRFPID] [int] NULL,
	[IsSendToGSE] [bit] NULL,
	[NoteType] [nvarchar](20) NULL,
 CONSTRAINT [PK_AuditAutomation_NoteHistory] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_NewRFPID_Note]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_NewRFPID_Note](
	[NewRFPIDNoteID] [int] IDENTITY(1,1) NOT NULL,
	[JobID] [int] NULL,
	[ID] [int] NULL,
	[RFPID] [int] NULL,
	[NewRFPID] [int] NULL,
 CONSTRAINT [PK_AuditAutomation_NewRFPID_Note] PRIMARY KEY CLUSTERED 
(
	[NewRFPIDNoteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_LeadStatus]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_LeadStatus](
	[StatusID] [int] NOT NULL,
	[StatusName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_InternalStatus]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_InternalStatus](
	[StatusID] [int] NOT NULL,
	[StatusName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_GSELeadID_Hotels]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_GSELeadID_Hotels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserFormSubmissionsID] [int] NOT NULL,
	[GSELeadID] [int] NULL,
	[PropertyName] [varchar](100) NULL,
	[InnCode] [varchar](10) NULL,
	[RFPID] [int] NULL,
	[ArrivalDate] [datetime] NULL,
	[DepartureDate] [datetime] NULL,
	[AVGRate] [money] NULL,
	[ContractedAVGRate] [money] NULL,
	[TotalRevenue] [money] NULL,
	[ContractedTotalRevenue] [money] NULL,
	[TotalRooms] [int] NULL,
	[ContractedTotalRooms] [int] NULL,
	[HotelContactName] [varchar](100) NULL,
	[HotelContactPhone] [varchar](20) NULL,
	[HotelContactEmail] [varchar](100) NULL,
	[OriginalLeadContractedTotals] [varchar](100) NULL,
	[ReasonAuditNotes] [varchar](8000) NULL,
	[AuditPerformBDO] [varchar](10) NULL,
	[InternalStatusID] [int] NULL,
	[AuditTeamMember] [nvarchar](50) NULL,
	[AssignTo] [varchar](100) NULL,
	[AuditLeadStatus] [int] NULL,
	[PropertyType] [nvarchar](50) NULL,
	[SPROffice] [nvarchar](50) NULL,
	[DateSubmitted] [datetime] NULL,
	[Channel] [varchar](100) NULL,
	[CurrentStatus] [nvarchar](150) NULL,
	[BusinessDataStatus] [nvarchar](50) NULL,
	[IsNoContract] [bit] NULL,
	[TeamLeadNote] [varchar](8000) NULL,
	[LastUpdated] [datetime] NULL,
	[RowColor] [varchar](10) NULL,
	[NewRFPID] [int] NULL,
	[Division] [varchar](50) NULL,
	[MaxPeakBlockedRooms] [int] NULL,
	[SPR] [varchar](100) NULL,
	[AccountName] [varchar](100) NULL,
	[PostAs] [varchar](100) NULL,
	[AgencyName] [varchar](100) NULL,
	[MasterSalesSystem] [varchar](255) NULL,
 CONSTRAINT [PK_GSELeadID_Hotels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_Form]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_Form](
	[UserFormSubmissionsID] [int] NOT NULL,
	[GSELeadID] [int] NULL,
	[SPR] [varchar](100) NULL,
	[AccountName] [varchar](100) NULL,
	[PostAs] [varchar](100) NULL,
	[AgencyName] [varchar](100) NULL,
	[DateSubmitted] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
 CONSTRAINT [PK_AuditAutomation_Form] PRIMARY KEY CLUSTERED 
(
	[UserFormSubmissionsID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_EmailHistory]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_EmailHistory](
	[UserFormSubmissionsID] [int] NULL,
	[GSELeadID] [int] NULL,
	[RFPID] [int] NULL,
	[EmailTo] [char](100) NULL,
	[TemplateID] [int] NULL,
	[UpdateBy] [nvarchar](50) NULL,
	[UpdateWhen] [datetime] NULL,
	[StatusID] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_CurrentStatusHistory]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_CurrentStatusHistory](
	[UserFormSubmissionsID] [int] NULL,
	[GSELeadID] [int] NULL,
	[RFPID] [int] NULL,
	[Status] [nvarchar](150) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedWhen] [datetime] NULL,
	[ID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_BusinessDataHistory]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_BusinessDataHistory](
	[UserFormSubmissionsID] [int] NULL,
	[GSELeadID] [int] NULL,
	[RFPID] [int] NULL,
	[Status] [nvarchar](150) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedWhen] [datetime] NULL,
	[ID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_AssignToMemberHistory]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_AssignToMemberHistory](
	[UserFormSubmissionsID] [int] NULL,
	[GSELeadID] [int] NULL,
	[RFPID] [int] NULL,
	[Member] [nvarchar](150) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedWhen] [datetime] NULL,
	[ID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_WC_MB_RFP_TRAN_F]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_WC_MB_RFP_TRAN_F](
	[RFP_WID] [int] NULL,
	[REF_NBR] [nvarchar](60) NULL,
	[CURRENT_FLG] [nvarchar](10) NULL,
	[RFP_DATA_STAT_TYP_WID] [int] NULL,
	[RCVR_STR_INN_ID] [int] NULL,
	[ARRVL_DT_WID] [int] NULL,
	[DEPRT_DT_WID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_WC_MB_RFP_D]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_WC_MB_RFP_D](
	[ROW_WID] [int] NOT NULL,
	[RFPID] [int] NULL,
	[GSELeadID] [int] NULL,
	[AVGRate] [decimal](18, 2) NULL,
	[TotalRevenue] [decimal](18, 2) NULL,
	[TotalRooms] [int] NULL,
	[Channel] [nvarchar](500) NULL,
	[SPROffice] [nvarchar](255) NULL,
	[REF_NBR] [nvarchar](60) NULL,
	[AccountName] [nvarchar](255) NULL,
	[AgencyName] [nvarchar](255) NULL,
	[PostAs] [nvarchar](255) NULL,
	[SPR] [nvarchar](255) NULL,
 CONSTRAINT [PK_HD_AuditAutomation_WC_MB_RFP_D] PRIMARY KEY CLUSTERED 
(
	[ROW_WID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_W_PROPERTY_D]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_W_PROPERTY_D](
	[STR_INN_ID] [int] NOT NULL,
	[INNCODE] [nvarchar](255) NULL,
	[HOTEL_NAME] [nvarchar](255) NULL,
	[USERNAME] [nvarchar](255) NULL,
	[FACILITY_LEGAL_NAME] [nvarchar](255) NULL,
 CONSTRAINT [PK_HD_AuditAutomation_W_PROPERTY_D] PRIMARY KEY CLUSTERED 
(
	[STR_INN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_V_WC_MB_DATA_STAT_TYPE]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_V_WC_MB_DATA_STAT_TYPE](
	[RFP_DATA_STAT_TYP_WID] [int] NULL,
	[REF_LKP_NM] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_Team]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_Team](
	[UserEmail] [nvarchar](50) NOT NULL,
	[UserID] [nvarchar](25) NULL,
	[FirstName] [nvarchar](25) NULL,
	[LastName] [nvarchar](25) NULL,
	[Role] [nvarchar](50) NULL,
	[UserEmailSignature] [nvarchar](2000) NULL,
 CONSTRAINT [PK_AuditAutomation_Team] PRIMARY KEY CLUSTERED 
(
	[UserEmail] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_SalesSysHotelList]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_SalesSysHotelList](
	[InnCode] [nvarchar](10) NOT NULL,
	[MasterSalesSystem] [nvarchar](100) NULL,
	[PropertyType] [nvarchar](100) NULL,
 CONSTRAINT [PK_HD_AuditAutomation_SalesSysHotelList] PRIMARY KEY CLUSTERED 
(
	[InnCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_Ref_EmailTemplates]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_Ref_EmailTemplates](
	[rEtID] [int] IDENTITY(1,1) NOT NULL,
	[rEtName] [nvarchar](255) NOT NULL,
	[rEtFrom] [nvarchar](255) NULL,
	[rEtTo] [nvarchar](2000) NULL,
	[rEtCC] [nvarchar](2000) NULL,
	[rEtBCC] [nvarchar](2000) NULL,
	[rEtSubject] [nvarchar](255) NOT NULL,
	[rEtBody] [nvarchar](max) NOT NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_EmailTemplates] PRIMARY KEY CLUSTERED 
(
	[rEtID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique Identifier' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HD_AuditAutomation_Ref_EmailTemplates', @level2type=N'COLUMN',@level2name=N'rEtID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the email template' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HD_AuditAutomation_Ref_EmailTemplates', @level2type=N'COLUMN',@level2name=N'rEtName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Who is this email from' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HD_AuditAutomation_Ref_EmailTemplates', @level2type=N'COLUMN',@level2name=N'rEtFrom'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Who is this email going to' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HD_AuditAutomation_Ref_EmailTemplates', @level2type=N'COLUMN',@level2name=N'rEtTo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Who will be copied on the email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HD_AuditAutomation_Ref_EmailTemplates', @level2type=N'COLUMN',@level2name=N'rEtCC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Who should be blind copied' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HD_AuditAutomation_Ref_EmailTemplates', @level2type=N'COLUMN',@level2name=N'rEtBCC'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Subject line of the email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HD_AuditAutomation_Ref_EmailTemplates', @level2type=N'COLUMN',@level2name=N'rEtSubject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Body of the email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HD_AuditAutomation_Ref_EmailTemplates', @level2type=N'COLUMN',@level2name=N'rEtBody'
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_Ref_EmailFieldTypes]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_Ref_EmailFieldTypes](
	[rEftID] [int] IDENTITY(1,1) NOT NULL,
	[rEftType] [nvarchar](50) NOT NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_AuditAutomation_Ref_EmailFieldTypes] PRIMARY KEY CLUSTERED 
(
	[rEftID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HD_AuditAutomation_Ref_EmailFields]    Script Date: 09/11/2017 15:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HD_AuditAutomation_Ref_EmailFields](
	[rEfID] [int] IDENTITY(1,1) NOT NULL,
	[rEfFieldName] [nvarchar](50) NOT NULL,
	[rEfValueTable] [nvarchar](255) NOT NULL,
	[rEfValueField] [nvarchar](255) NOT NULL,
	[rEftID] [int] NOT NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_AuditAutomation_Ref_EmailFields] PRIMARY KEY CLUSTERED 
(
	[rEfID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_AuditAutomation_AssignToMemberHistory_UpdatedWhen]    Script Date: 09/11/2017 15:24:36 ******/
ALTER TABLE [dbo].[HD_AuditAutomation_AssignToMemberHistory] ADD  CONSTRAINT [DF_AuditAutomation_AssignToMemberHistory_UpdatedWhen]  DEFAULT (getdate()) FOR [UpdatedWhen]
GO
/****** Object:  Default [DF_AuditAutomation_BusinessDataHistory_UpdatedWhen]    Script Date: 09/11/2017 15:24:36 ******/
ALTER TABLE [dbo].[HD_AuditAutomation_BusinessDataHistory] ADD  CONSTRAINT [DF_AuditAutomation_BusinessDataHistory_UpdatedWhen]  DEFAULT (getdate()) FOR [UpdatedWhen]
GO
/****** Object:  Default [DF_AuditAutomation_CurrentStatusHistory_UpdatedWhen]    Script Date: 09/11/2017 15:24:36 ******/
ALTER TABLE [dbo].[HD_AuditAutomation_CurrentStatusHistory] ADD  CONSTRAINT [DF_AuditAutomation_CurrentStatusHistory_UpdatedWhen]  DEFAULT (getdate()) FOR [UpdatedWhen]
GO
/****** Object:  Default [DF_AuditAutomation_GSELeadID_Hotels_DateSubmitted]    Script Date: 09/11/2017 15:24:36 ******/
ALTER TABLE [dbo].[HD_AuditAutomation_GSELeadID_Hotels] ADD  CONSTRAINT [DF_AuditAutomation_GSELeadID_Hotels_DateSubmitted]  DEFAULT (getdate()) FOR [DateSubmitted]
GO
/****** Object:  Default [DF_AuditAutomation_GSELeadID_Hotels_CurrentStatus]    Script Date: 09/11/2017 15:24:36 ******/
ALTER TABLE [dbo].[HD_AuditAutomation_GSELeadID_Hotels] ADD  CONSTRAINT [DF_AuditAutomation_GSELeadID_Hotels_CurrentStatus]  DEFAULT ('New') FOR [CurrentStatus]
GO
/****** Object:  Default [DF_AuditAutomation_NoteHistory_UpdatedWhen]    Script Date: 09/11/2017 15:24:36 ******/
ALTER TABLE [dbo].[HD_AuditAutomation_NoteHistory] ADD  CONSTRAINT [DF_AuditAutomation_NoteHistory_UpdatedWhen]  DEFAULT (getdate()) FOR [UpdatedWhen]
GO
/****** Object:  ForeignKey [FK_Ref_EmailFields_Ref_EmailFieldTypes]    Script Date: 09/11/2017 15:24:36 ******/
ALTER TABLE [dbo].[HD_AuditAutomation_Ref_EmailFields]  WITH CHECK ADD  CONSTRAINT [FK_Ref_EmailFields_Ref_EmailFieldTypes] FOREIGN KEY([rEftID])
REFERENCES [dbo].[HD_AuditAutomation_Ref_EmailFieldTypes] ([rEftID])
GO
ALTER TABLE [dbo].[HD_AuditAutomation_Ref_EmailFields] CHECK CONSTRAINT [FK_Ref_EmailFields_Ref_EmailFieldTypes]
GO
