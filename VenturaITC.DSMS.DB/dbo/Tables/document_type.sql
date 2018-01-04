CREATE TABLE [dbo].[document_type] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [name]      VARCHAR (255) NOT NULL,
    [file_name] VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_StudentDocumentationType_1] PRIMARY KEY CLUSTERED ([id] ASC)
);

