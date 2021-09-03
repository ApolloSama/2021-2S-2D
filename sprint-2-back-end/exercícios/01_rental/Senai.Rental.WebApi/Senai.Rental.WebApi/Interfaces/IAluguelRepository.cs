using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório AluguelRepository
    /// </summary>
    interface IAluguelRepository
    {
        //Estrutura dos métodos
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro)
        //Ex: GeneroDomain Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Lista todos os aluguels do AluguelDomain
        /// </summary>
        /// <returns>Lista de aluguels</returns>
        List<AluguelDomain> ListarTodos();

        /// <summary>
        /// Busca um objeto AluguelDomain através de um idAluguel
        /// </summary>
        /// <param name="idAluguel">id do aluguel que será buscado</param>
        /// <returns>um aluguel que foi buscado</returns>
        AluguelDomain BuscarPorId(int idAluguel);

        /// <summary>
        /// Cadastra um novoAluguel através de um AluguelDomain
        /// </summary>
        /// <param name="novoAluguel">Objeto novoAluguel com novos dados</param>
        void Cadastrar(AluguelDomain novoAluguel);

        /// <summary>
        /// Atualiza um aluguel já existente
        /// </summary>
        /// <param name="aluguelAtualizado">Objeto aluguelAtualizado com os dados atualizados</param>
        void AtualizarIdCorpo(AluguelDomain aluguelAtualizado);

        /// <summary>
        /// Atualiza um aluguel já existente
        /// </summary>
        /// <param name="idAluguel">Id do aluguel que será atualizado</param>
        /// <param name="aluguelAtualizado">Objeto aluguelAtualizado com os dados atualizados</param>
        void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado);

        /// <summary>
        /// Deleta um aluguel já existente
        /// </summary>
        /// <param name="idAluguel">id do aluguel que será deletado</param>
        void Deletar(int idAluguel);
    }
}
