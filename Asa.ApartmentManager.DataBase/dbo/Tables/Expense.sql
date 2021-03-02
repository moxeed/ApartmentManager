CREATE TABLE [dbo].[Expense] (
    [ExpenseId]         INT            IDENTITY (1, 1) NOT NULL,
    [Amount]            INT            NOT NULL,
    [From]              DATETIME2 (7)  NOT NULL,
    [To]                DATETIME2 (7)  NOT NULL,
    [ExpenseCategoryId] INT            NULL,
    [Title]             NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED ([ExpenseId] ASC),
    CONSTRAINT [FK_Expense_ExpenseCategory_ExpenseCategoryId] FOREIGN KEY ([ExpenseCategoryId]) REFERENCES [dbo].[ExpenseCategory] ([ExpenseCategoryId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Expense_ExpenseCategoryId]
    ON [dbo].[Expense]([ExpenseCategoryId] ASC);

