CREATE TABLE [EM].[ClientStatus]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DateTime] DATETIME2 NOT NULL, 
    [ClientId] BIGINT NOT NULL, 
    [LastRun] DATETIME2 NOT NULL, 
    [LastLifeSign] DATETIME2 NOT NULL, 
    [NextRun] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_ClientStatus_Client] FOREIGN KEY ([ClientId]) REFERENCES [EM].[Client]([Id])
)
