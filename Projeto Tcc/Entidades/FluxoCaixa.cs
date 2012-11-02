using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class FluxoCaixa
    {
        public int Id { get; set; }
        public char TipoOperacao { get; set; }
        public float Valor { get; set; }
        public DateTime Data { get; set; }
        public float Saldo { get; set; }
        //public Movimentacao Movimentacao { get; set; }
        public Lancamento Lancamento { get; set; }
    }
}
