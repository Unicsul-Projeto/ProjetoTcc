using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Repositorio.Repositorios
{
    public interface IPessoaFisicaRepositorio : IRepositorio<PessoaFisica>
    {
        IList<PessoaFisica> PesquisarPorNome(string nome);
        IList<PessoaFisica> PesquisarPorCpf(string cpf);
        IList<PessoaFisica> PesquisarPorRg(string rg);
    }

    public class PessoaFisicaRepositorio : DAO<PessoaFisica>, IPessoaFisicaRepositorio
    {
        public PessoaFisicaRepositorio(SessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }

        public IList<PessoaFisica> PesquisarPorNome(string nome)
        {
            return Session.QueryOver<PessoaFisica>()
                .Where(Restrictions.On<PessoaFisica>(x => x.Nome).IsLike(nome + "%")).List();
        }

        public IList<PessoaFisica> PesquisarPorCpf(string cpf)
        {
            return Session.QueryOver<PessoaFisica>()
                .Where(Restrictions.On<PessoaFisica>(x => x.Cpf).IsLike(cpf + "%")).List();
        }

        public IList<PessoaFisica> PesquisarPorRg(string rg)
        {
            return Session.QueryOver<PessoaFisica>()
                .Where(Restrictions.On<PessoaFisica>(x => x.Rg).IsLike(rg + "%")).List();
        }

        public IList<PessoaFisica> PesquisarPorUf(Uf uf)
        {
            return Session.QueryOver<PessoaFisica>().Where(x => x.Endereco.Uf == uf).List();
        }
    }
}
