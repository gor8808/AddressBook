CREATE TABLE [dbo].[Addresses] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [FullName]        NVARCHAR (500)  NOT NULL,
    [Email]           NVARCHAR (MAX)  NOT NULL,
    [PhoneNumber]     NVARCHAR (1000) NOT NULL,
    [PhysicalAddress] NVARCHAR (MAX)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

