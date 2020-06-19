ALTER TABLE [dbo].[Coordinates]
	ADD CONSTRAINT [CoordinatesForeignKeyConstraint]
	FOREIGN KEY ([TravelId])
	REFERENCES [Travel] (Id)
