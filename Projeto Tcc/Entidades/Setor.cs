using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Repositorio.Repositorios;

namespace Projeto_Tcc.Entidades
{
    public class Setor
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }
        public virtual IList<Cargo> Cargos { get; set; }
    }

    public interface ISetorServico
    {
        void Salvar(Setor setor);
        void Excluir(int id);
        Setor Pesquisar(int id);
        IList<Setor> PesquisarTodos();
        IList<Setor> PesquisarPorDesricao(string descricao);
    }

    public class SetorServico : ISetorServico
    {
        private readonly ISetorRepositorio _setorRepositorio;

        public SetorServico(ISetorRepositorio setorRepositorio)
        {
            _setorRepositorio = setorRepositorio;
        }

        public void Salvar(Setor setor)
        {
            _setorRepositorio.Salvar(setor);
        }

        public void Excluir(int id)
        {
            _setorRepositorio.Excluir(id);
        }

        public Setor Pesquisar(int id)
        {
            return _setorRepositorio.Pesquisar(id);
        }

        public IList<Setor> PesquisarTodos()
        {
            return _setorRepositorio.PesquisarTodos();
        }

        public IList<Setor> PesquisarPorDesricao(string descricao)
        {
            return _setorRepositorio.PesquisarPorDescricao(descricao);
        }

    }
}
