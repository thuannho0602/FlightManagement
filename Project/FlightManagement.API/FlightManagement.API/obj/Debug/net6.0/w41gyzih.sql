BEGIN TRANSACTION;
GO

CREATE TABLE [Client] (
    [Id] int NOT NULL IDENTITY,
    [FullName] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [Sex] bit NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230625121923_AddTableClient', N'6.0.0');
GO

COMMIT;
GO

