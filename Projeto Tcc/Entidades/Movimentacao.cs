using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public float ValorProduto { get; set; }
        public float ValorDesconto { get; set; }
        public float Quantidade { get; set; }

        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
        public Compra Compra { get; set; }
        //public Troca Troca { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
    }
}
