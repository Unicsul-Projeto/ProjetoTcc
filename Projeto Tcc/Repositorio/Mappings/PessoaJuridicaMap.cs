using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Projeto_Tcc.Entidades;

namespace Projeto_Tcc.Repositorio.Mappings
{
    public class PessoaJuridicaMap:ClassMap<PessoaJuridica>
    {
        public PessoaJuridicaMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();

            Map(x => x.RazaoSocial);
            Map(x => x.NomeFantasia);
            Map(x => x.Telefone);
            Map(x => x.CNPJ);
            Map(x => x.InscricaoEstadual);
            Map(x => x.NumeroEndereco);

            References(x => x.Endereco).Column("Endereco_Id").Cascade.SaveUpdate();
        }
    }
}
