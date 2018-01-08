CREATE TABLE [EM].[ClientProperty]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientId] BIGINT NOT NULL, 
    [Key] NVARCHAR(255) NOT NULL, 
    [Value] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_ClientProperty_Client] FOREIGN KEY ([ClientId]) REFERENCES [EM].[Client]([Id]) 
)
