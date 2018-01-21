CREATE TABLE [EM].[Client]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [PluginTemplateId] BIGINT NOT NULL, 
    [Name] NVARCHAR(255) NOT NULL UNIQUE, 
    [Enabled] BIT NOT NULL, 
    CONSTRAINT [FK_Client_PluginTemplate] FOREIGN KEY ([PluginTemplateId]) REFERENCES [EM].[PluginTemplate]([Id]) 
)
