CREATE TABLE [dbo].[Pedidos] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Cliente]   VARCHAR (50)  NULL,
    [Direccion] VARCHAR (200) NULL,
    [Fecha]     DATETIME      NULL,
    [Total]   FLOAT (53)    NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

