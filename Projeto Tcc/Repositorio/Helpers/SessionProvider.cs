using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Projeto_Tcc.Repositorio.Helpers
{
    public class SessionProvider
    {
        private readonly ISessionFactory _sessionFactory;
        private ISession _session;

        public SessionProvider(SessionFactoryProvider sessionFactoryProvider)
        {
            _sessionFactory = sessionFactoryProvider.GetSessionFactory();
        }

        public ISession GetCurrentSession()
        {
            return _session ?? (_session = _sessionFactory.OpenSession());
        }

        public void Dispose()
        {
            if (_session != null)
            {
                _session.Dispose();
            }
        }
    }
}
