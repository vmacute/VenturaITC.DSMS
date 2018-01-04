CREATE TABLE [dbo].[academic_level] (
    [id]   INT           IDENTITY (1, 1) NOT NULL,
    [name] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_AcademicLevel] PRIMARY KEY CLUSTERED ([id] ASC)
);

