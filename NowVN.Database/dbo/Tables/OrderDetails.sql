CREATE TABLE [dbo].[OrderDetails] (
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [OrderID]   INT        NULL,
    [ProductID] INT        NULL,
    [Price]     FLOAT (53) NOT NULL,
    [Quantity]  INT        DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Quantity]>=(1)),
    FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([Id]),
    FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([Id])
);

