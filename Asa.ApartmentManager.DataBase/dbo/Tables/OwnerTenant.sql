CREATE TABLE [dbo].[OwnerTenant] (
    [OwnerTenantId] INT           IDENTITY (1, 1) NOT NULL,
    [OccupantCount] INT           NULL,
    [IsOwner]       BIT           NOT NULL,
    [From]          DATETIME2 (7) NOT NULL,
    [To]            DATETIME2 (7) NULL,
    [PersonId]      INT           NOT NULL,
    [ApartmentId]   INT           NOT NULL,
    CONSTRAINT [PK_OwnerTenant] PRIMARY KEY CLUSTERED ([OwnerTenantId] ASC),
    CONSTRAINT [FK_OwnerTenant_Apartment_ApartmentId] FOREIGN KEY ([ApartmentId]) REFERENCES [dbo].[Apartment] ([ApartmentId]) ON DELETE CASCADE,
    CONSTRAINT [FK_OwnerTenant_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([PersonId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_OwnerTenant_ApartmentId]
    ON [dbo].[OwnerTenant]([ApartmentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OwnerTenant_PersonId]
    ON [dbo].[OwnerTenant]([PersonId] ASC);

