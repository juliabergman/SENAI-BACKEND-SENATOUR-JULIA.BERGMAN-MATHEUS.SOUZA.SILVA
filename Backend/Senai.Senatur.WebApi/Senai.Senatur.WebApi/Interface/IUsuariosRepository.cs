using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interface
{
    interface IUsuariosRepository
    {
        List<Usuarios> Listar();

        Usuarios Buscar(string Email, string Senha);

    }
}
