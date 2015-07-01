CREATE TABLE [dbo].[PlaneTable] (
    [VinNumber]         NVARCHAR (50)  NOT NULL,
    [Make]              NVARCHAR (256) NOT NULL,
    [Model]             NVARCHAR (256) NOT NULL,
    [Year]              INT            NOT NULL,
    [PassengerCapacity] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([VinNumber] ASC),
    CONSTRAINT [CHK_PassengerCapacity] CHECK ([PassengerCapacity]>(0) AND [PassengerCapacity]<(2000)),
    CONSTRAINT [CHK_Year] CHECK ([Year]>(1903))
);

