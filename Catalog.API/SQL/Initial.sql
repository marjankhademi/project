IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'Catalog') IS NULL EXEC(N'CREATE SCHEMA [Catalog];');
GO

CREATE SEQUENCE [Catalog].[ProductSeq] START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
GO

CREATE TABLE [Catalog].[Product] (
    [Id] int NOT NULL,
    [Name] nvarchar(200) NOT NULL,
    [Price] int NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211207142928_Initial', N'6.0.0');
GO

COMMIT;
GO

