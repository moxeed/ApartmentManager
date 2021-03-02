CREATE TABLE [dbo].[ChargeItem] (
    [ChargeItemId] INT IDENTITY (1, 1) NOT NULL,
    [PayerId]      INT NOT NULL,
    [ExpenseId]    INT NOT NULL,
    [Amount]       INT NOT NULL,
    [ChargeId]     INT NOT NULL,
    CONSTRAINT [PK_ChargeItem] PRIMARY KEY CLUSTERED ([ChargeItemId] ASC),
    CONSTRAINT [FK_ChargeItem_Charge_ChargeId] FOREIGN KEY ([ChargeId]) REFERENCES [dbo].[Charge] ([ChargeId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ChargeItem_ChargeId]
    ON [dbo].[ChargeItem]([ChargeId] ASC);

