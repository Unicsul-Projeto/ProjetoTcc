using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class Prateleira
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeLinha  { get; set; }
        public int QuantidadeColuna { get; set; }
    }
}
