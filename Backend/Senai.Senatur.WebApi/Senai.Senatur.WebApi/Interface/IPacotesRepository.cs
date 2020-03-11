using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interface { 
    
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


        // fazendo o extra, listando só por ativo
        List<Pacotes> ListarPorAtivo();
        // fazendo o extra, listando só por inativo

        List<Pacotes> ListarPorInativo();

        // extra, listando por cidades
        List<Pacotes> ListarPorCidade(string Cidade);



    }
}

