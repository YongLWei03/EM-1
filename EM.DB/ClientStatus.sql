CREATE TABLE [EM].[ClientStatus]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DateTime] DATETIME2 NOT NULL DEFAULT (getdate()), 
    [ClientId] BIGINT NOT NULL, 
    [LastRun] DATETIME2 NOT NULL, 
    [LastLifeSign] DATETIME2 NOT NULL, 
    [NextRun] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_ClientStatus_Client] FOREIGN KEY ([ClientId]) REFERENCES [EM].[Client]([Id]), 
   
)

GO

CREATE TRIGGER [EM].[Trigger_ClientStatus_Insert]
    ON [EM].[ClientStatus]
    FOR UPDATE
    AS
    BEGIN
         -- nothing to do?
    if (@@rowcount = 0)
      return;

    update d
    set 
       DateTime = getdate()
    from
       [EM].[ClientStatus] d join inserted i 
    on 
       d.Id = i.Id;
    END