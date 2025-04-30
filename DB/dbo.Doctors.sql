CREATE TABLE [dbo].[Doctors] (
    [Id]             NCHAR(10)           NOT NULL,
    [Name]           NCHAR (50)    NOT NULL,
    [AddressId]      INT           NOT NULL,
    [Specialization] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id])
);

