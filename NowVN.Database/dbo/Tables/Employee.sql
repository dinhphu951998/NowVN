CREATE TABLE [dbo].[Employee] (
    [Id]           VARCHAR (100)   NOT NULL,
    [Username]     VARCHAR (100)   NOT NULL,
    [PasswordHash] VARBINARY (MAX) NOT NULL,
    [PasswordSalt] VARBINARY (MAX) NOT NULL,
    [Fullname]     NVARCHAR (100)  NOT NULL,
    [Phone]        VARCHAR (20)    NOT NULL,
    [Mail]         VARCHAR (100)   NULL,
    [Address]      NVARCHAR (MAX)  NULL,
    [Gender]       VARCHAR (20)    DEFAULT ('Other') NULL,
    [Birthdate]    DATE            NULL,
    [StartDate]    DATE            DEFAULT (getdate()) NOT NULL,
    [EndDate]      DATE            NULL,
    [RoleID]       INT             NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Birthdate]<getdate()),
    CHECK ([Gender]='Male' OR [Gender]='Female' OR [Gender]='Other'),
    FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([Id]),
    UNIQUE NONCLUSTERED ([Mail] ASC),
    UNIQUE NONCLUSTERED ([Phone] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);



