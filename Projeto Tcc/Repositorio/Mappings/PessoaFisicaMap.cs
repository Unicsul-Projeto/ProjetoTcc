using FluentNHibernate.Mapping;
using Projeto_Tcc.Entidades;

namespace Projeto_Tcc.Repositorio.Mappings
{
    public class PessoaFisicaMap:ClassMap<PessoaFisica>
    {
        public PessoaFisicaMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();

            Map(x => x.Nome);
            Map(x => x.Cpf).Not.Nullable();
            Map(x => x.Rg);
            Map(x => x.Telefone);
            Map(x => x.Celular);
            Map(x => x.NumeroEndereco);

            References(x => x.Endereco).Column("Endereco_Id").Cascade.All();
            References(x => x.Sexo).Column("Sexo_Id");
        }
    }
}
