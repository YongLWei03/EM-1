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
DECLARE @CLIENTSCHEDULEID bigint;
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
INSERT INTO [EM].ClientSchedule (RunContinuously, RunEverySeconds) VALUES ('TRUE',0);
SELECT @CLIENTSCHEDULEID=SCOPE_IDENTITY();

SELECT @PLUGINTEMPLATEID=ID FROM [EM].PluginTemplate  WHERE FullClassName='EM.Plugin.PrimalPlugin';
INSERT INTO [EM].Client([PluginTemplateId],[Name],[Enabled],[ClientScheduleId]) 
VALUES (@PLUGINTEMPLATEID,'Primal Client','FALSE',@CLIENTSCHEDULEID);
SELECT @CLIENTID=SCOPE_IDENTITY();

INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Name','Primal Client.');
INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Description','The Primal Client starts and runs other clients.');
-- -----------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------
INSERT INTO [EM].ClientSchedule (RunContinuously, RunEverySeconds) VALUES ('TRUE',0);
SELECT @CLIENTSCHEDULEID=SCOPE_IDENTITY();

SELECT @PLUGINTEMPLATEID=ID FROM [EM].PluginTemplate  WHERE FullClassName='EM.Plugin.Sample.SamplePluginForever';
INSERT INTO [EM].Client([PluginTemplateId],[Name],[Enabled],[ClientScheduleId]) 
VALUES (@PLUGINTEMPLATEID,'Run forever client','TRUE',@CLIENTSCHEDULEID);
SELECT @CLIENTID=SCOPE_IDENTITY();

INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Name','Run forever client.');
INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Description','A client that should run continuously.');
-- -----------------------------------------------------------------------------------


-- -----------------------------------------------------------------------------------
INSERT INTO [EM].ClientSchedule (RunContinuously, RunEverySeconds) VALUES ('FALSE',30);
SELECT @CLIENTSCHEDULEID=SCOPE_IDENTITY();

SELECT @PLUGINTEMPLATEID=ID FROM [EM].PluginTemplate WHERE FullClassName='EM.Plugin.Sample.SamplePlugin';
INSERT INTO [EM].Client([PluginTemplateId],[Name],[Enabled],[ClientScheduleId]) 
VALUES (@PLUGINTEMPLATEID,'Sample client','TRUE',@CLIENTSCHEDULEID);
SELECT @CLIENTID=SCOPE_IDENTITY();

INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Name','Sample client.');
INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Description','A client that should run every Y seconds.');
-- -----------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------
INSERT INTO [EM].ClientSchedule (RunContinuously, RunEverySeconds) VALUES ('FALSE',60);
SELECT @CLIENTSCHEDULEID=SCOPE_IDENTITY();

SELECT @PLUGINTEMPLATEID=ID FROM [EM].PluginTemplate WHERE FullClassName='EM.Plugin.Sample.WashUpPlugin';
INSERT INTO [EM].Client([PluginTemplateId],[Name],[Enabled],[ClientScheduleId]) 
VALUES (@PLUGINTEMPLATEID,'WashUp client','TRUE',@CLIENTSCHEDULEID);
SELECT @CLIENTID=SCOPE_IDENTITY();

INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Name','WashUp client.');
INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@CLIENTID,'Description','Cleans the status table.'); 
-- -----------------------------------------------------------------------------------


