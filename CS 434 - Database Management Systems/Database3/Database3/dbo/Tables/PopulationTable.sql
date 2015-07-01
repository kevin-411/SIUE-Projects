CREATE TABLE [dbo].[PopulationTable] (
    [CRSA_Code]           NVARCHAR (50) NOT NULL,
    [Population]          INT           NULL,
    [MedianHousingIncome] MONEY         NULL,
    [PerCapitalIncome]    MONEY         NULL,
    [AvgTravelTime]       FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([CRSA_Code] ASC),
    CONSTRAINT [CHK_AvgTravelTime] CHECK ([AvgTravelTime]>(0)),
    CONSTRAINT [CHK_MedianHousingIncome] CHECK ([MedianHousingIncome]>(0)),
    CONSTRAINT [CHK_PerCapitalIncome] CHECK ([PerCapitalIncome]>(0)),
    CONSTRAINT [CHK_Population] CHECK ([Population]>(0))
);

