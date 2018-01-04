CREATE TABLE [dbo].[parameterization] (
    [parameter_key]   NVARCHAR (100) NOT NULL,
    [parameter_value] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Parameterization] PRIMARY KEY CLUSTERED ([parameter_key] ASC)
);

