USE OPTUS;
GO

INSERT INTO ALBUM (nomeAlbum)
VALUES ('Sins of The PastOnes'),('Visionario'),('Sanfoneiro da Gaita');

INSERT INTO ESTILO (nomeEstilo)
VALUES ('Rock'),('Pop'),('Forro'),('Heavy Metal'),('Hyper Pop');

INSERT INTO ARTISTA (nomeArtista)
VALUES ('Lucas'),('Saulo'),('Joao');

INSERT INTO USUARIO (nomeUsuario, emailUsuario, senhaUsuario, permissao)
VALUES ('Jonas','AAA',123,1),('Jefferson','BBB',321,0),('Julio','CCC',132,0);

INSERT INTO ALBUMUSUARIO (idUsuario, dataLancamento)
VALUES (2,'20/09/2001'),(2,'21/09/2001'),(1,'22/09/2001');

INSERT INTO ARTISTAALBUM (idAlbum, idArtista, dataCriacao)
VALUES (2,2,'28/08/2000'),(3,1,'28/08/2000'),(4,3,'29/08/2000');

INSERT INTO ALBUMESTILO (idAlbum, idEstilo, dataLancamento)
VALUES (2,4,'11/09/2001'),(2,4,'12/09/2001'),(3,3,'13/09/2001'),(4,2,'14/09/2001');