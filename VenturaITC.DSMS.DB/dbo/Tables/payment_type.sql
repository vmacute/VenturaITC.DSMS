CREATE TABLE [dbo].[payment_type] (
    [name]        NVARCHAR (50) NOT NULL,
    [description] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PaymentType2] PRIMARY KEY CLUSTERED ([name] ASC)
);

