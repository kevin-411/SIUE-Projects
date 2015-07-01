CREATE TABLE [dbo].[HasRailCarTable] (
    [AmtrakId]   NVARCHAR (50) NOT NULL,
    [FacilityId] NVARCHAR (50) NOT NULL,
    [VinNumber]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_HasRailCarTable] PRIMARY KEY CLUSTERED ([AmtrakId] ASC, [FacilityId] ASC, [VinNumber] ASC),
    CONSTRAINT [FK_HasRailCarTable_ToAmtrakTable] FOREIGN KEY ([AmtrakId], [FacilityId]) REFERENCES [dbo].[AmtrakTable] ([AmtrakId], [FacilityId]),
    CONSTRAINT [FK_HasRailCarTable_ToRailCarTable] FOREIGN KEY ([VinNumber]) REFERENCES [dbo].[RailCarTable] ([VinNumber])
);

