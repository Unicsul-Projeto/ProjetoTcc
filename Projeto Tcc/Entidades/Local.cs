using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class Local
    {
        public int Id { get; set; }
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Prateleira Prateleira { get; set; }
    }
}
