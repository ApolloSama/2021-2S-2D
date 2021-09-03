using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    /// <summary>
    /// Classe Responsável pelo repositório dos aluguéis
    /// </summary>
    public class AluguelRepository : IAluguelRepository
    {
        /// <summary>
        /// string de conexão com o banco de dados
        /// </summary>
        private string stringConexao = @"Data Source=DESKTOP-GBQM7GO\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";

        public void AtualizarIdCorpo(AluguelDomain aluguelAtualizado)
        {
            if (aluguelAtualizado.dataAluguel != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE ALUGUEL SET idVeiculo = @idVeiculo, idCliente = @idCliente, dataAluguel = @dataAluguel, dataDevolucao = @dataDevolucao WHERE idAluguel = @idAluguel";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", aluguelAtualizado.idCliente);
                        cmd.Parameters.AddWithValue("@dataAluguel", aluguelAtualizado.dataAluguel);
                        cmd.Parameters.AddWithValue("@dataDevolucao", aluguelAtualizado.dataDevolucao);
                        cmd.Parameters.AddWithValue("@idAluguel", aluguelAtualizado.idAluguel);


                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            throw new NotImplementedException();
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idAluguel, idVeiculo, idCliente, dataAluguel, dataDevolucao FROM ALUGUEL WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain
                        {
                            idAluguel = Convert.ToInt32(rdr["idAluguel"]),

                            idVeiculo = Convert.ToInt32(rdr["idVeiculo"]),

                            idCliente = Convert.ToInt32(rdr["idCliente"]),

                            dataAluguel = rdr["dataAluguel"].ToString(),

                            dataDevolucao = rdr["dataDevolucao"].ToString()
                        };

                        return aluguelBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            // Declara uma SqlConnection com a string de conexão como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert;
                if (novoAluguel.dataDevolucao == null)
                {
                    queryInsert = "INSERT INTO ALUGUEL (idVeiculo,idCliente,dataRetirada) VALUES (@idVeiculo, @idCliente, @dataRetirada)";
                }
                else
                {
                    queryInsert = "INSERT INTO ALUGUEL (idVeiculo, idCliente, dataAluguel, dataDevolucao) VALUES ( @idVeiculo, @idCliente, @dataAluguel,@dataDevolucao)";
                }

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);

                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);

                    cmd.Parameters.AddWithValue("@dataAluguel", novoAluguel.dataAluguel);

                    if (novoAluguel.dataDevolucao != null)
                    {
                        cmd.Parameters.AddWithValue("@dataDevolucao", novoAluguel.dataDevolucao);
                    }

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            // Declara uma coneção passando a string de conexão como parâmetro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idAluguel, idVeiculo, idCliente, dataAluguel, dataDevolucao FROM ALUGUEL";

                //Abre a conexão com o banco de dados.
                con.Open();

                //Declarando o SqlDataReader rdr que percorre a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando da query que será executada e a conexão com parametros.
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    //executa a query e armazena os dados rdr.
                    rdr = cmd.ExecuteReader();

                    // Enquanto existem registros para lermos no rdr, o laço se repete.
                    while (rdr.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            idVeiculo = Convert.ToInt32(rdr[1]),
                            idCliente = Convert.ToInt32(rdr[2]),
                            dataAluguel = rdr[3].ToString(),
                            dataDevolucao = rdr[4].ToString()
                        };

                        listaAlugueis.Add(aluguel);

                    }
                }
            };
            return listaAlugueis;
        }
    }
}
