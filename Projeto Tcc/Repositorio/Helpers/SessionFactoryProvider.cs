using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.ByteCode.Castle;
using Projeto_Tcc.Repositorio.Mappings;

namespace Projeto_Tcc.Repositorio.Helpers
{
    public class SessionFactoryProvider : IDisposable
    {
        private FluentConfiguration _fluentConfiguration;
        private ISessionFactory _sessionFactory;

        #region IDisposable Members

        public void Dispose()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Dispose();
            }
        }

        #endregion

        public ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
            {
                _fluentConfiguration = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ShowSql()
                                  .ConnectionString(("Data Source=.;Initial Catalog=ProjetoTCC;Integrated Security=True")))
                                  //.ConnectionString(@"Data Source=.\sqlexpress;Initial Catalog=Pizzaria;Integrated Security=True"))
                    //.Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<PessoaFisica>(new AppAutomappingCfg())));
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PessoaFisicaMap>());
                //.Conventions.Setup(GetConventions()));

                _sessionFactory = _fluentConfiguration.BuildSessionFactory();

                //var cfg = Fluently.Configure()
                //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Usuario>())
                //    .Database(MsSqlConfiguration.MsSql2008.ShowSql()
                //                  .ConnectionString(c => c.FromConnectionStringWithKey("ConnectionString"))
                //    );
            }

            return _sessionFactory;
        }

        //public void AutoCriarBancoDeDados()
        //{
        //    if (_fluentConfiguration != null)
        //    {
        //        var sessionSource = new SessionSource(_fluentConfiguration);
        //        ISession session = sessionSource.CreateSession();
        //        sessionSource.BuildSchema(session);
        //    }
        //}

    }

    public class AppAutomappingCfg : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace != null && type.Namespace.StartsWith("ProjetoTcc.Entidades");
        }

    }
}
