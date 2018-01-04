CREATE TABLE [dbo].[student_type] (
    [id]   INT          IDENTITY (1, 1) NOT NULL,
    [name] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_StudentType] PRIMARY KEY CLUSTERED ([id] ASC)
);

