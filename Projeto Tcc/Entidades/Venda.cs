using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Repositorio.Repositorios;

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

    public interface IVendaServico
    {
        Venda Salvar(Venda venda);
        void Excluir(int id);
        Venda Pesquisar(int id);
        IList<Venda> PesquisarTodos();
    }

    public class VendaServico:IVendaServico
    {
        private readonly IVendaRepositorio _vendaRepositorio;
        public VendaServico(IVendaRepositorio vendaRepositorio)
        {
            _vendaRepositorio = vendaRepositorio;
        }

        public Venda Salvar(Venda venda)
        {
            _vendaRepositorio.Salvar(venda);
            return _vendaRepositorio.Pesquisar(venda.Id);
        }

        public void Excluir(int id)
        {
            _vendaRepositorio.Excluir(id);
        }

        public Venda Pesquisar(int id)
        {
            return _vendaRepositorio.Pesquisar(id);
        }

        public IList<Venda> PesquisarTodos()
        {
            return _vendaRepositorio.PesquisarTodos();
        }
    }
}
