﻿CREATE TABLE [EM].[Client]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [TemplateId] BIGINT NOT NULL, 
    [Name] NVARCHAR(255) NOT NULL UNIQUE, 
    CONSTRAINT [FK_Client_Template] FOREIGN KEY ([TemplateId]) REFERENCES [EM].[Template]([Id])
)
