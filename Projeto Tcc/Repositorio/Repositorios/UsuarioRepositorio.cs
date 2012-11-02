using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Repositorio.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
    }

    public class UsuarioRepositorio :DAO<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(SessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}