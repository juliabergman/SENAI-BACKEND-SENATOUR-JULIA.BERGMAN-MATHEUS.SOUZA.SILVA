USE Senatur_Tarde;

SELECT * FROM Pacotes;

SELECT * FROM Usuarios;

SELECT * FROM TipoUsuarios;

SELECT IdUsuario, Email, Senha, TipoUsuarios.TituloTipoUsuario
FROM Usuarios
INNER JOIN TipoUsuarios ON TipoUsuarios.IdTipoUsuario = Usuarios.IdUsuario;