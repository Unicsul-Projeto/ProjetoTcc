using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Repositorio.Repositorios
{
    public interface ISetorRepositorio : IRepositorio<Setor>
    {
        IList<Setor> PesquisarPorDescricao(string descricao);
    }

    public class SetorRepositorio : DAO<Setor>, ISetorRepositorio
    {
        public SetorRepositorio(SessionProvider sessionProvider) : base(sessionProvider)
        {
        }

        public IList<Setor> PesquisarPorDescricao(string descricao)
        {
            return Session.QueryOver<Setor>()
                .Where(Restrictions
                    .On<Setor>(x => x.Descricao)
                        .IsLike(descricao + "%")).List<Setor>();
        } 
    }
}
