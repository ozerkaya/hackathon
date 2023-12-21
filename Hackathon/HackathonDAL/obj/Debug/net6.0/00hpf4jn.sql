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

CREATE TABLE [Users] (
    [ID] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [NameSurname] nvarchar(max) NULL,
    [IsEnable] bit NOT NULL,
    [TeamName] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([ID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231219082306_ver1', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Questions] (
    [ID] int NOT NULL IDENTITY,
    [QuestionTR] nvarchar(max) NULL,
    [QuestionEN] nvarchar(max) NULL,
    [Answer] nvarchar(max) NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY ([ID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231221120711_ver2', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Questions]') AND [c].[name] = N'Answer');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Questions] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Questions] ALTER COLUMN [Answer] nvarchar(1) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231221120824_ver3', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Games] (
    [ID] int NOT NULL IDENTITY,
    [GameKey] uniqueidentifier NOT NULL,
    [Gamer1Key] uniqueidentifier NOT NULL,
    [Gamer2Key] uniqueidentifier NOT NULL,
    [Gamer1Point] int NOT NULL,
    [Gamer2Point] int NOT NULL,
    [Gamer1Question] int NOT NULL,
    [Gamer2Question] int NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY ([ID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231221122120_ver4', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Questions] ADD [QuestionNumber] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231221124809_ver5', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Games] ADD [Gamer1Finish] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Games] ADD [Gamer2Finish] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231221154202_ver6', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Games]') AND [c].[name] = N'Gamer2Finish');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Games] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Games] ALTER COLUMN [Gamer2Finish] bit NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Games]') AND [c].[name] = N'Gamer1Finish');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Games] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Games] ALTER COLUMN [Gamer1Finish] bit NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231221154508_ver7', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Questions] ADD [ChoiseA] nvarchar(max) NULL;
GO

ALTER TABLE [Questions] ADD [ChoiseB] nvarchar(max) NULL;
GO

ALTER TABLE [Questions] ADD [ChoiseC] nvarchar(max) NULL;
GO

ALTER TABLE [Questions] ADD [ChoiseD] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231221155525_ver8', N'6.0.25');
GO

COMMIT;
GO

