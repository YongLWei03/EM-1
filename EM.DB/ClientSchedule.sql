CREATE TABLE [EM].[ClientSchedule]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [RunContinuously] BIT NOT NULL, 
    [RunEverySeconds] INT NOT NULL 
)
