USE CLINICA;
GO

SELECT nomeClinica, nomeVeterinario, CRMV FROM VETERINARIO
LEFT JOIN CLINICA
ON VETERINARIO.idClinica = CLINICA.idClinica

------------------------------------------------------------------

SELECT nomeRaca FROM RACA
WHERE nomeRaca LIKE 's%'

------------------------------------------------------------------

SELECT nomeTipo FROM TIPOPET
WHERE nomeTipo LIKE '%o'

------------------------------------------------------------------

SELECT nomePet, nomeDono FROM PET
LEFT JOIN DONO
ON PET.idDono = DONO.idDono

------------------------------------------------------------------

SELECT nomeVeterinario, nomePet, nomeTipo, nomeRaca , nomeDono, nomeClinica FROM ATENDIMENTO
LEFT JOIN VETERINARIO
ON ATENDIMENTO.idVeterinario = VETERINARIO.idVeterinario
LEFT JOIN PET
ON ATENDIMENTO.idPet = PET.idPet
LEFT JOIN RACA
ON PET.idRaca = RACA.idRaca
LEFT JOIN TIPOPET
ON RACA.idTipo = TIPOPET.idTipo
LEFT JOIN DONO
ON PET.idDono = DONO.idDono
LEFT JOIN CLINICA
ON VETERINARIO.idClinica = CLINICA.idClinica

-------------------------------------------------------------------

SELECT * FROM CLINICA
SELECT * FROM PET
SELECT * FROM DONO
SELECT * FROM VETERINARIO
SELECT * FROM RACA
SELECT * FROM ATENDIMENTO
SELECT * FROM TIPOPET