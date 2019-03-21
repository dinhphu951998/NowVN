CREATE TABLE [dbo].[Product] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (100) NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    [Price]       FLOAT (53)    NOT NULL,
    [CategoryId]  INT           NULL,
    [CreatedTime] DATE          DEFAULT (getdate()) NOT NULL,
    [isActive]    BIT           DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);



