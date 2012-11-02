using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class Funcionario
    {
        public virtual int Id { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual string NumCarteira { get; set; }
        public virtual DateTime DataAdmissao { get; set; }
        public virtual DateTime DataDemissao { get; set; }
    }
}
