BEGIN TRANSACTION;
GO

CREATE TABLE [BookAPlace] (
    [ID] int NOT NULL IDENTITY,
    [StartDate] datetime2 NOT NULL,
    [ReturnDay] datetime2 NULL,
    [FlightID] int NOT NULL,
    [ClientID] int NOT NULL,
    CONSTRAINT [PK_BookAPlace] PRIMARY KEY ([ID])
);
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
VALUES (N'20230625130949__AdddatabaseaddClient_BookAPlace', N'6.0.0');
GO

COMMIT;
GO

