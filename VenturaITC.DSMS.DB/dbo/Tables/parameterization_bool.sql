CREATE TABLE [dbo].[parameterization_bool] (
    [parameter_key]   NVARCHAR (100) NOT NULL,
    [parameter_value] BIT            NOT NULL,
    CONSTRAINT [PK_BoolParameterization] PRIMARY KEY CLUSTERED ([parameter_key] ASC)
);

