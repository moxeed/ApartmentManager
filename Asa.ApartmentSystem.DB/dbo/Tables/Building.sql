CREATE TABLE [dbo].[Building] (
    [id]              INT           IDENTITY (1, 1) NOT NULL,
    [name]            NVARCHAR (50) NOT NULL,
    [number_of_units] INT           NOT NULL,
    CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED ([id] ASC)
);

