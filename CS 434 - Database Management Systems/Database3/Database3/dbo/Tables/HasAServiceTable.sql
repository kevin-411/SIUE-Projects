CREATE TABLE [dbo].[HasAServiceTable] (
    [ToCode]    NVARCHAR (50) NOT NULL,
    [FromCode]  NVARCHAR (50) NOT NULL,
    [ServiceId] INT           NOT NULL,
    CONSTRAINT [PK_HasAServiceTable] PRIMARY KEY CLUSTERED ([ToCode] ASC, [FromCode] ASC, [ServiceId] ASC),
    CONSTRAINT [CHK_ServiceId] CHECK ([ServiceId]>=(0) AND [ServiceId]<=(3)),
    CONSTRAINT [FK_HasAServiceTable_ToFacilityTable] FOREIGN KEY ([ToCode]) REFERENCES [dbo].[FacilityTable] ([FacilityId]),
    CONSTRAINT [FK_HasAServiceTable_ToFacilityTable1] FOREIGN KEY ([FromCode]) REFERENCES [dbo].[FacilityTable] ([FacilityId])
);

