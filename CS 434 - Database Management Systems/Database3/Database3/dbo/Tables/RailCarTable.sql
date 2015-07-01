CREATE TABLE [dbo].[RailCarTable] (
    [VinNumber]         NVARCHAR (50)  NOT NULL,
    [Make]              NVARCHAR (256) NOT NULL,
    [Model]             NVARCHAR (256) NOT NULL,
    [Year]              INT            NOT NULL,
    [PassengerCapacity] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([VinNumber] ASC),
    CONSTRAINT [CHK_PassengerCapacityR] CHECK ([PassengerCapacity]>(0) AND [PassengerCapacity]<(10000)),
    CONSTRAINT [CHK_YearR] CHECK ([Year]>(1900))
);

