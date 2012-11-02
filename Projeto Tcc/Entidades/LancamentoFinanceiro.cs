using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class LancamentoFinanceiro
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
