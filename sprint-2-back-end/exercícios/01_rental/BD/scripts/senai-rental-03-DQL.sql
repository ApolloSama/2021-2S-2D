USE T_Rental;
GO

SELECT nomeCliente, surNameCliente, nomeModelo, dataAluguel, dataDevolucao FROM ALUGUEL
RIGHT JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
LEFT JOIN VEICULO
ON VEICULO.idVeiculo = ALUGUEL.idVeiculo
LEFT JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo
GO

SELECT placaCarro, nomeMarca, nomeModelo, nomeEmpresa FROM VEICULO
INNER JOIN MODELO
ON VEICULO.idModelo = MODELO.idModelo
LEFT JOIN MARCA
ON MODELO.idMarca = MARCA.idMarca
INNER JOIN EMPRESA
ON VEICULO.IdEmpresa = EMPRESA.idEmpresa
GO

SELECT * FROM ALUGUEL
SELECT idAluguel, idVeiculo, idCliente, dataAluguel, dataDevolucao FROM ALUGUEL
SELECT * FROM CLIENTE
SELECT idCliente, nomeCliente, surNameCliente, CNH FROM CLIENTE
SELECT * FROM EMPRESA
SELECT * FROM MARCA
SELECT * FROM MODELO
SELECT * FROM VEICULO
SELECT idVeiculo, idEmpresa, idModelo, placaCarro FROM VEICULO