using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class CaixaDia
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public float ValorInicio { get; set; }
        public float ValorTermino { get; set; }

        public FluxoCaixa FluxoCaixa { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
