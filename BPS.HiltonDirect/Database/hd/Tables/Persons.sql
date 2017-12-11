CREATE TABLE [hd].[Persons]
(
	[EmailAddress] VARCHAR(100) NOT NULL, 
	[FirstName] VARCHAR(500) NOT NULL, 
    [LastName] VARCHAR(500) NOT NULL, 
    [PhoneNumber] VARCHAR(50) NULL, 
    [OfficeLocation] VARCHAR(100) NULL, 
    [IsActive] BIT NULL, 
    [ModifiedById] VARCHAR(100) NULL, 
    [ModifiedDate] DATETIMEOFFSET NULL, 
    CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED ([EmailAddress] ASC),
)
