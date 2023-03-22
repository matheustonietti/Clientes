using APITruck.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITruck.Controllers
{
    [ApiController]
    [Route("api/Caminhao")]
    public class CaminhaoController : ControllerBase
    {

        private IClienteRepository _clienteRepository { get; set; }

        public CaminhaoController(IClienteRepository caminhaoRepository)
        {
            _clienteRepository = caminhaoRepository;
        }

        /// <summary>
        /// Retorna o que corresponde ao Id
        /// </summary>
        /// <returns>Caminhao pelo Id</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(string nome)
        {
            if (nome == "")
            {
                throw new Exception($"Nome não pode ser vazio.");
            }

            var caminhao = await _clienteRepository.Buscar(nome);

            if (caminhao == null)
            {
                throw new Exception("Caminhao não localizado");
            }

            return Ok(caminhao);
        }

        /// <summary>
        /// Retorna a lista completa
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var caminhoes = await _clienteRepository.Listar();
            return Ok(caminhoes);
        }

        /// <summary>
        /// Insere
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Cliente cliente)
        {
            cliente.Id = 0;

            //if (caminhao.AnoFabricacao == 0 || caminhao.AnoModelo == 0)
            //{
            //    throw new Exception($"Ano de Fabricação e Ano do modelo não podem ser 0 ou inexistentes");
            //}
          
            var caminhaodb = await _clienteRepository.Inserir(cliente);
            return new ObjectResult(caminhaodb) { StatusCode = StatusCodes.Status201Created };
        }

        /// <summary>
        /// Atualiza o Caminhão através do Id
        /// </summary>        
        /// <param name="id"></param>
        /// <param name="caminhao"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] string nome, [FromBody] Cliente cliente)
        {
            //if (id == 0)
            //{
            //    throw new Exception($"Id não pode ser zero ou nulo.");
            //}
           
            var caminhaodb = await _clienteRepository.Atualizar(nome, cliente);
            return new ObjectResult(caminhaodb) { StatusCode = StatusCodes.Status200OK };
        }

        /// <summary>
        /// Deleta o que corresponde ao Id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string nome)
        {
            //if(id == 0)
            //{
            //    throw new Exception($"Id não pode ser zero ou nulo.");
            //}
            await _clienteRepository.Deletar(nome);
            return Ok();
        }
    }
}
