using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Repositorio.Repositorios
{
    public interface IUfRepositorio:IRepositorio<Uf>
    {
    }

    public class UfRepositorio :DAO<Uf>,IUfRepositorio
    {
        public UfRepositorio(SessionProvider sessionProvider) : base(sessionProvider)
        {
        }


    }
}
