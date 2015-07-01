CREATE TABLE [dbo].[HasLocationTable] (
    [FacilityId] NVARCHAR (50) NOT NULL,
    [CRSA_Code]  NVARCHAR (50) NOT NULL,
    [Latitude]   FLOAT (53)    NOT NULL,
    [Longitude]  FLOAT (53)    NOT NULL,
    CONSTRAINT [PK_HasLocationTable] PRIMARY KEY CLUSTERED ([FacilityId] ASC, [CRSA_Code] ASC, [Latitude] ASC, [Longitude] ASC),
    CONSTRAINT [FK_HasLocationTable_ToFacilityTable] FOREIGN KEY ([FacilityId]) REFERENCES [dbo].[FacilityTable] ([FacilityId]),
    CONSTRAINT [FK_HasLocationTable_ToLocationTable] FOREIGN KEY ([CRSA_Code], [Latitude], [Longitude]) REFERENCES [dbo].[LocationTable] ([CRSA_Code], [Latitude], [Longitude])
);

