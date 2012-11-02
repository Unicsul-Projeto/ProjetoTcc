using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc
{
    public partial class Consultar_Cliente : Form
    {
        public Consultar_Cliente()
        {
            InitializeComponent();
        }

        private IPessoaFisicaServico _pessoaFisicaServico;
        private ISexoServico _sexoServico;
        private IEnderecoServico _enderecoServico;

        private void Consultar_Cliente_Load(object sender, EventArgs e)
        {
            try
            {
                var container = ContainerWindsor.InicializarContainer();

                _pessoaFisicaServico = container.Resolve<IPessoaFisicaServico>();
                _sexoServico = container.Resolve<ISexoServico>();
                _enderecoServico = container.Resolve<IEnderecoServico>();

                CarregarGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridConsultarCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = new PessoaFisica
                {
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text,
                    Rg = txtRg.Text,
                    Endereco = new Endereco
                    {
                        Cep = txtCep.Text,
                        Logradouro = txtEndereco.Text,
                        Cidade = txtCidade.Text,
                        Bairro = txtBairro.Text,
                        Uf = cbEstado.Text
                    },
                    Sexo = new Sexo
                    {
                        Descricao = cbSexo.Text
                    }
                    ,
                    NumeroEndereco = txtNumero.Text

                };

                cliente = _pessoaFisicaServico.Salvar(cliente);
                
                MessageBox.Show("Cliente cadastrado com sucesso");

                txtCodigo.Text = cliente.Id.ToString();
                CarregarGrid();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CarregarGrid()
        {
            var lista = new List<ViewModelCliente>();
            var clientes = _pessoaFisicaServico.PesquisarTodos();

            foreach (var cliente in clientes)
            {
                var vm = new ViewModelCliente
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Cpf = cliente.Cpf,
                    Rg = cliente.Rg,
                    Cep = cliente.Endereco.Cep,
                    Logradouro = cliente.Endereco.Logradouro,
                    Bairro = cliente.Endereco.Bairro,
                    Cidade = cliente.Endereco.Cidade,
                    Uf = cliente.Endereco.Uf,
                    NumeroEndereco = cliente.NumeroEndereco,
                    Sexo = cliente.Sexo.Descricao

                };
                lista.Add(vm);

            }

            gridConsultarCliente.DataSource = lista;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tabControlCliente.SelectTab(tabPageDetalhe);
        }
    }

    public class ViewModelCliente
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Rg { get; set; }
        public virtual string NumeroEndereco { get; set; }
        public virtual string Cep { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Uf { get; set; }
        public virtual string Sexo { get; set; }
    }
}
