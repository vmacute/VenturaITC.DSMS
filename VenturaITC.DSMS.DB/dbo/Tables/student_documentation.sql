CREATE TABLE [dbo].[student_documentation] (
    [id]               INT             IDENTITY (1, 1) NOT NULL,
    [student_number]   INT             NOT NULL,
    [document_type]    INT             NOT NULL,
    [document_content] VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_StudentDocumentation_DocumentType] FOREIGN KEY ([document_type]) REFERENCES [dbo].[document_type] ([id]),
    CONSTRAINT [FK_StudentDocumentation_Student] FOREIGN KEY ([student_number]) REFERENCES [dbo].[student] ([number])
);

