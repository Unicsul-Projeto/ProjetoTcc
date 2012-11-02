using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class ProdutoGrade
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public Grade Grade { get; set; }
    }
}
