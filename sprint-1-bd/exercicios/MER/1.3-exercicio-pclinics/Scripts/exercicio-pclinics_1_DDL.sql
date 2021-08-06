CREATE DATABASE CLINICA;
GO

USE CLINICA;
GO

CREATE TABLE CLINICA (
idClinica SMALLINT PRIMARY KEY IDENTITY (1,1),
nomeClinica VARCHAR (25) NOT NULL 
);

CREATE TABLE TIPOPET (
idTipo TINYINT PRIMARY KEY IDENTITY (1,1),
nomeTipo VARCHAR (20) NOT NULL
);

CREATE TABLE DONO (
idDono SMALLINT PRIMARY KEY IDENTITY (1,1),
nomeDono VARCHAR (20) NOT NULL
);

CREATE TABLE VETERINARIO (
idVeterinario SMALLINT PRIMARY KEY IDENTITY (1,1),
idClinica SMALLINT FOREIGN KEY REFERENCES CLINICA(idClinica),
nomeVeterinario VARCHAR (20) NOT NULL
);

CREATE TABLE RACA (
idRaca TINYINT PRIMARY KEY IDENTITY (1,1),
idTipo TINYINT FOREIGN KEY REFERENCES TIPOPET(idTipo),
nomeRaca VARCHAR (25) NOT NULL
);

CREATE TABLE PET (
	idPet SMALLINT PRIMARY KEY IDENTITY (1,1),
	idRaca TINYINT FOREIGN KEY REFERENCES RACA(idRaca),
	idDono SMALLINT FOREIGN KEY REFERENCES DONO(idDono),
	nomePet VARCHAR (20) NOT NULL
);

CREATE TABLE ATENDIMENTO (
idAtendimento SMALLINT PRIMARY KEY IDENTITY (1,1),
idVeterinario SMALLINT FOREIGN KEY REFERENCES VETERINARIO(idVeterinario), 
idPet SMALLINT FOREIGN KEY REFERENCES PET(idPet),
dataAtendimento VARCHAR (10) NOT NULL
);