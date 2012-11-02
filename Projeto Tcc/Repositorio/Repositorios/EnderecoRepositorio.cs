using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Repositorio.Repositorios
{
    public interface IEnderecoRepositorio : IRepositorio<Endereco>
    {
        Endereco PesquisarPorCep(string cep);
    }

    public class EnderecoRepositorio :DAO<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(SessionProvider sessionProvider) : base(sessionProvider)
        {
        }

        public Endereco PesquisarPorCep(string cep)
        {
            return Session.QueryOver<Endereco>().Where(x => x.Cep == cep).SingleOrDefault<Endereco>();
        }
    }
}
