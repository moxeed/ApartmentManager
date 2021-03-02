CREATE TABLE [dbo].[Building] (
    [BuildingId]     INT            IDENTITY (1, 1) NOT NULL,
    [BuildingName]   NVARCHAR (MAX) NULL,
    [ApartmentCount] INT            NULL,
    CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED ([BuildingId] ASC)
);

