using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class Preco
    {
        public int Id { get; set; }
        public Promocao Promocao { get; set; }
        public float Valor { get; set; }
    }
}
