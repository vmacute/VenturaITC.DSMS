CREATE TABLE [dbo].[holiday] (
    [day]   INT NOT NULL,
    [month] INT NOT NULL,
    CONSTRAINT [PK_Holiday] PRIMARY KEY CLUSTERED ([day] ASC, [month] ASC)
);

