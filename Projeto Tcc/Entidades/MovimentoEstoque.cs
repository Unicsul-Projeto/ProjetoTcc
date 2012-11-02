using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class MovimentoEstoque
    {
        public int Id { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
        public DateTime MovimentacaoEstoqueData { get; set; }
        public char MovimentacaoEstoqueTipo { get; set; }
    }
}
