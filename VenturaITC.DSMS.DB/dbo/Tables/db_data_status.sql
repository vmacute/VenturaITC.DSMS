CREATE TABLE [dbo].[db_data_status] (
    [name]        NVARCHAR (50) NOT NULL,
    [description] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_DataStatus] PRIMARY KEY CLUSTERED ([name] ASC)
);

