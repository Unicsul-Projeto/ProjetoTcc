using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto_Tcc.Repositorio.Repositorios
{
    public interface IRepositorio<T>
    {
        void Salvar(T entity);
        T Pesquisar(int id);
        IList<T> PesquisarTodos();
        void Excluir(int id);
        void Excluir(T entity);
    }
}
