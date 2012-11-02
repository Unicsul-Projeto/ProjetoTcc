using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Repositorio.Repositorios;

namespace Projeto_Tcc.Entidades
{
    public class Endereco
    {
        public virtual int Id { get; set; }
        public virtual string Cep { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual Uf Uf { get; set; }
        
    }

    public interface IEnderecoServico
    {
        void Salvar(Endereco endereco);
        void Excluir(int id);
        Endereco Pesquisar(int id);
        IList<Endereco> PesquisarTodos();
    }

    public class EnderecoServico : IEnderecoServico
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        public EnderecoServico(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        public void Salvar(Endereco endereco)
        {
            _enderecoRepositorio.Salvar(endereco);
        }

        public void Excluir(int id)
        {
            _enderecoRepositorio.Excluir(id);
        }

        public Endereco Pesquisar(int id)
        {
            return _enderecoRepositorio.Pesquisar(id);
        }

        public IList<Endereco> PesquisarTodos()
        {
            return _enderecoRepositorio.PesquisarTodos();
        }
    }
        
}
