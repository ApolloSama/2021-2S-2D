using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório VeiculoRepository
    /// </summary>
    interface IVeiculoRepository
    {
        //Estrutura dos métodos
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro)
        //Ex: GeneroDomain Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Lista todos os veiculos do VeiculoDomain
        /// </summary>
        /// <returns>Lista de veiculos</returns>
        List<VeiculoDomain> ListarTodos();

        /// <summary>
        /// Busca um objeto VeiculoDomain através de um idVeiculo
        /// </summary>
        /// <param name="idVeiculo">id do veiculo que será buscado</param>
        /// <returns>um veiculo que foi buscado</returns>
        VeiculoDomain BuscarPorId(int idVeiculo);

        /// <summary>
        /// Cadastra um novoVeiculo através de um VeiculoDomain
        /// </summary>
        /// <param name="novoVeiculo">Objeto novoVeiculo com novos dados</param>
        void Cadastrar(VeiculoDomain novoVeiculo);

        /// <summary>
        /// Atualiza um veiculo já existente
        /// </summary>
        /// <param name="veiculoAtualizado">Objeto veiculoAtualizado com os dados atualizados</param>
        void AtualizarIdCorpo(VeiculoDomain veiculoAtualizado);

        /// <summary>
        /// Atualiza um veiculo já existente
        /// </summary>
        /// <param name="idVeiculo">Id do veiculo que será atualizado</param>
        /// <param name="veiculoAtualizado">Objeto veiculoAtualizado com os dados atualizados</param>
        void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado);

        /// <summary>
        /// Deleta um veiculo já existente
        /// </summary>
        /// <param name="idVeiculo">id do veiculo que será deletado</param>
        void Deletar(int idVeiculo);
    }
}
