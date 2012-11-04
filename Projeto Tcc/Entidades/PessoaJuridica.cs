using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Repositorio.Repositorios;

namespace Projeto_Tcc.Entidades
{
    public class PessoaJuridica
    {
        public virtual int Id { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string NomeFantasia { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string CNPJ { get; set; }
        public virtual string InscricaoEstadual { get; set; }
        public virtual string NumeroEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }
    }

    public interface IPessoaJuridicaServico
    {
        PessoaJuridica Salvar(PessoaJuridica pessoaJuridica);
        void Excluir(int id);
        PessoaJuridica Pesquisar(int id);
        IList<PessoaJuridica> PesquisarTodos();
        IList<PessoaJuridica> PesquisarPorNomeFantasia(string nomeFatasia);
        IList<PessoaJuridica> PesquisarPorRazaoSocial(string razaoSocial);
        IList<PessoaJuridica> PesquisarPorCnpj(string cnpj);
        
    }

    public class PessoaJuridicaServico:IPessoaJuridicaServico
    {
        private readonly IPessoaJuridicaRepositorio _pessoaJuridicaRepositorio;

        public PessoaJuridicaServico(IPessoaJuridicaRepositorio pessoaJuridicaRepositorio)
        {
            _pessoaJuridicaRepositorio = pessoaJuridicaRepositorio;
        }

        public PessoaJuridica Salvar(PessoaJuridica pessoaJuridica)
        {
            _pessoaJuridicaRepositorio.Salvar(pessoaJuridica);
            return _pessoaJuridicaRepositorio.Pesquisar(pessoaJuridica.Id);
        }

        public void Excluir(int id)
        {
            _pessoaJuridicaRepositorio.Excluir(id);
        }

        public PessoaJuridica Pesquisar(int id)
        {
            return _pessoaJuridicaRepositorio.Pesquisar(id);
        }

        public IList<PessoaJuridica> PesquisarTodos()
        {
            return _pessoaJuridicaRepositorio.PesquisarTodos();
        }

        public IList<PessoaJuridica> PesquisarPorNomeFantasia(string nomeFatasia)
        {
            return _pessoaJuridicaRepositorio.PesquisarPorNomeFantasia(nomeFatasia);
        }

        public IList<PessoaJuridica> PesquisarPorRazaoSocial(string razaoSocial)
        {
            return _pessoaJuridicaRepositorio.PesquisarPorRazaoSocial(razaoSocial);
        }

        public IList<PessoaJuridica> PesquisarPorCnpj(string cnpj)
        {
            return _pessoaJuridicaRepositorio.PesquisarPorCnpj(cnpj);
        }
    }
}
