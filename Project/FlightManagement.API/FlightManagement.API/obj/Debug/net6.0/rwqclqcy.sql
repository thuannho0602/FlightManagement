BEGIN TRANSACTION;
GO

ALTER TABLE [BookAPlace] ADD [BookAPlaceID] int NULL;
GO

CREATE INDEX [IX_HoldtheSeat_BookAPlaceId] ON [HoldtheSeat] ([BookAPlaceId]);
GO

CREATE INDEX [IX_BookAPlace_BookAPlaceID] ON [BookAPlace] ([BookAPlaceID]);
GO

ALTER TABLE [BookAPlace] ADD CONSTRAINT [FK_BookAPlace_BookAPlace_BookAPlaceID] FOREIGN KEY ([BookAPlaceID]) REFERENCES [BookAPlace] ([ID]);
GO

ALTER TABLE [HoldtheSeat] ADD CONSTRAINT [FK_HoldtheSeat_BookAPlace_BookAPlaceId] FOREIGN KEY ([BookAPlaceId]) REFERENCES [BookAPlace] ([ID]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230625132547_AddTable_HoldtheSeat', N'6.0.0');
GO

COMMIT;
GO

