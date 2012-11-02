using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Projeto_Tcc.Entidades;

namespace Projeto_Tcc.Repositorio.Mappings
{
    public class AcessoMap : ClassMap<Acesso>
    {
        public AcessoMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();
            Map(x => x.Descricao);
        }
    }
}
