using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Properties;
using Projeto_Tcc.Repositorio.Helpers;
using Telerik.WinControls;

namespace Projeto_Tcc.Visualizacao.Cliente
{
    public partial class ControlarCliente : Telerik.WinControls.UI.RadForm
    {

        public ControlarCliente()
        {
            InitializeComponent();
        }

        private IPessoaFisicaServico _pessoaFisicaServico;
        private IEnderecoServico _enderecoServico;
        private ISexoServico _sexoServico;
        private IUfServico _ufServico;
        private string comando;

        private void ControlarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                var container = ContainerWindsor.InicializarContainer();

                _pessoaFisicaServico = container.Resolve<IPessoaFisicaServico>();
                _enderecoServico = container.Resolve<IEnderecoServico>();
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
                    Telefone = cliente.Telefone,
                    Celular = cliente.Celular,
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



        public class ViewModelCliente
        {
            public virtual int Id { get; set; }
            public virtual string Nome { get; set; }
            public virtual string Cpf { get; set; }
            public virtual string Rg { get; set; }
            public virtual string Telefone { get; set; }
            public virtual string Celular { get; set; }
            public virtual string NumeroEndereco { get; set; }
            public virtual string Cep { get; set; }
            public virtual string Logradouro { get; set; }
            public virtual string Bairro { get; set; }
            public virtual string Cidade { get; set; }
            public virtual string Uf { get; set; }
            public virtual string Sexo { get; set; }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var u = new Util();
            if (!u.Validar(txtNome) && !u.Validar(txtCpf) && !u.Validar(txtRg) && !u.Validar(txtTelefone) && !u.Validar(cbSexo))
            {
                MessageBox.Show("Existem campos obrigatórios não preenchidos.", "Validação", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }

            switch (comando)
            {
                case "Novo":
                    try
                    {

                        if ((_pessoaFisicaServico.PesquisarPorCpf(txtCpf.Text).Count > 0))
                        {
                            MessageBox.Show("Cpf já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        var cliente = new PessoaFisica
                        {
                            Nome = txtNome.Text,
                            Cpf = txtCpf.Text,
                            Rg = txtRg.Text,
                            Telefone = txtTelefone.Text,
                            Celular = txtCelular.Text,
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
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case "Excluir":
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                        {
                            if (MessageBox.Show("Tem certeza que deseja remover esse cadastro?", "Atenção",
                                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                _pessoaFisicaServico.Excluir(Convert.ToInt32(txtCodigo.Text));
                                MessageBox.Show("Cliente excluido com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tabControlCliente.SelectedPage = tabPageConsultar;
                                LimparCampos();

                                CarregarGrid(_pessoaFisicaServico.PesquisarTodos());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nenhum cadastro foi selecionado. \nSelecione um cadastro antes de realizar esta operação.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Alterar":
                    try
                    {
                        var cliente = _pessoaFisicaServico.Pesquisar(Convert.ToInt32(txtCodigo.Text));

                        cliente.Id = Convert.ToInt32(txtCodigo.Text);
                        cliente.Nome = txtNome.Text;
                        cliente.Cpf = txtCpf.Text;
                        cliente.Rg = txtRg.Text;
                        cliente.Telefone = txtTelefone.Text;
                        cliente.Celular = txtCelular.Text;
                        cliente.Endereco.Cep = txtCep.Text;
                        cliente.Endereco.Logradouro = txtEndereco.Text;
                        cliente.Endereco.Cidade = txtCidade.Text;
                        cliente.Endereco.Bairro = txtBairro.Text;
                        cliente.Endereco.Uf.Descricao = cbEstado.Text;
                        cliente.Sexo.Descricao = cbSexo.Text;
                        cliente.NumeroEndereco = txtNumero.Text;

                        cliente = _pessoaFisicaServico.Salvar(cliente);

                        MessageBox.Show("Cliente alterado com sucesso");

                        txtCodigo.Text = cliente.Id.ToString();
                        CarregarGrid(_pessoaFisicaServico.PesquisarTodos());

                        LimparCampos();
                        LiberarCampos();
                        tabControlCliente.SelectedPage = tabPageConsultar;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }


        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text) || !string.IsNullOrWhiteSpace(txtCpf.Text))
            {
                if (MessageBox.Show("Deseja descartar as alterações realizadas e iniciar um novo cadastro?", "Atenção", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    comando = "Novo";
                    tabControlCliente.SelectedPage = tabPageDetalhe;
                    LiberarCampos();
                    LimparCampos();
                }
            }
            else
            {
                comando = "Novo";
                tabControlCliente.SelectedPage = tabPageDetalhe;
                LiberarCampos();
                LimparCampos();
            }
        }

        public void LimparCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtCpf.Text = "";
            txtRg.Text = "";
            cbSexo.Text = "";
            txtCep.Text = "";
            txtEndereco.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cbEstado.Text = "";
        }

        public void LiberarCampos()
        {
            txtNome.Enabled = true;
            txtCpf.Enabled = true;
            txtRg.Enabled = true;
            cbSexo.Enabled = true;
            txtCep.Enabled = true;
            txtEndereco.Enabled = true;
            txtTelefone.Enabled = true;
            txtCelular.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            cbEstado.Enabled = true;
        }

        public void BloquearCampos()
        {
            txtNome.Enabled = false;
            txtCpf.Enabled = false;
            txtRg.Enabled = false;
            cbSexo.Enabled = false;
            txtCep.Enabled = false;
            txtEndereco.Enabled = false;
            txtTelefone.Enabled = false;
            txtCelular.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            cbEstado.Enabled = false;
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            comando = "Alterar";
            LiberarCampos();
            tabControlCliente.SelectedPage = tabPageDetalhe;
            try
            {
                LiberarCampos();

                var viewmodel = (ViewModelCliente)gridConsultarCliente.SelectedRows[0].DataBoundItem;
                var cliente = _pessoaFisicaServico.Pesquisar(Convert.ToInt32(viewmodel.Id));
                txtCodigo.Text = cliente.Id.ToString();
                txtNome.Text = cliente.Nome;
                txtCpf.Text = cliente.Cpf;
                txtRg.Text = cliente.Rg;
                cbSexo.Text = cliente.Sexo.Descricao;
                txtTelefone.Text = cliente.Telefone;
                txtCelular.Text = cliente.Celular;
                txtCep.Text = cliente.Endereco.Cep;
                txtEndereco.Text = cliente.Endereco.Logradouro;
                txtNumero.Text = cliente.NumeroEndereco;
                txtBairro.Text = cliente.Endereco.Bairro;
                txtCidade.Text = cliente.Endereco.Cidade;
                cbEstado.Text = cliente.Endereco.Uf.Descricao;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            comando = "Excluir";
            BloquearCampos();
            tabControlCliente.SelectedPage = tabPageDetalhe;
            try
            {
                var viewmodel = (ViewModelCliente)gridConsultarCliente.SelectedRows[0].DataBoundItem;
                var cliente = _pessoaFisicaServico.Pesquisar(Convert.ToInt32(viewmodel.Id));
                txtCodigo.Text = cliente.Id.ToString();
                txtNome.Text = cliente.Nome;
                txtCpf.Text = cliente.Cpf;
                txtRg.Text = cliente.Rg;
                cbSexo.Text = cliente.Sexo.Descricao;
                txtCep.Text = cliente.Endereco.Cep;
                txtEndereco.Text = cliente.Endereco.Logradouro;
                txtTelefone.Text = cliente.Telefone;
                txtCelular.Text = cliente.Celular;
                txtNumero.Text = cliente.NumeroEndereco;
                txtBairro.Text = cliente.Endereco.Bairro;
                txtCidade.Text = cliente.Endereco.Cidade;
                cbEstado.Text = cliente.Endereco.Uf.Descricao;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (rbNome.IsChecked)
            {
                var clientes = _pessoaFisicaServico.PesquisarPorNome(txtPesquisar.Text);
                CarregarGrid(clientes);
            }
            else if (rbCpf.IsChecked)
            {
                var clientes = _pessoaFisicaServico.PesquisarPorCpf(txtPesquisar.Text);
                CarregarGrid(clientes);
            }
            else if (rbRg.IsChecked)
            {
                var clientes = _pessoaFisicaServico.PesquisarPorRg(txtPesquisar.Text);
                CarregarGrid(clientes);
            }
        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex("[^0-9]");
            if (r.IsMatch(txtCpf.Text))
            {
                pbCpf.Image = Resources.error;
                tip.SetToolTip(pbCpf, "Somente números.");
                return;
            }
            if (txtCpf.MaxLength == txtCpf.Text.Length)
            {
                var ok = Util.ValidarCpf(txtCpf.Text);
                if (ok)
                {
                    pbCpf.Image = Resources.Ok_icon;
                    tip.SetToolTip(pbCpf, "CPF Válido!");
                }
                else
                {
                    pbCpf.Image = Resources.error;
                    tip.SetToolTip(pbCpf, "CPF inválido! Verifique.");
                }
            }
            else
            {
                pbCpf.Image = null;
                tip.SetToolTip(pbCpf, null);
            }
        }

        private void btnPesquisarCep_Click(object sender, EventArgs e)
        {
            var endereco = _enderecoServico.PesquisarPorCep(txtCep.Text);
            if (endereco == null)
            {
                MessageBox.Show(
                    "CEP não encontrado. Insira as informações do endereço e após o cadastro, o endereço será adicionado ao banco de dados.", "CEP não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtEndereco.Text = endereco.Logradouro;
                txtBairro.Text = endereco.Bairro;
                txtCidade.Text = endereco.Cidade;
                cbEstado.Text = endereco.Uf.Descricao;
            }
        }
    }


}
