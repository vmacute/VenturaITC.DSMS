CREATE TABLE [dbo].[province] (
    [id]   INT           IDENTITY (1, 1) NOT NULL,
    [name] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_province] PRIMARY KEY CLUSTERED ([id] ASC)
);

