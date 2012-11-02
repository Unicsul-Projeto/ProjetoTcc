using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public float Valor { get; set; }
        public float Desconto { get; set; }

        public PessoaFisica PessoaFisica { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
