using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Projeto_Tcc.Repositorio.Helpers
{
    public class ContainerWindsor
    {
        public static WindsorContainer InicializarContainer()
        {
            var container = new WindsorContainer();
            container.Register(AllTypes.FromThisAssembly().Pick().WithService.DefaultInterface());
            return container;
        }
        
    }
}
