USE T_Rental;
GO

INSERT INTO MARCA (nomeMarca)
VALUES ('BMW'),('Opel'),('Lancia');

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('A Empresa');

INSERT INTO CLIENTE (nomeCliente, surNameCliente, CNH)
VALUES ('Saulo','Mestre','048721837298'), ('Joao','O Brabo','741002834512'), ('Lucas','Malacobaco','152752938400');

INSERT INTO MODELO (idMarca, nomeModelo)
VALUES (2,'Manta'),(3,'Delta'),(1,'E30 M3');

INSERT INTO VEICULO (idEmpresa,idModelo, placaCarro)
VALUES (1,2,'CAR7R14'),(1,3,'BEE3R82'),(1,1,'GYA4R02');

INSERT INTO ALUGUEL (idVeiculo, idCliente, dataAluguel, dataDevolucao)
VALUES (4,3,'11/09/2000','15/09/2000'),(2,2,'11/09/2000','12/09/2000'),(3,1,'11/09/2000','13/09/2000'),(4,2,'13/09/2000','14/09/2000');
