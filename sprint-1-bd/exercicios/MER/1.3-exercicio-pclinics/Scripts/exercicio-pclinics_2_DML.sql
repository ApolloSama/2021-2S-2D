USE CLINICA;
GO

INSERT INTO CLINICA (nomeClinica)
VALUES ('Jorge'),('Amado');

INSERT INTO DONO (nomeDono)
VALUES ('Lucas'),('Joao'),('Saulo');

INSERT INTO TIPOPET (nomeTipo)
VALUES ('Cavalo'),('CAVALO'),('cavALO');

INSERT INTO VETERINARIO (idClinica, nomeVeterinario)
VALUES (1,'Lucas'),(1,'Joao');

INSERT INTO RACA (idTipo, nomeRaca)
VALUES (1,'Morgan'),(2,'Arabe'),(3,'Quarto de Milha');

INSERT INTO PET (idRaca, idDono, nomePet)
VALUES (3,1,'Jorge'),(1,2,'Amado'),(2,3,'Capitaes da Areia');

INSERT INTO ATENDIMENTO (idVeterinario, idPet, dataAtendimento)
VALUES (1,3,'24/04/1999'),(2,2,'25/04/1999'),(1,3,'26/04/1999');
