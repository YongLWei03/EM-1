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


DECLARE @LASTID bigint;

INSERT INTO [EM].Template ([DLLName], [FullClassName])
VALUES ('EM.Plugin.Sample', 'EM.Plugin.Sample.SamplePlugin');

SELECT @LASTID=SCOPE_IDENTITY();

INSERT INTO [EM].Client([TemplateID],[Name]) VALUES (@LASTID,'Sample Client');

SELECT @LASTID=SCOPE_IDENTITY();

INSERT INTO [EM].ClientProperty ([ClientId],[Key],[Value])
VALUES (@LASTID,'Name','Sample Client Name.');