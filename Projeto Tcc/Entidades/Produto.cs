using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public float ValorCusto { get; set; }
        public float ValorVenda { get; set; }
        public char Situacao { get; set; }
        public int QuantidadeMinima { get; set; }
        public int Medida { get; set; }
        public DateTime DataCadastro { get; set; }

        public Categoria Categoria { get; set; }
        public Comissao Comissao { get; set; }
        public Preco Preco { get; set; }
        public Marca Marca { get; set; }
    }
}
