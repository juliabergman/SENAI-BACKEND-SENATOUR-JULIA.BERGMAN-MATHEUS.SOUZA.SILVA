using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interface;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    //Matheus Esteve aq
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

        [HttpGet]
        public IEnumerable<Pacotes> Get()
        {
            return _pacotesRepository.Listar();
        }

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

        [HttpPost]
        public IActionResult Post(Pacotes pacoteNovo)
        {
            _pacotesRepository.Cadastro(pacoteNovo);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Put(Pacotes pacotesAtualizado)
        {
            //Pacotes pacotesBuscado = _pacotesRepository.Buscar(pacotesAtualizado.IdPacote);

            _pacotesRepository.Alterar(pacotesAtualizado);

            return Ok("Pacote Atualizado.");
        }
    }
}