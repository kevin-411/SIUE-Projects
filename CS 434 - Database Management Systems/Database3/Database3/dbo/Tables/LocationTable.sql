CREATE TABLE [dbo].[LocationTable] (
    [CRSA_Code] NVARCHAR (50)  NOT NULL,
    [Latitude]  FLOAT (53)     NOT NULL,
    [Longitude] FLOAT (53)     NOT NULL,
    [Street]    NVARCHAR (256) NOT NULL,
    [City]      NVARCHAR (256) NOT NULL,
    [State]     NVARCHAR (2)   NOT NULL,
    [Zipcode]   NVARCHAR (16)  NOT NULL,
    CONSTRAINT [PK_LocationTable] PRIMARY KEY CLUSTERED ([CRSA_Code] ASC, [Latitude] ASC, [Longitude] ASC),
    CONSTRAINT [CHK_Latitude] CHECK ([Latitude]>=(-90.0) AND [Latitude]<=(90.0)),
    CONSTRAINT [CHK_Longitude] CHECK ([Longitude]>=(-180.0) AND [Longitude]<=(180.0)),
    CONSTRAINT [FK_LocationTable_ToPopulationTable] FOREIGN KEY ([CRSA_Code]) REFERENCES [dbo].[PopulationTable] ([CRSA_Code])
);


GO
CREATE NONCLUSTERED INDEX [LocIndex]
    ON [dbo].[LocationTable]([Longitude] ASC) WHERE ([Longitude]>(-180) AND [Longitude]<(-90));


GO
CREATE NONCLUSTERED INDEX [LocationIndex]
    ON [dbo].[LocationTable]([Longitude] ASC) WHERE ([Longitude] IS NOT NULL AND [Longitude]<(-90));


GO
CREATE NONCLUSTERED INDEX [WestIndex]
    ON [dbo].[LocationTable]([Longitude] ASC) WHERE ([Longitude] IS NOT NULL AND [Longitude]<(-90));


GO
CREATE NONCLUSTERED INDEX [EastIndex]
    ON [dbo].[LocationTable]([Longitude] ASC) WHERE ([Longitude] IS NOT NULL AND [Longitude]>=(-90));

