using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Repositorio.Repositorios;

namespace Projeto_Tcc.Repositorio.Helpers
{
    public class FabricaWindsor
    {
        public void IniciarRepositorio()
        {
            var container = ContainerWindsor.InicializarContainer();
            container.Resolve<IPessoaFisicaRepositorio>();
            container.Resolve<IAcessoRepositorio>();
            container.Resolve<IAcessoUsuarioRepositorio>();
            container.Resolve<ICargoRepositorio>();
            container.Resolve<IEnderecoRepositorio>();
            container.Resolve<ISetorRepositorio>();
            container.Resolve<ISexoRepositorio>();
            container.Resolve<IUfRepositorio>();
            container.Resolve<IUsuarioRepositorio>();
        }
    }
}
