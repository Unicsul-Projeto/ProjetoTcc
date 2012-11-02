using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class PessoaJuridica
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia  { get; set; }
        public int CNPJ { get; set; }
        public int InscricaoEstatual { get; set; }
        public int NumeroEndereco { get; set; }
        public Endereco Endereco { get; set; }
    }
}
