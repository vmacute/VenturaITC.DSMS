CREATE TABLE [dbo].[student_payment] (
    [receipt_number]     INT             NOT NULL,
    [student_number]     INT             NOT NULL,
    [installment_number] INT             NULL,
    [amount]             DECIMAL (18, 2) NOT NULL,
    [total_paid_amount]  DECIMAL (18, 2) NOT NULL,
    [remaining_amount]   DECIMAL (18, 2) NOT NULL,
    [username]           NVARCHAR (50)   NOT NULL,
    [date]               DATETIME        NOT NULL,
    CONSTRAINT [PK_StudentPayment] PRIMARY KEY CLUSTERED ([receipt_number] ASC),
    CONSTRAINT [FK_StudentPayment_Student] FOREIGN KEY ([student_number]) REFERENCES [dbo].[student] ([number]),
    CONSTRAINT [FK_StudentPayment_User] FOREIGN KEY ([username]) REFERENCES [dbo].[user] ([username])
);

