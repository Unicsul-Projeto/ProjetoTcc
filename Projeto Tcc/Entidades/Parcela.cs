using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class Parcela
    {
        public int Id { get; set; }
        public DateTime DataVencimento { get; set; }
        public float Valor { get; set; }
        public string Obvervacao { get; set; }

    }
}
