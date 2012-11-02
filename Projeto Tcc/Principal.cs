using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_Tcc
{
    public partial class Principal : Telerik.WinControls.UI.RadForm
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void radRibbonBarGroup1_Click(object sender, EventArgs e)
        {
            Visualizacao.Cliente.ControlarCliente Frm1 = new Visualizacao.Cliente.ControlarCliente();
            Frm1.MdiParent = this;
            Frm1.Show();

        }

     

        private void radMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem9_Click(object sender, EventArgs e)
        {
            Visualizacao.ControleCep cep = new Visualizacao.ControleCep();
            cep.MdiParent = this;
            cep.Show();
        }

        private void radMenuItem1_Click_1(object sender, EventArgs e)
        {
            Visualizacao.Cliente.ControlarCliente Cliente = new Visualizacao.Cliente.ControlarCliente();
            Cliente.MdiParent = this;
            Cliente.Show();
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            Visualizacao.Fornecedor.ControlarFornecedor Fornecedor = new Visualizacao.Fornecedor.ControlarFornecedor();
            Fornecedor.MdiParent = this;
            Fornecedor.Show();

        }

        private void radMenuItem4_Click_1(object sender, EventArgs e)
        {
            Visualizacao.Funcionario.ControlarFuncionari Funcionario = new Visualizacao.Funcionario.ControlarFuncionari();
            Funcionario.MdiParent = this;
            Funcionario.Show();
        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
            Visualizacao.Produto.Produto Produto = new Visualizacao.Produto.Produto();
            Produto.MdiParent = this;
            Produto.Show();
        }

        private void radMenuItem6_Click_1(object sender, EventArgs e)
        {
            Visualizacao.TipoProduto.TipoProduto TipoProduto = new Visualizacao.TipoProduto.TipoProduto();
            TipoProduto.MdiParent = this;
            TipoProduto.Show();
        }

        private void radMenuItem7_Click(object sender, EventArgs e)
        {
            Visualizacao.Setor.ControlarSeto ContorlarSetor = new Visualizacao.Setor.ControlarSeto();
            ContorlarSetor.MdiParent = this;
            ContorlarSetor.Show();
        }

        private void radMenuItem8_Click(object sender, EventArgs e)
        {
            Visualizacao.Cargo.Carg Cargo = new Visualizacao.Cargo.Carg();
            Cargo.MdiParent = this;
            Cargo.Show();
        }

        private void radMenu1_Click(object sender, EventArgs e)
        {
           
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
           
          
        }

        private void radMenuItem11_Click(object sender, EventArgs e)
        {

            var teste = new Visualizacao.Venda {MdiParent = this};
            teste.Show();

        }
    }
}
