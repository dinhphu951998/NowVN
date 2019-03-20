CREATE TABLE [dbo].[Employee] (
    [Id]        VARCHAR (100)  NOT NULL,
    [Username]  VARCHAR (100)  NOT NULL,
    [Password]  VARCHAR (100)  NOT NULL,
    [Fullname]  NVARCHAR (100) NOT NULL,
    [Phone]     VARCHAR (20)   NOT NULL,
    [Mail]      VARCHAR (100)  NOT NULL,
    [Address]   NVARCHAR (100) NOT NULL,
    [Gender]    VARCHAR (20)   DEFAULT ('Other') NULL,
    [Birthdate] DATE           NULL,
    [StartDate] DATE           DEFAULT (getdate()) NOT NULL,
    [EndDate]   DATE           NULL,
    [RoleID]    INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Birthdate]<getdate()),
    CHECK ([Gender]='Male' OR [Gender]='Female' OR [Gender]='Other'),
    CHECK (len([Password])>=(10)),
    FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([Id]),
    UNIQUE NONCLUSTERED ([Mail] ASC),
    UNIQUE NONCLUSTERED ([Phone] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);

