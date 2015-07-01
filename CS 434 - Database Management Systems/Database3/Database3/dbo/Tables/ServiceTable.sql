CREATE TABLE [dbo].[ServiceTable] (
    [ServiceId] NVARCHAR (50) NOT NULL,
    [ToCode]    NVARCHAR (50) NOT NULL,
    [FromCode]  NVARCHAR (50) NOT NULL,
    [Cost]      SMALLMONEY    NOT NULL,
    [BeginTime] DATETIME      NOT NULL,
    [EndTime]   DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([ServiceId] ASC, [ToCode] ASC, [FromCode] ASC),
    CONSTRAINT [CHK_Cost] CHECK ([Cost]>(0) AND [Cost]<(99999.99)),
    CONSTRAINT [CHK_Time] CHECK ([BeginTime]<[EndTime]),
    CONSTRAINT [CHK_ToFrom] CHECK ([ToCode]<>[FromCode]),
    CONSTRAINT [FK_HasAServiceTable_ToFacilityTable14] FOREIGN KEY ([FromCode]) REFERENCES [dbo].[FacilityTable] ([FacilityId]),
    CONSTRAINT [FK_HasAServiceTable_ToFacilityTable3] FOREIGN KEY ([ToCode]) REFERENCES [dbo].[FacilityTable] ([FacilityId])
);

