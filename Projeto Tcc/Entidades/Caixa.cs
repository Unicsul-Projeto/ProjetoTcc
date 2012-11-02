using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class Caixa
    {
        public int Id { get; set; }
        public CaixaDia CaixaDia { get; set; }
        public DateTime Data { get; set; }
        public float SaldoCaixa { get; set; }
    }
}
