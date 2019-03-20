CREATE TABLE [dbo].[Role] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [RoleName] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([RoleName] ASC)
);

