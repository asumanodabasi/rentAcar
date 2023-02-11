CREATE TABLE [dbo].[Cars] (
    [Id]     INT          DEFAULT ((1)) NOT NULL,
    [CarName]   VARCHAR (50) NOT NULL,
    [BrandId] INT         NOT NULL,
    [ColorId]  NCHAR (10)   NOT NULL,
    [ModelYear] DATETIME NULL, 
    [DailyPrice] DECIMAL NULL, 
    [Description] NCHAR(10) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

