CREATE TABLE [dbo].[FacilityTable] (
    [FacilityId]   NVARCHAR (50)  NOT NULL,
    [Website]      NVARCHAR (MAX) NULL,
    [Name]         NVARCHAR (256) NOT NULL,
    [FacilityType] INT            NOT NULL,
    [Description]  NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([FacilityId] ASC),
    CONSTRAINT [CHK_FacilityType] CHECK ([FacilityType]>=(0) AND [FacilityType]<=(10))
);

