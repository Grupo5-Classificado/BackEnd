USE Classificados 
GO

INSERT INTO tipoUsuario(nomeTipoUsuario) VALUES
('admin'), ('comum')
GO

INSERT INTO usuario(idTipoUsuario,nomeUsuario,email,senha,popularidade) VALUES
(1,'Administrador','adm@adm.com', 'teste123', 10), (2,'Comum','comum@comum.com', 'teste321', 0)
GO
