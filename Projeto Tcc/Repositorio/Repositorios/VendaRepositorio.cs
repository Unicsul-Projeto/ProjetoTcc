using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Repositorio.Repositorios
{
    public interface IVendaRepositorio:IRepositorio<Venda>{}

    public class VendaRepositorio:DAO<Venda>,IVendaRepositorio
    {
        public VendaRepositorio(SessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}
