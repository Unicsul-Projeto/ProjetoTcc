using FluentNHibernate.Mapping;
using Projeto_Tcc.Entidades;

namespace Projeto_Tcc.Repositorio.Mappings
{
    public class SexoMap :ClassMap<Sexo>
    {
        public SexoMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();
            Map(x => x.Descricao);
        }
    }
}
