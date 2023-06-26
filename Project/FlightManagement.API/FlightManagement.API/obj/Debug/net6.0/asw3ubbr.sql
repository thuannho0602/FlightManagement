BEGIN TRANSACTION;
GO

ALTER TABLE [BookAPlace] ADD [BookAPlaceID] int NULL;
GO

CREATE INDEX [IX_BookAPlace_BookAPlaceID] ON [BookAPlace] ([BookAPlaceID]);
GO

ALTER TABLE [BookAPlace] ADD CONSTRAINT [FK_BookAPlace_BookAPlace_BookAPlaceID] FOREIGN KEY ([BookAPlaceID]) REFERENCES [BookAPlace] ([ID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230625131934_AddTableHoldtheSeat', N'6.0.0');
GO

COMMIT;
GO

