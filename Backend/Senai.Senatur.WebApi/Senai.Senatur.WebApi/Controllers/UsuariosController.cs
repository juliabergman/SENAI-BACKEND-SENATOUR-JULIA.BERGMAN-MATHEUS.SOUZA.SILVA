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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository { get; set; }
        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }
        /// <summary>
        /// LISTANDO OS USUARIOS
        /// </summary>
        /// <returns>retorna a lista de usuarios</returns>
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            return _usuariosRepository.Listar();

        }
        
    }
}