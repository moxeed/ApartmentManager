CREATE TABLE [dbo].[Apartment] (
    [ApartmentId] INT             IDENTITY (1, 1) NOT NULL,
    [Area]        DECIMAL (10, 2) NOT NULL,
    [Number]      INT             NOT NULL,
    [BuildingId]  INT             NOT NULL,
    CONSTRAINT [PK_Apartment] PRIMARY KEY CLUSTERED ([ApartmentId] ASC),
    CONSTRAINT [FK_Apartment_Building_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [dbo].[Building] ([BuildingId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Apartment_BuildingId]
    ON [dbo].[Apartment]([BuildingId] ASC);

