CREATE TABLE [dbo].[Products] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Count]       INT            NOT NULL, CHECK ([Count]>0),
    [Price]       INT            NOT NULL, CHECK (Price>0),
    [TypeId]      INT            NULL,
    [Category_Id] INT            NULL,
    CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Products_dbo.Categories_Category_Id] FOREIGN KEY ([Category_Id]) REFERENCES [dbo].[Categories] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Category_Id]
    ON [dbo].[Products]([Category_Id] ASC);

