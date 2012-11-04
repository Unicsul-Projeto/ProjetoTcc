using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;
using Telerik.WinControls;

namespace Projeto_Tcc.Visualizacao
{
    public partial class ControlarVenda : Telerik.WinControls.UI.RadForm
    {
        public ControlarVenda()
        {
            InitializeComponent();
        }

        private IFuncionarioServico _funcionarioServico;
        private IVendaServico _vendaServico;
        private Entidades.Funcionario _vendedor;
        private Venda _venda; 
        private void Venda_Load(object sender, EventArgs e)
        {
            var container = ContainerWindsor.InicializarContainer();
            _funcionarioServico = container.Resolve<IFuncionarioServico>();
            _vendaServico = container.Resolve<IVendaServico>();
            


            lblData.Text = DateTime.Today.ToShortDateString();
            //lblCodVenda.Text = 
        }

        private void btnVendedor_Click(object sender, EventArgs e)
        {
            _vendedor = _funcionarioServico.Pesquisar(Convert.ToInt32(txtCodVendedor.Text));
            lblNomeVendedor.Text = _vendedor.PessoaFisica.Nome;
        }
    }
}
