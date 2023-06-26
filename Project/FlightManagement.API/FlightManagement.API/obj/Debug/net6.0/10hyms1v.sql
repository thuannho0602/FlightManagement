BEGIN TRANSACTION;
GO

ALTER TABLE [Client] DROP CONSTRAINT [FK_Client_Client_ClientId];
GO

ALTER TABLE [Flight] DROP CONSTRAINT [FK_Flight_Flight_FlightId];
GO

DROP INDEX [IX_Flight_FlightId] ON [Flight];
GO

DROP INDEX [IX_Client_ClientId] ON [Client];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Flight]') AND [c].[name] = N'FlightId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Flight] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Flight] DROP COLUMN [FlightId];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Client]') AND [c].[name] = N'ClientId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Client] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Client] DROP COLUMN [ClientId];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230625130255_addTableClient_BookAPlace', N'6.0.0');
GO

COMMIT;
GO

