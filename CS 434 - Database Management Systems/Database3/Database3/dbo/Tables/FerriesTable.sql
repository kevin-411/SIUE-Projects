CREATE TABLE [dbo].[FerriesTable] (
    [FerryId]     NVARCHAR (50)  NOT NULL,
    [FacilityId]  NVARCHAR (50)  NOT NULL,
    [NumFerries]  INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_FerriesTable] PRIMARY KEY CLUSTERED ([FerryId] ASC, [FacilityId] ASC),
    CONSTRAINT [CHK_NumFerries] CHECK ([NumFerries]>(0) AND [NumFerries]<(1000)),
    CONSTRAINT [FK_FerriesTable_ToFacilityTable] FOREIGN KEY ([FacilityId]) REFERENCES [dbo].[FacilityTable] ([FacilityId])
);

