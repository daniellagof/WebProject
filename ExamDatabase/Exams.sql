CREATE TABLE [dbo].[Exams]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] VARCHAR(50) NULL, 
    [TeacherId] INT NULL, 
    [DateStarted] DATETIME NULL, 
    [DurationMinuets] INT NULL
)
