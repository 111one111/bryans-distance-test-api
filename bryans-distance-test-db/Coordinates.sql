CREATE TABLE [dbo].[Coordinates]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [TravelId] INT NOT NULL, 
    [Latitude] FLOAT NOT NULL, 
    [Longitude] FLOAT NOT NULL
)
