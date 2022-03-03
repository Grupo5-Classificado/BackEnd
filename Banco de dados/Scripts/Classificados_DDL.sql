CREATE DATABASE Classificados
GO


CREATE TABLE tipoUsuario(
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	nomeTipoUsuario VARCHAR(30) UNIQUE NOT NULL
);
GO

CREATE TABLE usuario (
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	nomeUsuario VARCHAR(50) NOT NULL,
	email VARCHAR(200) UNIQUE NOT NULL,
	senha VARCHAR(10) NOT NULL,
	popularidade INT,
	binarioImg VARBINARY(MAX),
	telefone INT
);
GO

CREATE TABLE pedidos(
	idPedido INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	pedido TEXT NOT NULL,
	titulo VARCHAR(100) NOT NULL,
);
GO

CREATE TABLE comentarios(
	idComentario INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	idClassificado INT FOREIGN KEY REFERENCES pedidos(idPedido),
	comentario varchar(1000) NOT NULL,
	binarioImg VARBINARY(MAX),
	reservado int 
);
GO


CREATE TABLE tags(
	idTag INT PRIMARY KEY IDENTITY,
	nomeTag VARCHAR(30) UNIQUE NOT NULL
);
GO

CREATE TABLE etiquetas(
	idEtiqueta INT PRIMARY KEY IDENTITY,
	idTag INT FOREIGN KEY REFERENCES tags(idTag),
	idClassificado INT FOREIGN KEY REFERENCES pedidos(idPedido),
);
GO