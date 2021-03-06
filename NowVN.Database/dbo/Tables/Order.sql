﻿CREATE TABLE [dbo].[Order] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [CreatedTime] DATE           DEFAULT (getdate()) NOT NULL,
    [Total]       FLOAT (53)     NOT NULL,
    [isAvailable] BIT            DEFAULT ((1)) NOT NULL,
    [Address]     NVARCHAR (MAX) NOT NULL,
    [Phone]       VARCHAR (100)  NOT NULL,
    [Fullname]    NVARCHAR (255) NULL,
    [CustomerID]  VARCHAR (100)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([Id])
);



