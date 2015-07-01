CREATE TABLE [dbo].[AmtrakTable] (
    [AmtrakId]    NVARCHAR (50)  NOT NULL,
    [FacilityId]  NVARCHAR (50)  NOT NULL,
    [NumAmtraks]  INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AmtrakTable] PRIMARY KEY CLUSTERED ([AmtrakId] ASC, [FacilityId] ASC),
    CONSTRAINT [CHK_NumAmtraks] CHECK ([NumAmtraks]>(0) AND [NumAmtraks]<(1000)),
    CONSTRAINT [FK_AmtrakTable_ToFacilityTable] FOREIGN KEY ([FacilityId]) REFERENCES [dbo].[FacilityTable] ([FacilityId])
);

