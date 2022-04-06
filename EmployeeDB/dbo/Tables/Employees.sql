CREATE TABLE [dbo].[Employees] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (10)  NOT NULL,
    [Email]      NVARCHAR (MAX) NOT NULL,
    [Department] INT            NOT NULL,
    [PhotoPath]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Id] ASC)
);

