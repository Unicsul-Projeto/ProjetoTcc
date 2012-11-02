using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual string NomeLogin { get; set; }
        public virtual string Senha { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual char Situacao { get; set; }
        public virtual IList<AcessoUsuario> AcessoUsuarios { get; set; }
    }
}
