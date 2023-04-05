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

CREATE TABLE [USUARIO] (
    [IDUSUARIO] uniqueidentifier NOT NULL,
    [NOME] nvarchar(150) NOT NULL,
    [EMAIL] nvarchar(50) NOT NULL,
    [SENHA] nvarchar(40) NOT NULL,
    [DATACRIACAO] datetime NOT NULL,
    [ATIVO] int NOT NULL,
    CONSTRAINT [PK_USUARIO] PRIMARY KEY ([IDUSUARIO])
);
GO

CREATE UNIQUE INDEX [IX_USUARIO_EMAIL] ON [USUARIO] ([EMAIL]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230318144707_Initial', N'7.0.4');
GO

COMMIT;
GO

