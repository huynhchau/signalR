CREATE TABLE [hd].[Requests]
(
	[Id] INT NOT NULL IDENTITY(1,1),

	[EchannelRequestId] INT NULL,
	[DirectLeadId] INT NULL,
	[RequestType] INT NULL,

	[CreatedById] VARCHAR(100) NOT NULL, 
    [ModifiedById] VARCHAR(100) NOT NULL, 
    [CreatedDate] DATETIMEOFFSET NOT NULL, 
    [ModifiedDate] DATETIMEOFFSET NOT NULL, 

	CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Requests_CreatedPersons] FOREIGN KEY ([CreatedById]) REFERENCES [hd].[Persons] ([EmailAddress]),
	CONSTRAINT [FK_Requests_ModifiedPersons] FOREIGN KEY ([ModifiedById]) REFERENCES [hd].[Persons] ([EmailAddress]),
	CONSTRAINT [FK_Requests_EchannelRequests] FOREIGN KEY ([EchannelRequestId]) REFERENCES [hd].[EchannelRequests] ([Id]),
	CONSTRAINT [FK_Requests_DirectLeadRequests] FOREIGN KEY ([DirectLeadId]) REFERENCES [hd].[DirectLeadRequests] ([Id]),
)
