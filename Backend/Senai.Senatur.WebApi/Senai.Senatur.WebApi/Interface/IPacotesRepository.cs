using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interface { 
    // julia fez esse
    interface IPacotesRepository
    {
    // primeiro tem que colocar o retorno
    // cadastro é void
    void Cadastro(Pacotes pacotes);
    //buscar é Pacotes

    Pacotes Buscar(int id);

    //alterar é void
    void Alterar(Pacotes pacotes);

    // listar obviamente em listas
    List<Pacotes> Listar();

    



    }
}

