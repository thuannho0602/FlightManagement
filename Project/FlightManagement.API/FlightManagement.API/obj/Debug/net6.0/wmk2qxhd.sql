BEGIN TRANSACTION;
GO

ALTER TABLE [Flight] ADD [FlightId] int NULL;
GO

ALTER TABLE [Client] ADD [ClientId] int NULL;
GO

CREATE INDEX [IX_Flight_FlightId] ON [Flight] ([FlightId]);
GO

CREATE INDEX [IX_Client_ClientId] ON [Client] ([ClientId]);
GO

ALTER TABLE [Client] ADD CONSTRAINT [FK_Client_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Client] ([Id]);
GO

ALTER TABLE [Flight] ADD CONSTRAINT [FK_Flight_Flight_FlightId] FOREIGN KEY ([FlightId]) REFERENCES [Flight] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230625125910_addTableClient_BookAPlace', N'6.0.0');
GO

COMMIT;
GO

