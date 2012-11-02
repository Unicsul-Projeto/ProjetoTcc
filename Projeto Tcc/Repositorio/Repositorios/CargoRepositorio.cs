using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Repositorio.Repositorios
{
    public interface ICargoRepositorio:IRepositorio<Cargo>
    {
        IList<Cargo> PesquisarPorDescricao(string descricao);
        IList<Cargo> PesquisarPorSetor(Setor setor);
        IList<Cargo> PesquisarPorSetorDescricao(Setor setor, string descricao);
    }

    public class CargoRepositorio:DAO<Cargo>,ICargoRepositorio
    {
        public CargoRepositorio(SessionProvider sessionProvider) : base(sessionProvider)
        {
        }

        public IList<Cargo> PesquisarPorDescricao(string descricao)
        {
            return Session.QueryOver<Cargo>()
                .Where(Restrictions
                    .On<Cargo>(x => x.Descricao)
                        .IsLike(descricao + "%")).List<Cargo>();
        }

        public IList<Cargo> PesquisarPorSetor(Setor setor)
        {
            var qo =  Session.QueryOver<Cargo>().Where(x => x .Setor.Descricao == setor.Descricao);
            return qo.List();
        }

        public IList<Cargo> PesquisarPorSetorDescricao(Setor setor, string descricao)
        {
            return Session.QueryOver<Cargo>()
                .Where(x=>x.Setor == setor)
                .And(Restrictions
                    .On<Cargo>(x => x.Descricao)
                        .IsLike(descricao + "%")).List<Cargo>();
        } 
    }
}
