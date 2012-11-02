using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Projeto_Tcc.Entidades;

namespace Projeto_Tcc.Repositorio.Mappings
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();
            Map(x => x.NomeLogin);
            Map(x => x.Senha);
            Map(x => x.DataCadastro);
            Map(x => x.Situacao);

            //HasMany(x => x.AcessoUsuarios);

            //HasOne(x => x.Funcionario);
        }
    }
}
