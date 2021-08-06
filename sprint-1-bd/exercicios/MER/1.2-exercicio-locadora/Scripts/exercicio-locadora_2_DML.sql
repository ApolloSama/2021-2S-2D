USE LOCADORA;
GO

INSERT INTO MARCA (nomeMarca)
VALUES ('BMW');

DELETE FROM MARCA
WHERE idMarca = 4

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('Empresa');

INSERT INTO CLIENTE (nomeCliente)
VALUES ('Saulo'), ('Joao'), ('Lucas');

INSERT INTO MODELO (idMarca, nomeModelo)
VALUES (1,'Manta'),(2,'Delta'),(3,'E30 M3');

INSERT INTO VEICULO (idEmpresa,idModelo, placaCarro)
VALUES (1,2,'777'),(1,3,'666'),(1,1,'555');

DELETE FROM VEICULO
WHERE idModelo = 1

INSERT INTO CLIENTE (nomeCliente)
VALUES ('Saulo'),('Joao'),('Lucas');

DELETE FROM CLIENTE
WHERE nomeCliente = 'Saulo'

INSERT INTO ALUGUEL (idVeiculo, idCliente, dataAluguel)
VALUES (5,3,'11/09/2000'),(7,5,'11/09/2000'),(6,6,'11/09/2000'),(6,2,'13/09/2000');
