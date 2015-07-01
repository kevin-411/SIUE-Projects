CREATE TABLE [dbo].[AirportTable] (
    [AirportId]    NVARCHAR (50)  NOT NULL,
    [FacilityId]   NVARCHAR (50)  NOT NULL,
    [NumTerminals] INT            NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AirportTable] PRIMARY KEY CLUSTERED ([AirportId] ASC, [FacilityId] ASC),
    CONSTRAINT [CHK_NumTerminals] CHECK ([NumTerminals]>(0) AND [NumTerminals]<(1000)),
    CONSTRAINT [FK_AirportTable_ToFacilityTable] FOREIGN KEY ([FacilityId]) REFERENCES [dbo].[FacilityTable] ([FacilityId])
);

