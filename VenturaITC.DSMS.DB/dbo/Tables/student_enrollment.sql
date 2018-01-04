CREATE TABLE [dbo].[student_enrollment] (
    [id]              INT           IDENTITY (1, 1) NOT NULL,
    [student_number]  INT           NOT NULL,
    [category]        NVARCHAR (50) NOT NULL,
    [enrollment_date] DATETIME      NOT NULL,
    [enrollment_user] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_StudentRegistration] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_StudentRegistration_Student] FOREIGN KEY ([student_number]) REFERENCES [dbo].[student] ([number]),
    CONSTRAINT [FK_StudentRegistration_User] FOREIGN KEY ([enrollment_user]) REFERENCES [dbo].[user] ([username])
);

