using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class MovimentoEstoqueItem
    {
        public int Id { get; set; }
        public float Quantidade { get; set; }
        public float ValorUnitario { get; set; }
        public MovimentoEstoque MovimentoEstoque { get; set; }
        public Produto Produto { get; set; }
    }
}
