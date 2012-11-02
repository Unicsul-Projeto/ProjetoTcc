using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Repositorio.Repositorios;

namespace Projeto_Tcc.Entidades
{
    public class Uf
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }
    }

    public interface IUfServico
    {
        Uf Salvar(Uf uf);
        void Excluir(int id);
        Uf Pesquisar(int id);
        IList<Uf> PesquisarTodos();
    }

    public class UfServico : IUfServico
    {
        private readonly IUfRepositorio _ufRepositorio;
        public UfServico(IUfRepositorio ufRepositorio)
        {
            _ufRepositorio = ufRepositorio;
        }

        public Uf Salvar(Uf uf)
        {
            _ufRepositorio.Salvar(uf);
            return _ufRepositorio.Pesquisar(uf.Id);
        }

        public void Excluir(int id)
        {
            _ufRepositorio.Excluir(id);
        }

        public Uf Pesquisar(int id)
        {
            return _ufRepositorio.Pesquisar(id);
        }

        public IList<Uf> PesquisarTodos()
        {
            return _ufRepositorio.PesquisarTodos();
        }
    }
}
