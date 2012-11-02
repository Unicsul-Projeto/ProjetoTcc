using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Repositorio.Repositorios
{
    public interface IEnderecoRepositorio : IRepositorio<Endereco>
    {
    }

    public class EnderecoRepositorio :DAO<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(SessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}
