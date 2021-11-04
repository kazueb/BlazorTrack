﻿CREATE TABLE [dbo].[Member]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Email] NVARCHAR(320) NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL
)

GO

CREATE UNIQUE INDEX [IX_Member_Email] ON [dbo].Member(Email)
