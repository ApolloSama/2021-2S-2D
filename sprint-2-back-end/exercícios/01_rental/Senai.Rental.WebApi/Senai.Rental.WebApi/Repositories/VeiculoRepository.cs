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
    /// Classe Responsável pelo repositório dos veiculos
    /// </summary>
    public class VeiculoRepository : IVeiculoRepository
    {
        /// <summary>
        /// string de conexão com o banco de dados
        /// </summary>
        private string stringConexao = @"Data Source=DESKTOP-GBQM7GO\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";

        public void AtualizarIdCorpo(VeiculoDomain veiculoAtualizado)
        {
            if (veiculoAtualizado.placaCarro != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE VEICULO SET idEmpresa = @idEmpresa, idModelo = @idModelo, placaCarro = @placaCarro WHERE idVeiculo = @idVeiculo";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idEmpresa", veiculoAtualizado.idEmpresa);
                        cmd.Parameters.AddWithValue("@idModelo", veiculoAtualizado.idModelo);
                        cmd.Parameters.AddWithValue("@placaCarro", veiculoAtualizado.placaCarro);
                        cmd.Parameters.AddWithValue("@idVeiculo", veiculoAtualizado.idVeiculo);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            throw new NotImplementedException();
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idVeiculo, idEmpresa, idModelo, placaCarro FROM VEICULO WHERE idVeiculo = @idVeiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculoDomain veiculoBuscado = new VeiculoDomain
                        {
                            idVeiculo = Convert.ToInt32(rdr["idVeiculo"]),

                            idEmpresa = Convert.ToInt32(rdr["idEmpresa"]),

                            idModelo = Convert.ToInt32(rdr["idModelo"]),

                            placaCarro = rdr["placaCarro"].ToString()
                        };

                        return veiculoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO VEICULO (idEmpresa,idModelo,placaCarro) VALUES (@idEmpresa, @idModelo, @placaCarro)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", novoVeiculo.idEmpresa);

                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);

                    cmd.Parameters.AddWithValue("@placaCarro", novoVeiculo.placaCarro);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();

            // Declara uma coneção passando a string de conexão como parâmetro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idVeiculo, idEmpresa, idModelo, placaCarro FROM VEICULO";

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
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            idEmpresa = Convert.ToInt32(rdr[1]),
                            idModelo = Convert.ToInt32(rdr[2]),
                            placaCarro = rdr[3].ToString()
                        };

                        listaVeiculos.Add(veiculo);

                    }
                }
            };
            return listaVeiculos;
        }
    }
}
