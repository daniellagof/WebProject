CREATE TABLE [dbo].[Exams] (
    [Id]              INT          NOT NULL,
    [Title]           VARCHAR (50) NULL,
    [TeachrId]        INT          NULL,
    [DurationMinutes] INT          NULL,
    [DateStarted] DATETIME NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

