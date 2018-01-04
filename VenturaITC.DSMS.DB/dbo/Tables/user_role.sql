CREATE TABLE [dbo].[user_role] (
    [name]        NVARCHAR (50) NOT NULL,
    [description] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([name] ASC)
);

