BEGIN TRANSACTION;
GO

CREATE TABLE [Flight] (
    [Id] int NOT NULL IDENTITY,
    [DepartureTime] time NOT NULL,
    [Time] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [AirportDepartureID] int NOT NULL,
    [ArrivalAirportID] int NOT NULL,
    [PlaneID] int NOT NULL,
    CONSTRAINT [PK_Flight] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Flight_AirportDeparture_AirportDepartureID] FOREIGN KEY ([AirportDepartureID]) REFERENCES [AirportDeparture] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Flight_ArrivalAirport_ArrivalAirportID] FOREIGN KEY ([ArrivalAirportID]) REFERENCES [ArrivalAirport] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Flight_Plane_PlaneID] FOREIGN KEY ([PlaneID]) REFERENCES [Plane] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Flight_AirportDepartureID] ON [Flight] ([AirportDepartureID]);
GO

CREATE INDEX [IX_Flight_ArrivalAirportID] ON [Flight] ([ArrivalAirportID]);
GO

CREATE INDEX [IX_Flight_PlaneID] ON [Flight] ([PlaneID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230622164943_AddFlight', N'6.0.0');
GO

COMMIT;
GO

