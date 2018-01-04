CREATE TABLE [dbo].[gender] (
    [id]   INT          IDENTITY (1, 1) NOT NULL,
    [name] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED ([id] ASC)
);

