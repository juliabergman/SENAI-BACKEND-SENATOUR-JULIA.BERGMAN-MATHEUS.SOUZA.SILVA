using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interface;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{

   
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        private IPacotesRepository _pacotesRepository { get; set; }

        public PacotesController()
        {
            _pacotesRepository = new PacotesRepository();
        }
        
        /// <summary>
        /// gerando uma lista
        /// </summary>
        /// <returns>retorna a lista de pacotes</returns>
        [HttpGet]
        public IEnumerable<Pacotes> Get()
        {
            return _pacotesRepository.Listar();
        }

        /// <summary>
        /// buscando um pacote pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna o pacote </returns>
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            Pacotes pacoteBuscado = _pacotesRepository.Buscar(id);

            if (pacoteBuscado == null)
            {
                return NotFound("Pacote não encontrado.");
            }

            return Ok(pacoteBuscado);
        }

        /// <summary>
        ///cadastrando um pacote
        /// </summary>
        /// <param name="pacoteNovo"></param>
        /// <returns>retorna o statuscode 201</returns>
        //só o adm pode cadastrar
        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Post(Pacotes pacoteNovo)
        {
            _pacotesRepository.Cadastro(pacoteNovo);

            return StatusCode(201);
        }

        /// <summary>
        /// atualizando um pacote
        /// </summary>
        /// <param name="pacotesAtualizado"></param>
        /// <returns>retorna com "return Ok"</returns>
        //só o adm pode cadastrar
        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Put(Pacotes pacotesAtualizado)
        {
            //Pacotes pacotesBuscado = _pacotesRepository.Buscar(pacotesAtualizado.IdPacote);

            _pacotesRepository.Alterar(pacotesAtualizado);

            return Ok("Pacote Atualizado.");
        }
    }
}