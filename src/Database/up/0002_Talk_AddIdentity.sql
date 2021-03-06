/*
   Saturday, June 11, 201612:22:00 AM
   User: 
   Server: .
   Database: SpeakR
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Talk
	DROP CONSTRAINT FK_Lecture_Presentation
GO
ALTER TABLE dbo.Presentation SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Talk
	(
	Id bigint NOT NULL IDENTITY (1, 1),
	PresentationId bigint NOT NULL,
	Code nvarchar(5) NOT NULL,
	Title nvarchar(100) NULL,
	StartDate datetime NULL,
	EndDate datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Talk SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Talk ON
GO
IF EXISTS(SELECT * FROM dbo.Talk)
	 EXEC('INSERT INTO dbo.Tmp_Talk (Id, PresentationId, Code, Title, StartDate, EndDate)
		SELECT Id, PresentationId, Code, Title, StartDate, EndDate FROM dbo.Talk WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Talk OFF
GO
ALTER TABLE dbo.Feedback
	DROP CONSTRAINT FK_Feedback_Lecture
GO
DROP TABLE dbo.Talk
GO
EXECUTE sp_rename N'dbo.Tmp_Talk', N'Talk', 'OBJECT' 
GO
ALTER TABLE dbo.Talk ADD CONSTRAINT
	PK_Lecture PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Talk ADD CONSTRAINT
	FK_Lecture_Presentation FOREIGN KEY
	(
	PresentationId
	) REFERENCES dbo.Presentation
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Feedback ADD CONSTRAINT
	FK_Feedback_Lecture FOREIGN KEY
	(
	TalkId
	) REFERENCES dbo.Talk
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Feedback SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
