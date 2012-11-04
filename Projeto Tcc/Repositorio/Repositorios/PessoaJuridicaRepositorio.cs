using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Repositorio.Repositorios
{
    public interface IPessoaJuridicaRepositorio : IRepositorio<PessoaJuridica>
    {
        IList<PessoaJuridica> PesquisarPorNomeFantasia(string nomeFantasia);
        IList<PessoaJuridica> PesquisarPorRazaoSocial(string razaoSocial);
        IList<PessoaJuridica> PesquisarPorCnpj(string cnpj);
    }
    public class PessoaJuridicaRepositorio : DAO<PessoaJuridica>, IPessoaJuridicaRepositorio
    {
        public PessoaJuridicaRepositorio(SessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }

        public IList<PessoaJuridica> PesquisarPorNomeFantasia(string nomeFantasia)
        {
            return Session.QueryOver<PessoaJuridica>()
                .Where(Restrictions.On<PessoaJuridica>(x => x.NomeFantasia).IsLike(nomeFantasia + "%")).List();
        }

        public IList<PessoaJuridica> PesquisarPorRazaoSocial(string razaoSocial)
        {
            return Session.QueryOver<PessoaJuridica>()
                .Where(Restrictions.On<PessoaJuridica>(x => x.RazaoSocial).IsLike(razaoSocial + "%")).List();
        }

        public IList<PessoaJuridica> PesquisarPorCnpj(string cnpj)
        {
            return Session.QueryOver<PessoaJuridica>()
                .Where(Restrictions.On<PessoaJuridica>(x => x.CNPJ).IsLike(cnpj+ "%")).List();
        }
    }
}
