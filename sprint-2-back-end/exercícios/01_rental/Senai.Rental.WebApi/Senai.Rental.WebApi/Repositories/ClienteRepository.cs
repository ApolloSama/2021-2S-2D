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
    /// Classe Responsável pelo repositório dos clientes
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        /// <summary>
        /// string de conexão com o banco de dados
        /// </summary>
        private string stringConexao = @"Data Source=DESKTOP-GBQM7GO\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";

        public void AtualizarIdCorpo(ClienteDomain clienteAtualizado)
        {
            if (clienteAtualizado.CNH != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE CLIENTE SET nomeCliente = @nomeCliente, surNameCliente = @surNameCliente, CNH = @CNH WHERE idCliente = @idCliente";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);
                        cmd.Parameters.AddWithValue("@surNameCliente", clienteAtualizado.surNameCliente);
                        cmd.Parameters.AddWithValue("@CNH", clienteAtualizado.CNH);
                        cmd.Parameters.AddWithValue("@idCliente", clienteAtualizado.idCliente);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado)
        {
            throw new NotImplementedException();
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idCliente, nomeCliente, surNameCliente, CNH FROM CLIENTE WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(rdr["idCliente"]),

                            nomeCliente = rdr["nomeCliente"].ToString(),

                            surNameCliente = rdr["surNameCliente"].ToString(),

                            CNH = rdr["CNH"].ToString()
                        };

                        return clienteBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert;

                if (novoCliente.CNH != null)
                {
                    queryInsert = "INSERT INTO CLIENTE (nomeCliente, surNameCliente, CNH) VALUES(@nomeCliente, @surNameCliente, @CNH)";
                }
                else
                {
                    queryInsert = "INSERT INTO CLIENTE (nomeCliente,surNameCliente) VALUES(@nomeCliente,@surNameCliente)";
                }

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);

                    cmd.Parameters.AddWithValue("@surNameCliente", novoCliente.surNameCliente);

                    if (novoCliente.CNH != null)
                    {

                        cmd.Parameters.AddWithValue("@CNH", novoCliente.CNH);

                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idCliente";


                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaClientes = new List<ClienteDomain>();

            // Declara uma coneção passando a string de conexão como parâmetro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idCliente, nomeCliente, surNameCliente, CNH FROM CLIENTE";

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
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),
                            nomeCliente = rdr[1].ToString(),
                            surNameCliente = rdr[2].ToString(),
                            CNH = rdr[3].ToString()
                        };

                        listaClientes.Add(cliente);

                    }
                }
            };
            return listaClientes;
        }
    }
}
