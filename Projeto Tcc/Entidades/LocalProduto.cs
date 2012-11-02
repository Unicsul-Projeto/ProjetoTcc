using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class LocalProduto
    {
        public int Id { get; set; }
        public ProdutoGrade ProdutoGrade { get; set; }
        public Local Local { get; set; }
    }
}
