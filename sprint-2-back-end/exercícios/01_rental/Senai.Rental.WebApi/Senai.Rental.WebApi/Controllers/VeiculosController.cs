using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Senai.Rental.WebApi.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato domino/api/nomeController.
    // ex: http://localhost:5000/api/veiculos
    [Route("api/[controller]")]

    //Define que é um controlador de API.
    [ApiController]

    public class VeiculosController : ControllerBase
    {
        /// <summary>
        /// Obejto _veiculoRepository que irá receber todos os metodos definidor na interface IVeiculoRepository
        /// </summary>
        private IVeiculoRepository _veiculoRepository { get; set; }
        /// <summary>
        /// Instancia um objeto _veiculoRepository para que haja a referencia aos metodos no repositorio.
        /// </summary>
        public VeiculosController()
        {
            _veiculoRepository = new VeiculoRepository();
        }
        /// <summary>
        /// Lista todos os veiculos
        /// </summary>
        /// <returns>Uma lista de veiculos e um status code.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Criar uma lista nomeada listaVeiculos para receber os dados.
            List<VeiculoDomain> listaVeiculos = _veiculoRepository.ListarTodos();

            //Retorna o status code 200(OK) com a lista de gêneros no formato JSON
            return Ok(listaVeiculos);

        }

        [HttpPut]
        public IActionResult PutIdBody(VeiculoDomain veiculoAtualizado)
        {
            VeiculoDomain veiculoBuscado = _veiculoRepository.BuscarPorId(veiculoAtualizado.idVeiculo);

            if (veiculoBuscado != null)
            {
                try
                {
                    _veiculoRepository.AtualizarIdCorpo(veiculoAtualizado);

                    return NoContent();
                }
                catch (Exception codigoErro)
                {
                    return BadRequest(codigoErro);
                }
            }
            return NotFound(
                new
                {
                    mensagem = "veiculo não encontrado",
                    errorstats = true
                }
                );
        }

        /// <summary>
        /// Cadastra um novo veículo
        /// </summary>
        /// <returns>Um status code indicando que foi criado</returns>
        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            _veiculoRepository.Cadastrar(novoVeiculo);
            return StatusCode(201);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _veiculoRepository.Deletar(id);

            return NoContent();
        }
    }
}
