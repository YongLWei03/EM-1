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
DECLARE @LASTID bigint;
DECLARE @TEMPLATEID bigint;
-- -----------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------
INSERT INTO [EM].Template ([DLLName], [FullClassName])
VALUES ('EM.Plugin.dll', 'EM.Plugin.PrimalPlugin');

INSERT INTO [EM].Template ([DLLName], [FullClassName])
VALUES ('EM.Plugin.Sample.dll', 'EM.Plugin.Sample.SamplePlugin');

INSERT INTO [EM].Template ([DLLName], [FullClassName])
VALUES ('EM.Plugin.Sample.dll', 'EM.Plugin.Sample.SamplePluginForever');
-- -----------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------
SELECT @TEMPLATEID=ID FROM [EM].Template WHERE FullClassName='EM.Plugin.PrimalPlugin';
INSERT INTO [EM].Client([TemplateID],[Name],[Enabled],[RunContinously],[RunEverySeconds],[LastRun]) 
VALUES (@TEMPLATEID,'Primal Client','TRUE','TRUE',0,'1900-01-01');

SELECT @LASTID=SCOPE_IDENTITY();

INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@LASTID,'Name','Primal Client.');
INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@LASTID,'Description','The Primal Client starts and runs other clients.');
-- -----------------------------------------------------------------------------------

-- -----------------------------------------------------------------------------------
SELECT @TEMPLATEID=ID FROM [EM].Template WHERE FullClassName='EM.Plugin.Sample.SamplePluginForever';
INSERT INTO [EM].Client([TemplateID],[Name],[Enabled],[RunContinously],[RunEverySeconds],[LastRun]) 
VALUES (@TEMPLATEID,'Run forever client','TRUE','TRUE',0,'1900-01-01');

SELECT @LASTID=SCOPE_IDENTITY();

INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@LASTID,'Name','Run forever client.');
-- -----------------------------------------------------------------------------------


-- -----------------------------------------------------------------------------------
SELECT @TEMPLATEID=ID FROM [EM].Template WHERE FullClassName='EM.Plugin.Sample.SamplePlugin';
INSERT INTO [EM].Client([TemplateID],[Name],[Enabled],[RunContinously],[RunEverySeconds],[LastRun]) 
VALUES (@TEMPLATEID,'Sample client','TRUE','FALSE',10,'1900-01-01');

SELECT @LASTID=SCOPE_IDENTITY();

INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@LASTID,'Name','Sample client.');
-- -----------------------------------------------------------------------------------


