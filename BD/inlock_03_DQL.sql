USE inlock_games_tarde;
GO


--Listar todos os usuários
SELECT * FROM Usuarios;
GO

SELECT * FROM TipoUsuarios;
GO


--Listar todos os usuários
SELECT * FROM Estudios;
GO

--Listar todos os jogos
SELECT * FROM Jogos;
GO


--Listar todos os jogos e seus respectivos estúdios
SELECT J.nomeJogo, J.descricao, J.dataLancamento, FORMAT (J.valor, 'c', 'pt-br') AS Preço , E.nomeEstudio AS Estudios FROM Jogos AS J
INNER JOIN Estudios AS E
ON J.idEstudio = E.idEstudio
;
GO

--Buscar e trazer na lista todos os estúdios com os respectivos jogos
SELECT E.idEstudio, E.nomeEstudio, J.nomeJogo FROM Estudios AS E
LEFT JOIN Jogos AS J
ON J.idEstudio = E.idEstudio
WHERE E.idEstudio = 1
;
GO

--Buscar um usuário por e-mail e senha
SELECT * FROM Usuarios
WHERE email = 'admin@admin.com' AND senha = 'admin'
;
GO


--Buscar um jogo por idJogo
SELECT * FROM Jogos
WHERE idJogo = 1
;
GO

--Buscar um estúdio por idEstudio
SELECT * FROM Estudios
WHERE idEstudio = 1
;
GO