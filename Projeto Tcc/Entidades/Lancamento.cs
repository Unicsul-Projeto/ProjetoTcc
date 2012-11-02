using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class Lancamento
    {
        public int Id { get; set; }
        public string Desconto { get; set; }
        public string Tipo { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
    }
}
