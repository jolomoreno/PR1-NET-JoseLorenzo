CREATE TABLE [dbo].[PedidoPelicula] (
    [Pedidos_Id]   INT NOT NULL,
    [Peliculas_Id] INT NOT NULL,
    CONSTRAINT [PK_PedidoPelicula] PRIMARY KEY CLUSTERED ([Pedidos_Id] ASC, [Peliculas_Id] ASC),
    CONSTRAINT [FK_PedidoPelicula_Pedidos] FOREIGN KEY ([Pedidos_Id]) REFERENCES [dbo].[Pedidos] ([Id]),
    CONSTRAINT [FK_PedidoPelicula_Peliculas] FOREIGN KEY ([Peliculas_Id]) REFERENCES [dbo].[Peliculas] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_PedidoProducto_Productos]
    ON [dbo].[PedidoProducto]([Productos_Id] ASC);

