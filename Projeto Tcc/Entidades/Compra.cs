using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class Compra
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public float ValorTotal { get; set; }
        public float Desconto { get; set; }

        public PessoaJuridica PessoaJuridica { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
