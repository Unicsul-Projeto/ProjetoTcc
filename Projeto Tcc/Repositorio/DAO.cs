using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Projeto_Tcc.Repositorio.Helpers;
using Projeto_Tcc.Repositorio.Repositorios;

namespace Projeto_Tcc.Repositorio
{
    public class DAO<T> : IRepositorio<T>
    {
        private readonly SessionProvider _sessionProvider;

        public DAO(SessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        protected ISession Session
        {
            get { return _sessionProvider.GetCurrentSession(); }
        }

        #region IRepositorio<T> Members

        public void Salvar(T entidade)
        {
            Session.SaveOrUpdate(entidade);
            Session.Flush();
        }

        public T Pesquisar(int id)
        {
            return Session.Load<T>(id);
        }

        public void Excluir(int id)
        {
            T entidade = Pesquisar(id);
            Excluir(entidade);
        }

        public void Excluir(T entidade)
        {
            Session.Delete(entidade);
            Session.Flush();
        }

        public IList<T> PesquisarTodos()
        {
            ICriteria criteria = Session.CreateCriteria(typeof(T));
            return criteria.List<T>();
        }

        #endregion
    }

    
}
