using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Projeto_Tcc.Entidades;

namespace Projeto_Tcc.Repositorio.Mappings
{
    public class FuncionarioMap : ClassMap<Funcionario>
    {
        public FuncionarioMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();
            Map(x => x.NumCarteira);
            Map(x => x.DataAdmissao);
            Map(x => x.DataDemissao);

            References(x => x.PessoaFisica);
            References(x => x.Cargo);
        }
    }
}
