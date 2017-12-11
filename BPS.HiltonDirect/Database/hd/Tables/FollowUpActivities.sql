CREATE TABLE [hd].[FollowUpActivities]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Name] NVARCHAR(50) NOT NULL, 
    [Active] BIT NULL DEFAULT ((1)),
	CONSTRAINT [PK_FollowUpActivities] PRIMARY KEY CLUSTERED ([Id] ASC),
)
