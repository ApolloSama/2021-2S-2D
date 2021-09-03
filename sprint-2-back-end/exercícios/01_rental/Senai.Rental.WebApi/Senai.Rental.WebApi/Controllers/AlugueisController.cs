using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Controlador responsavel pelos end points referentes aos alugueis
/// </summary>
namespace Senai.Rental.WebApi.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato domino/api/nomeController.
    // ex: http://localhost:5000/api/alugueis
    [Route("api/[controller]")]

    //Define que é um controlador de API.
    [ApiController]

    public class AlugueisController : ControllerBase
    {
        /// <summary>
        /// Obejto _aluguelRepository que irá receber todos os metodos definidor na interface IAluguelRepository
        /// </summary>
        private IAluguelRepository _aluguelRepository { get; set; }
        /// <summary>
        /// Instancia um objeto _aluguelRepository para que haja a referencia aos metodos no repositorio.
        /// </summary>
        public AlugueisController()
        {
            _aluguelRepository = new AluguelRepository();
        }
        /// <summary>
        /// Lista todos os aluguéis
        /// </summary>
        /// <returns>Uma lista de aluguéis e um status code.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Criar uma lista nomeada listaAlugueis para receber os dados.
            List<AluguelDomain> listaAlugueis = _aluguelRepository.ListarTodos();

            //Retorna o status code 200(OK) com a lista de gêneros no formato JSON
            return Ok(listaAlugueis);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AluguelDomain aluguelBuscado = _aluguelRepository.BuscarPorId(id);

            if (aluguelBuscado == null)
            {
                return NotFound();
            }

            return Ok(aluguelBuscado);
        }

        /// <summary>
        /// Cadastra um novo veículo
        /// </summary>
        /// <returns>Um status code indicando que foi criado</returns>
        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            _aluguelRepository.Cadastrar(novoAluguel);
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult PutIdBody(AluguelDomain aluguelAtualizado)
        {
            AluguelDomain aluguelBuscado = _aluguelRepository.BuscarPorId(aluguelAtualizado.idAluguel);

            if (aluguelBuscado != null)
            {
                try
                {
                    _aluguelRepository.AtualizarIdCorpo(aluguelAtualizado);

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
                    mensagem = "aluguel não encontrado",
                    errorstats = true
                }
                );
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _aluguelRepository.Deletar(id);

            return NoContent();
        }
    }
}