CREATE TABLE [EM].[ClientSchedule]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [RunContinuously] BIT NOT NULL, 
    [RunEverySeconds] INT NOT NULL, 
    [ClientId] BIGINT NOT NULL, 
    CONSTRAINT [FK_ClientSchedule_Client] FOREIGN KEY ([ClientId]) REFERENCES [EM].[Client]([Id]) 
)
