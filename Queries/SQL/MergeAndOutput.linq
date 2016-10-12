<Query Kind="SQL" />

CREATE PROCEDURE [dbo].[Data_JobQueueType]
AS
PRINT N'JobQueueType: Data loading';

DECLARE @SummaryOfChanges TABLE(Change VARCHAR(20), ID INT, Description Varchar(100), IsContinuousPollingJob BIT);

SET IDENTITY_INSERT JobQueueType ON;

MERGE INTO JobQueueType AS Target 
USING (VALUES 
  (1, 'Email', 1, 0),
  (2, 'MeasureFileUpload', 2, 0),
  (3, 'MeasureFootPrintFileUpload', 1, 0),
  (4, 'VisitAnswersFileUpload', 1, 0),
  (5, 'RemedialResponsesFileUpload', 1, 0),
  (6, 'ReinspectionFileUpload', 1, 0),
  (7, 'OfgemResponseFileUpload', 2, 0),
  (8, 'Lig16FileUpload', 2, 0),
  (9, 'VisitExtract', 1, 0),
  (10, 'OfgemReport', 1, 0),
  (11, 'MeasureRecalculationExportFileExtract', 2, 0),
  (12, 'OfgemExtensionExportFileExtract', 1, 0),
  (13, 'MeasureRecalculationFileUpload', 2, 0),
  (14, 'EvidenceFileUpload', 2, 0),
  (15, 'PropertyHubDocuments', 2, 0),
  (16, 'SyncSubInstallationCompany', 2, 1)
)

AS Source (JobQueueTypeId, Description, JobQueueProcessorId, IsContinuousPollingJob) 
ON Target.JobQueueTypeId = Source.JobQueueTypeId 

-- UPDATE MATCHED ROWS
WHEN MATCHED THEN 
UPDATE SET	
	Description = Source.Description,
	JobQueueProcessorId = Source.JobQueueProcessorId,
	IsContinuousPollingJob = Source.IsContinuousPollingJob


-- INSERT NEW ROWS
WHEN NOT MATCHED BY TARGET THEN 
INSERT (JobQueueTypeId, Description, JobQueueProcessorId, IsContinuousPollingJob) 
VALUES (JobQueueTypeId, Description, JobQueueProcessorId, IsContinuousPollingJob)

-- NOT MATCHED ROWS
WHEN NOT MATCHED BY SOURCE THEN 
DELETE

OUTPUT $action, inserted.JobQueueTypeId, inserted.Description, inserted.IsContinuousPollingJob
	INTO @SummaryOfChanges;

SET IDENTITY_INSERT JobQueueType OFF;

INSERT INTO JobQueue (QueueName, JobDetails, fkJobStatus, JobQueueTypeId, ExecutionDateTime)
	SELECT s.Description, '', 1, s.ID, GETDATE()
	FROM @SummaryOfChanges s
	WHERE s.Change = 'INSERT' AND s.IsContinuousPollingJob = 1
