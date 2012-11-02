using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Visualizacao
{
    public partial class ControlarCliente : Form
    {
        public ControlarCliente()
        {
            InitializeComponent();
        }

        private IPessoaFisicaServico _pessoaFisicaServico;
        private ISexoServico _sexoServico;
        private IUfServico _ufServico;

        private void Consultar_Cliente_Load(object sender, EventArgs e)
        {
            try
            {
                var container = ContainerWindsor.InicializarContainer();

                _pessoaFisicaServico = container.Resolve<IPessoaFisicaServico>();
                _sexoServico = container.Resolve<ISexoServico>();
                _ufServico = container.Resolve<IUfServico>();


                var clientes = _pessoaFisicaServico.PesquisarTodos();
                CarregarGrid(clientes);
                CarregarComboSexo();
                CarregarComboEstado();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CarregarComboEstado()
        {
            var estados = _ufServico.PesquisarTodos();
            foreach (var estado in estados)
            {
                cbEstado.Items.Add(estado.Descricao);
            }
        }

        public void CarregarComboSexo()
        {
            var sexos = _sexoServico.PesquisarTodos();
            foreach (var sexo in sexos)
            {
                cbSexo.Items.Add(sexo.Descricao);
            }
        }

        private void gridConsultarCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(gridConsultarCliente.Rows[e.RowIndex].Cells["Id"].Value);
                var cliente = _pessoaFisicaServico.Pesquisar(id);

                txtCodigo.Text = cliente.Id.ToString();
                txtNome.Text = cliente.Nome;
                txtCpf.Text = cliente.Cpf;
                txtRg.Text = cliente.Rg;
                txtEndereco.Text = cliente.Endereco.Logradouro;
                txtNumero.Text = cliente.NumeroEndereco;
                txtCep.Text = cliente.Endereco.Cep;
                txtBairro.Text = cliente.Endereco.Bairro;
                txtCidade.Text = cliente.Endereco.Cidade;
                cbEstado.Text = cliente.Endereco.Uf.Descricao;
                cbSexo.Text = cliente.Sexo.Descricao;

                tabControlCliente.SelectTab(tabPageDetalhe);
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
                        Uf = new Uf
                                 {
                                     //Id = cbEstado.SelectedIndex,
                                     Descricao = cbEstado.SelectedText
                                 }
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
                CarregarGrid(_pessoaFisicaServico.PesquisarTodos());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CarregarGrid(IList<PessoaFisica> clientes)
        {
            var lista = new List<ViewModelCliente>();

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
                    Uf = cliente.Endereco.Uf.Descricao,
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

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (rbNome.Checked)
            {
                var clientes = _pessoaFisicaServico.PesquisarPorNome(txtPesquisa.Text);
                CarregarGrid(clientes);
            }
            else if (rbCpf.Checked)
            {
                var clientes = _pessoaFisicaServico.PesquisarPorCpf(txtPesquisa.Text);
                CarregarGrid(clientes);
            }
            else if (rbRg.Checked)
            {
                var clientes = _pessoaFisicaServico.PesquisarPorRg(txtPesquisa.Text);
                CarregarGrid(clientes);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (MessageBox.Show("Tem certeza que deseja remover esse cadastro?", "Atenção",
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _pessoaFisicaServico.Excluir(Convert.ToInt32(txtCodigo.Text));
                        MessageBox.Show("Cliente excluido com sucesso","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        CarregarGrid(_pessoaFisicaServico.PesquisarTodos());
                    }
                }
                else
                {
                    throw new Exception("Nenhum cadastro foi selecionado. \nSelecione um cadastro antes de realizar esta operação.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
        }

        private void tabPageConsultar_Click(object sender, EventArgs e)
        {

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
