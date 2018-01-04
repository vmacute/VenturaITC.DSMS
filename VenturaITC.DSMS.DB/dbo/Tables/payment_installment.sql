CREATE TABLE [dbo].[payment_installment] (
    [id]         INT             NOT NULL,
    [percentage] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_PaymentInstallment_1] PRIMARY KEY CLUSTERED ([id] ASC)
);

