CREATE TABLE [dbo].[payment_status] (
    [name]        NVARCHAR (50) NOT NULL,
    [description] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PaymentStatus] PRIMARY KEY CLUSTERED ([name] ASC)
);

