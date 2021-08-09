USE CLINICA;
GO

INSERT INTO CLINICA (nomeClinica)
VALUES ('Jorge'),('Amado');

INSERT INTO DONO (nomeDono)
VALUES ('Lucas'),('Joao'),('Saulo');

INSERT INTO TIPOPET (nomeTipo)
VALUES ('Cavalo'),('CAVALO'),('cavALO');

INSERT INTO VETERINARIO (idClinica, nomeVeterinario, CRMV)
VALUES (1,'Lucas','17701'),(1,'Joao','17702');

INSERT INTO RACA (idTipo, nomeRaca)
VALUES (1,'Morgan'),(2,'Arabe'),(3,'Quarto de Milha');

INSERT INTO PET (idRaca, idDono, nomePet)
VALUES (5,1,'Jorge'),(7,2,'Amado'),(6,3,'Capitaes da Areia');

INSERT INTO ATENDIMENTO (idVeterinario, idPet, dataAtendimento)
VALUES (5,59,'24/04/1999'),(6,60,'25/04/1999'),(7,61,'26/04/1999');
