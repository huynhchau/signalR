CREATE TABLE [hd].[DirectLeadRequests]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[SPRId] VARCHAR(100) NULL, 
    [Admin1Id] VARCHAR(100) NULL, 
	[Note] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_DirectLeadRequests] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_DirectLeadRequests_SPRPersons] FOREIGN KEY ([SPRId]) REFERENCES [hd].[Persons] ([EmailAddress]),
	CONSTRAINT [FK_DirectLeadRequests_Admin1] FOREIGN KEY ([Admin1Id]) REFERENCES [hd].[Persons] ([EmailAddress]),
)
