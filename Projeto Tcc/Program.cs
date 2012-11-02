using System;
using System.Windows.Forms;
using Projeto_Tcc.Repositorio.Helpers;
using Projeto_Tcc.Repositorio.Repositorios;
using Projeto_Tcc.Visualizacao;
using Projeto_Tcc.Visualizacao.Cargo;
using Projeto_Tcc.Visualizacao.Funcionario;

namespace Projeto_Tcc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new FabricaWindsor().IniciarRepositorio();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal());
            
        }
    }
}
