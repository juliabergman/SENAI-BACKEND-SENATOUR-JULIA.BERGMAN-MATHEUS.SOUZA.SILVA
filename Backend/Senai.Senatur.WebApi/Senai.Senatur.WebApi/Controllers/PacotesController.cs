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
        [Authorize(Roles = "1")]
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

        /// <summary>
        /// fazendo o extra, listando só por ativo
        /// </summary>
        /// <returns>retorna a lista de ativos</returns>
        [HttpGet("Ativo")]
        public IEnumerable<Pacotes>GetPorAtivo()
        {
            return _pacotesRepository.ListarPorAtivo();
        }

        /// <summary>
        /// fazendo o extra, listando só por inaativo
        /// </summary>
        /// <returns>retorna a lista de inativos</returns>

        [HttpGet("Inativo")]
        public IEnumerable<Pacotes> GetPorInativo()
        {
            return _pacotesRepository.ListarPorInativo();
        }

        /// <summary>
        /// fazendo o extra, listando só cidade
        /// </summary>
        /// <returns>retorna a lista de pacotes da cidade buscada</returns>

        [HttpGet("{Cidade}")]
        public IEnumerable<Pacotes> GetPorCidade(string Cidade)
        {
            return _pacotesRepository.ListarPorCidade(Cidade);
        }

        // EXTRA Listar os Pacotes com ordeew
        // primeiro a ordem caro
        /// <summary>
        /// Listando pela ordem de preço mais caro
        /// </summary>
        /// <returns>retorna os preços mais caros</returns>

        [HttpGet("Caro")]
        public IEnumerable<Pacotes> GetPorCaro()
        {
            return _pacotesRepository.ListarCaro();
        }


        // EXTRA Listar os Pacotes com ordenação por preço. Ou seja, do mais barato para o mais caro e vice-versa. 
        // agora o barato


        [HttpGet("Barato")]
        public IEnumerable<Pacotes> GetPorBarato()
        {
            return _pacotesRepository.ListarBarato();
        }




    }
}