USE Classificados


--SELECIONANDO TODOS OS PEDIDOS DE TAG 'ELETRONICOS'

SELECT titulo, pedido,nomeTag as Categoria FROM pedidos
RIGHT JOIN etiquetas on etiquetas.idClassificado = pedidos.idPedido
INNER JOIN tags ON tags.idTag = etiquetas.idTag
where etiquetas.idTag = 1
GO
