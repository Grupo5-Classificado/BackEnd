USE Classificados 
GO

INSERT INTO tipoUsuario(nomeTipoUsuario) VALUES
('admin'), ('comum')
GO

INSERT INTO usuario(idTipoUsuario,nomeUsuario,email,senha,popularidade, telefone) VALUES
(1,'Administrador','adm@adm.com', 'teste123', 10,40028922), (2,'Comum','comum@comum.com', 'teste321', 0,40028922)
GO

INSERT INTO pedidos(idUsuario,titulo,pedido) VALUES
(2,'Preciso de um PS4!','Meu filho anda pedindo um videogame de presente, especificamente um PS4, e como ele teve um desempenho bom na escola, procuro um para comprar, podem mostrar as ofertas?'),
(2,'Preciso de um imóvel!','Preciso de um imóvel para alugar próximo à estação da luz, podem mostrar as ofertas?')
GO

INSERT INTO comentarios(idUsuario,idClassificado,comentario,reservado) VALUES
(1,1,'Olá, preciso vender o meu PS4 por conta da faculdade, entre em contato comigo pelo meu telefone no perfil!',0)
GO

INSERT INTO tags(nomeTag) VALUES
('Eletrônicos'),('Empregos'),('Automóveis'),('Imóveis'),('Móveis'),('Brinquedos'),('Acessórios'),('Serviços')
GO

INSERT INTO etiquetas(idClassificado,idTag) VALUES
(1,1),(2,4)
GO