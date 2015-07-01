CREATE TABLE [dbo].[HasPlanesTable] (
    [AirportId]  NVARCHAR (50) NOT NULL,
    [FacilityId] NVARCHAR (50) NOT NULL,
    [VinNumber]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_HasPlanesTable] PRIMARY KEY CLUSTERED ([AirportId] ASC, [FacilityId] ASC, [VinNumber] ASC),
    CONSTRAINT [FK_HasPlanesTable_ToAirportTable] FOREIGN KEY ([AirportId], [FacilityId]) REFERENCES [dbo].[AirportTable] ([AirportId], [FacilityId]),
    CONSTRAINT [FK_HasPlanesTable_ToPlaneTable] FOREIGN KEY ([VinNumber]) REFERENCES [dbo].[PlaneTable] ([VinNumber])
);

