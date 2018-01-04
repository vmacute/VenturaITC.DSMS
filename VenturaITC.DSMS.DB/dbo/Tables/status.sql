CREATE TABLE [dbo].[status] (
    [id]   INT          IDENTITY (1, 1) NOT NULL,
    [name] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED ([id] ASC)
);

