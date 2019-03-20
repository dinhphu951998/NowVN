CREATE TABLE [dbo].[Image] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Path]      NVARCHAR (255) NOT NULL,
    [ProductId] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

