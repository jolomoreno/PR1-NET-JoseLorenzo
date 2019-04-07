CREATE TABLE [dbo].[Peliculas] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      VARCHAR (50)   NOT NULL,
    [Sinopsis] VARCHAR (200)  NULL,
    [Precio]      FLOAT (53)     NULL,
    [Stock]    SMALLINT       NULL,
    [Caratula]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED ([Id] ASC)
);

