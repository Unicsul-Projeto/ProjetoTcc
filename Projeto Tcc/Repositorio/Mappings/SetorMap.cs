using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Projeto_Tcc.Entidades;

namespace Projeto_Tcc.Repositorio.Mappings
{
    public class SetorMap:ClassMap<Setor>
    {
        public SetorMap()
        {
            Id(x => x.Id).Column("ID").GeneratedBy.Native();
            Map(x => x.Descricao);

            HasMany(x => x.Cargos).Cascade.AllDeleteOrphan();
        }
    }
}
