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
/// Controlador responsavel pelos end points referentes aos clientes
/// </summary>
namespace Senai.Rental.WebApi.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato domino/api/nomeController.
    // ex: http://localhost:5000/api/clientes
    [Route("api/[controller]")]

    //Define que é um controlador de API.
    [ApiController]

    public class ClientesController : ControllerBase
    {
        /// <summary>
        /// Obejto _clienteRepository que irá receber todos os metodos definidor na interface IClienteRepository
        /// </summary>
        private IClienteRepository _clienteRepository { get; set; }
        /// <summary>
        /// Instancia um objeto _clienteRepository para que haja a referencia aos metodos no repositorio.
        /// </summary>
        public ClientesController()
        {
            _clienteRepository = new ClienteRepository();
        }
        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <returns>Uma lista de clientes e um status code.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Criar uma lista nomeada listaClientes para receber os dados.
            List<ClienteDomain> listaClientes = _clienteRepository.ListarTodos();

            //Retorna o status code 200(OK) com a lista de gêneros no formato JSON
            return Ok(listaClientes);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClienteDomain clienteBuscado = _clienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
            {
                return NotFound();
            }

            return Ok(clienteBuscado);
        }

        /// <summary>
        /// Cadastra um novo veículo
        /// </summary>
        /// <returns>Um status code indicando que foi criado</returns>
        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            _clienteRepository.Cadastrar(novoCliente);
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult PutIdBody(ClienteDomain clienteAtualizado)
        {
            ClienteDomain clienteBuscado = _clienteRepository.BuscarPorId(clienteAtualizado.idCliente);

            if (clienteBuscado != null)
            {
                try
                {
                    _clienteRepository.AtualizarIdCorpo(clienteAtualizado);

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
                    mensagem = "cliente não encontrado",
                    errorstats = true
                }
                );
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _clienteRepository.Deletar(id);

            return NoContent();
        }
    }
}