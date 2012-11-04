using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Repositorios;

namespace Projeto_Tcc
{
    public class PessoaFisica
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Rg { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string Celular { get; set; }
        public virtual string NumeroEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Sexo Sexo { get; set; }
    }

    public interface IPessoaFisicaServico
    {
        PessoaFisica Salvar(PessoaFisica pessoaFisica);
        void Excluir(int id);
        PessoaFisica Pesquisar(int id);
        IList<PessoaFisica> PesquisarTodos();
        IList<PessoaFisica> PesquisarPorNome(string nome);
        IList<PessoaFisica> PesquisarPorCpf(string cpf);
        IList<PessoaFisica> PesquisarPorRg(string rg);
    }

    public class PessoaFisicaServico:IPessoaFisicaServico
    {
        private readonly IPessoaFisicaRepositorio _pessoaFisicaRepositorio;
        public PessoaFisicaServico(IPessoaFisicaRepositorio pessoaFisicaRepositorio)
        {
            _pessoaFisicaRepositorio = pessoaFisicaRepositorio;
        }

        public PessoaFisica Salvar(PessoaFisica pessoaFisica)
        {
            _pessoaFisicaRepositorio.Salvar(pessoaFisica);
            return _pessoaFisicaRepositorio.Pesquisar(pessoaFisica.Id);
        }

        public void Excluir(int id)
        {
            _pessoaFisicaRepositorio.Excluir(id);
        }
        
        public PessoaFisica Pesquisar(int id)
        {
            return _pessoaFisicaRepositorio.Pesquisar(id);
        }

        public IList<PessoaFisica> PesquisarTodos()
        {
            return _pessoaFisicaRepositorio.PesquisarTodos();
        }

        public IList<PessoaFisica> PesquisarPorNome(string nome)
        {
            return _pessoaFisicaRepositorio.PesquisarPorNome(nome);
        }
        public IList<PessoaFisica> PesquisarPorCpf(string cpf)
        {
            return _pessoaFisicaRepositorio.PesquisarPorCpf(cpf);
        }
        public IList<PessoaFisica> PesquisarPorRg(string rg)
        {
            return _pessoaFisicaRepositorio.PesquisarPorRg(rg);
        }
    }
}
