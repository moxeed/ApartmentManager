CREATE TABLE [dbo].[Units]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [building_id] INT NOT NULL, 
    [number] INT NOT NULL, 
    [area] DECIMAL(5, 1) NOT NULL, 
    [description] NVARCHAR(250) NULL, 
    CONSTRAINT [Fk_unit_building] FOREIGN KEY ([building_id]) REFERENCES [building](id)
)
