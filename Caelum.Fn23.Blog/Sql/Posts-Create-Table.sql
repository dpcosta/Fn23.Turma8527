﻿CREATE TABLE [dbo].[Posts] 
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Titulo] VARCHAR(50),
	[Resumo] VARCHAR(500),
	[Categoria] VARCHAR(50)
)