CREATE TABLE [dbo].[Customer] (
    [Id]        VARCHAR (100)  NOT NULL,
    [Username]  VARCHAR (100)  NOT NULL,
    [Password]  VARCHAR (100)  NOT NULL,
    [Fullname]  NVARCHAR (100) NOT NULL,
    [Phone]     VARCHAR (20)   NOT NULL,
    [Mail]      VARCHAR (100)  NOT NULL,
    [Address]   NVARCHAR (100) NOT NULL,
    [Gender]    VARCHAR (20)   NULL,
    [Birthdate] DATE           NULL,
    [StartDate] DATE           DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Birthdate]<=getdate()),
    UNIQUE NONCLUSTERED ([Mail] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);

