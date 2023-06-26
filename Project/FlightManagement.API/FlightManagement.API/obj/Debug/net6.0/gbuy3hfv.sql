BEGIN TRANSACTION;
GO

ALTER TABLE [BookAPlace] DROP CONSTRAINT [FK_BookAPlace_BookAPlace_BookAPlaceID];
GO

ALTER TABLE [HoldtheSeat] DROP CONSTRAINT [FK_HoldtheSeat_BookAPlace_BookAPlaceId];
GO

DROP INDEX [IX_HoldtheSeat_BookAPlaceId] ON [HoldtheSeat];
GO

DROP INDEX [IX_BookAPlace_BookAPlaceID] ON [BookAPlace];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BookAPlace]') AND [c].[name] = N'BookAPlaceID');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [BookAPlace] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [BookAPlace] DROP COLUMN [BookAPlaceID];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230625132721_AddTable_HoldtheSeats', N'6.0.0');
GO

COMMIT;
GO

