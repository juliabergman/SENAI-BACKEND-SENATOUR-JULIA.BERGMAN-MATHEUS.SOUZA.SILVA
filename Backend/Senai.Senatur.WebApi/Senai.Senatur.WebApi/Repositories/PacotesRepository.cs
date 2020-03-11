using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
    //julia
    // famoso crud
{
    public class PacotesRepository : IPacotesRepository
    {
        private SenaturContext ctx = new SenaturContext();

        public void Alterar(Pacotes pacotesAtualizado)
        {
            // nesse linha a gente tá procurando o id que a gente fez no corpo da requisição
            //ele vai procurar no banco os dados
            //SE ELE ACHAR, ELE VAI
            //armazenar nesse ctx
            // e o ctx vai se armazevar no var pacotes
            //corpo da requisição == isso aqui no body do postman ó:
            //{
            //                          "idpacotes" : 1
            //                       }

            var pacotes = ctx.Pacotes.First(P => P.IdPacote == pacotesAtualizado.IdPacote);
                                    // esse valor
            pacotes.NomePacote = pacotesAtualizado.NomePacote;
            // vem pra cá
        
            pacotes.Descricao = pacotesAtualizado.Descricao;
            pacotes.DataIda = pacotesAtualizado.DataIda;
            pacotes.DataVolta = pacotesAtualizado.DataVolta;
            pacotes.Ativo = pacotesAtualizado.Ativo;
            pacotes.NomeCidade = pacotesAtualizado.NomeCidade;

            // aqui diz que o nome que a gente passou no nome da requisição vai ir pro pacotes

            // agora dando um SaveChanges();
            ctx.SaveChanges();

                }

        public Pacotes Buscar(int id)
        {
            return ctx.Pacotes.FirstOrDefault(p => p.IdPacote == id);
        }

        public void Cadastro(Pacotes pacotesNovo)
        {
            ctx.Pacotes.Add(pacotesNovo);
            ctx.SaveChanges();
        }

        public List<Pacotes> Listar()
        {
            return ctx.Pacotes.ToList();
        }


        // fazendo o extra, listando só por ativo
        // ativo = 1 ou true
        public List<Pacotes> ListarPorAtivo()
        {
            return ctx.Pacotes.ToList().FindAll(p => p.Ativo == true);

        }


        // extra, listando por cidades

        public List<Pacotes> ListarPorCidade(string Cidade)
        {
            return ctx.Pacotes.ToList().FindAll(p => p.NomeCidade == Cidade);
        }

        // fazendo o extra, listando só por inativo

        public List<Pacotes> ListarPorInativo()
        {
            return ctx.Pacotes.ToList().FindAll(p => p.Ativo == false);

        }


    }
}
