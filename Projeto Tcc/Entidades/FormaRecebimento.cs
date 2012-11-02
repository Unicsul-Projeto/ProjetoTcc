using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class FormaRecebimento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeParcela { get; set; }
        public Cartao Cartao { get; set; }
    }
}
