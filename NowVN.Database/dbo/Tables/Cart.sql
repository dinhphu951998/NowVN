CREATE TABLE [dbo].[Cart] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Quantity]  INT           DEFAULT ((1)) NOT NULL,
    [ProductId] INT           NOT NULL,
    [UserId]    VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

