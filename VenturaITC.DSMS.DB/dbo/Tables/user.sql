CREATE TABLE [dbo].[user] (
    [username]               NVARCHAR (50)   NOT NULL,
    [full_name]              NVARCHAR (255)  NOT NULL,
    [cell_phone]             NVARCHAR (50)   NOT NULL,
    [email]                  NVARCHAR (50)   NULL,
    [role]                   NVARCHAR (50)   NOT NULL,
    [locked]                 BIT             NOT NULL,
    [disabled]               BIT             NOT NULL,
    [password]               VARBINARY (MAX) NOT NULL,
    [must_change_password]   BIT             NOT NULL,
    [last_password_change]   DATETIME        NULL,
    [logged]                 BIT             NOT NULL,
    [last_login]             DATETIME        NULL,
    [current_login_attempts] INT             NOT NULL,
    [registration_date]      DATETIME        NOT NULL,
    [registration_user]      NVARCHAR (50)   NOT NULL,
    [status]                 NVARCHAR (50)   NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([username] ASC),
    CONSTRAINT [FK_User_DBDataStatus] FOREIGN KEY ([status]) REFERENCES [dbo].[db_data_status] ([name]),
    CONSTRAINT [FK_User_UserRole] FOREIGN KEY ([role]) REFERENCES [dbo].[user_role] ([name])
);

