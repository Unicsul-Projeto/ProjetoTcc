using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Repositorio.Repositorios;

namespace Projeto_Tcc.Entidades
{
    public class Sexo
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }
    }

    public interface ISexoServico
    {
        void Salvar(Sexo sexo);
        void Excluir(int id);
        Sexo Pesquisar(int id);
        IList<Sexo> PesquisarTodos();
    }

    public class SexoServico : ISexoServico
    {
        private readonly ISexoRepositorio _sexoRepositorio;
        public SexoServico(ISexoRepositorio enderecoRepositorio)
        {
            _sexoRepositorio = enderecoRepositorio;
        }

        public void Salvar(Sexo sexo)
        {
            _sexoRepositorio.Salvar(sexo);
        }

        public void Excluir(int id)
        {
            _sexoRepositorio.Excluir(id);
        }

        public Sexo Pesquisar(int id)
        {
            return _sexoRepositorio.Pesquisar(id);
        }

        public IList<Sexo> PesquisarTodos()
        {
            return _sexoRepositorio.PesquisarTodos();
        }
    }
}
