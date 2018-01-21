/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


-- -----------------------------------------------------------------------------------
DECLARE @CLIENTID bigint;
DECLARE @PLUGINTEMPLATEID bigint;
-- -----------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------
INSERT INTO [EM].PluginTemplate ([DLLName], [FullClassName])
VALUES ('EM.Plugin.dll', 'EM.Plugin.PrimalPlugin');

INSERT INTO [EM].PluginTemplate  ([DLLName], [FullClassName])
VALUES ('EM.Plugin.Sample.dll', 'EM.Plugin.Sample.SamplePlugin');

INSERT INTO [EM].PluginTemplate  ([DLLName], [FullClassName])
VALUES ('EM.Plugin.Sample.dll', 'EM.Plugin.Sample.SamplePluginForever');

INSERT INTO [EM].PluginTemplate  ([DLLName], [FullClassName])
VALUES ('EM.Plugin.Sample.dll', 'EM.Plugin.Sample.WashUpPlugin');
-- -----------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------
SELECT @PLUGINTEMPLATEID=ID FROM [EM].PluginTemplate  WHERE FullClassName='EM.Plugin.PrimalPlugin';
INSERT INTO [EM].Client([PluginTemplateId],[Name],[Enabled]) 
VALUES (@PLUGINTEMPLATEID,'Primal Client','FALSE');
SELECT @CLIENTID=SCOPE_IDENTITY();

INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Name','Primal Client.');
INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Description','The Primal Client starts and runs other clients.');

INSERT INTO [EM].ClientSchedule (ClientId, RunContinuously, RunEverySeconds) VALUES (@CLIENTID,'TRUE',0);
-- -----------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------
SELECT @PLUGINTEMPLATEID=ID FROM [EM].PluginTemplate  WHERE FullClassName='EM.Plugin.Sample.SamplePluginForever';
INSERT INTO [EM].Client([PluginTemplateId],[Name],[Enabled]) 
VALUES (@PLUGINTEMPLATEID,'Run forever client','TRUE');
SELECT @CLIENTID=SCOPE_IDENTITY();

INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Name','Run forever client.');
INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Description','A client that should run continuously.');

INSERT INTO [EM].ClientSchedule (ClientId, RunContinuously, RunEverySeconds) VALUES (@CLIENTID,'TRUE',0);
-- -----------------------------------------------------------------------------------


-- -----------------------------------------------------------------------------------
SELECT @PLUGINTEMPLATEID=ID FROM [EM].PluginTemplate WHERE FullClassName='EM.Plugin.Sample.SamplePlugin';
INSERT INTO [EM].Client([PluginTemplateId],[Name],[Enabled]) 
VALUES (@PLUGINTEMPLATEID,'Sample client','TRUE');
SELECT @CLIENTID=SCOPE_IDENTITY();

INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Name','Sample client.');
INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Description','A client that should run every Y seconds.');

INSERT INTO [EM].ClientSchedule (ClientId, RunContinuously, RunEverySeconds) VALUES (@CLIENTID, 'FALSE',30);
-- -----------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------
SELECT @PLUGINTEMPLATEID=ID FROM [EM].PluginTemplate WHERE FullClassName='EM.Plugin.Sample.WashUpPlugin';
INSERT INTO [EM].Client([PluginTemplateId],[Name],[Enabled]) 
VALUES (@PLUGINTEMPLATEID,'WashUp client','TRUE');
SELECT @CLIENTID=SCOPE_IDENTITY();

INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Name','WashUp client.');
INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Description','Cleans the status table.'); 

INSERT INTO [EM].ClientSchedule (ClientId, RunContinuously, RunEverySeconds) VALUES (@CLIENTID, 'FALSE',60);
-- -----------------------------------------------------------------------------------


