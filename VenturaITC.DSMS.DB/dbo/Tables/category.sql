CREATE TABLE [dbo].[category] (
    [id]   INT             IDENTITY (1, 1) NOT NULL,
    [name] VARCHAR (255)   NOT NULL,
    [cost] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Category_1] PRIMARY KEY CLUSTERED ([id] ASC)
);

