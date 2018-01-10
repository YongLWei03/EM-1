CREATE TABLE [EM].[Client]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [TemplateId] BIGINT NOT NULL, 
    [Name] NVARCHAR(255) NOT NULL UNIQUE, 
    [Enabled] BIT NOT NULL, 
    [RunContinously] BIT NOT NULL, 
    [RunEverySeconds] INT NOT NULL, 
    [LastRun] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Client_Template] FOREIGN KEY ([TemplateId]) REFERENCES [EM].[Template]([Id])
)
