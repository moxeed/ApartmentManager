CREATE TABLE [dbo].[Charge] (
    [ChargeId]          INT           IDENTITY (1, 1) NOT NULL,
    [ApartmentId]       INT           NOT NULL,
    [CalculateDateTime] DATETIME2 (7) NOT NULL,
    [From]              DATETIME2 (7) NOT NULL,
    [To]                DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_Charge] PRIMARY KEY CLUSTERED ([ChargeId] ASC)
);

