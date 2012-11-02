using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Repositorio.Repositorios
{
    public interface IAcessoUsuarioRepositorio:IRepositorio<AcessoUsuario>
    {
    }
    public class AcessoUsuarioRepositorio:DAO<AcessoUsuario>,IAcessoUsuarioRepositorio
    {
        public AcessoUsuarioRepositorio(SessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}
