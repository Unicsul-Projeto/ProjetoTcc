using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Repositorio.Repositorios;

namespace Projeto_Tcc.Entidades
{
    public class Funcionario
    {
        public virtual int Id { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual string NumCarteira { get; set; }
        public virtual DateTime DataAdmissao { get; set; }
        public virtual DateTime DataDemissao { get; set; }
    }

    public interface IFuncionarioServico
    {
        Funcionario Salvar(Funcionario funcionario);
        void Excluir(int id);
        Funcionario Pesquisar(int id);
        IList<Funcionario> PesquisarTodos();
    }

    public class FuncionarioServico : IFuncionarioServico
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public FuncionarioServico(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        public Funcionario Salvar(Funcionario funcionario)
        {
            _funcionarioRepositorio.Salvar(funcionario);
            return _funcionarioRepositorio.Pesquisar(funcionario.Id);
        }

        public void Excluir(int id)
        {
            _funcionarioRepositorio.Excluir(id);
        }

        public Funcionario Pesquisar(int id)
        {
            return _funcionarioRepositorio.Pesquisar(id);
        }

        public IList<Funcionario> PesquisarTodos()
        {
            return _funcionarioRepositorio.PesquisarTodos();
        }
    }
}
