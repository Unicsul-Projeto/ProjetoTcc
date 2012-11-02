using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Repositorio.Repositorios
{
    public interface IFuncionarioRepositorio:IRepositorio<Funcionario>
    {
        
    }
    public class FuncionarioRepositorio :DAO<Funcionario>, IFuncionarioRepositorio
    {
        public FuncionarioRepositorio(SessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}
