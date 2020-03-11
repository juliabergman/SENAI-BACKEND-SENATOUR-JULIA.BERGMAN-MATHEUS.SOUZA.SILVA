using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private SenaturContext ctx = new SenaturContext();

        public Usuarios Buscar(string Email, string Senha)
        {
            
           var Usuario= ctx.Usuarios.FirstOrDefault(u => u.Email == Email);
            Usuario = ctx.Usuarios.FirstOrDefault(u => u.Senha == Senha);

            return (Usuario);

        }

        public List<Usuarios> Listar()
        //Listar todos os usuários mostrando o título do tipo de usuário
        //usando o include
        {
           
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }
    }
}
