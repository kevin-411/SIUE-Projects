CREATE TABLE [dbo].[Facility_Locations] (
    [FacilityId] NVARCHAR (50)  NOT NULL,
    [City]       NVARCHAR (256) NOT NULL,
    [State]      NVARCHAR (2)   NOT NULL,
    [Latitude]   FLOAT (53)     NOT NULL,
    [Longitude]  FLOAT (53)     NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [WestIndex]
    ON [dbo].[Facility_Locations]([Longitude] ASC) WHERE ([Longitude] IS NOT NULL AND [Longitude]<(-90));


GO
CREATE NONCLUSTERED INDEX [EastIndex]
    ON [dbo].[Facility_Locations]([Longitude] ASC) WHERE ([Longitude] IS NOT NULL AND [Longitude]>=(-90));

