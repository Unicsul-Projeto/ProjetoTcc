using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Projeto_Tcc.Entidades
{
    public class AcessoUsuario
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Acesso Acesso { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
