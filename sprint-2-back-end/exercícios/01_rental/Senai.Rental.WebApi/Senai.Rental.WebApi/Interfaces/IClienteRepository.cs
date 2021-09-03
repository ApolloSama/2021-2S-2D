using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ClienteRepository
    /// </summary>
    interface IClienteRepository
    {
        //Estrutura dos métodos
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro)
        //Ex: GeneroDomain Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Lista todos os clientes do ClienteDomain
        /// </summary>
        /// <returns>Lista de clientes</returns>
        List<ClienteDomain> ListarTodos();

        /// <summary>
        /// Busca um objeto ClienteDomain através de um idCliente
        /// </summary>
        /// <param name="idCliente">id do cliente que será buscado</param>
        /// <returns>um cliente que foi buscado</returns>
        ClienteDomain BuscarPorId(int idCliente);

        /// <summary>
        /// Cadastra um novoCliente através de um ClienteDomain
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente com novos dados</param>
        void Cadastrar(ClienteDomain novoCliente);

        /// <summary>
        /// Atualiza um cliente já existente
        /// </summary>
        /// <param name="clienteAtualizado">Objeto clienteAtualizado com os dados atualizados</param>
        void AtualizarIdCorpo(ClienteDomain clienteAtualizado);

        /// <summary>
        /// Atualiza um cliente já existente
        /// </summary>
        /// <param name="idCliente">Id do cliente que será atualizado</param>
        /// <param name="clienteAtualizado">Objeto clienteAtualizado com os dados atualizados</param>
        void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado);

        /// <summary>
        /// Deleta um cliente já existente
        /// </summary>
        /// <param name="idCliente">id do cliente que será deletado</param>
        void Deletar(int idCliente);
    }
}
