CREATE TABLE [dbo].[ExpenseCategory] (
    [ExpenseCategoryId]   INT            IDENTITY (1, 1) NOT NULL,
    [ExpenseCategoryName] NVARCHAR (MAX) NULL,
    [FormulaType]         INT            NOT NULL,
    CONSTRAINT [PK_ExpenseCategory] PRIMARY KEY CLUSTERED ([ExpenseCategoryId] ASC)
);

