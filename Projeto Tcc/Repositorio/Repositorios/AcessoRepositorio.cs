using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Repositorio.Repositorios
{
    public interface IAcessoRepositorio:IRepositorio<Acesso>
    {
    }
    public class AcessoRepositorio:DAO<Acesso>,IAcessoRepositorio
    {
        public AcessoRepositorio(SessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}
