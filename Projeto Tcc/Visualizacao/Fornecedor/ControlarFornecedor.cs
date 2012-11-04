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

namespace Projeto_Tcc.Visualizacao.Fornecedor
{
    public partial class ControlarFornecedor : Telerik.WinControls.UI.RadForm
    {
        public ControlarFornecedor()
        {
            InitializeComponent();
        }

        private IPessoaJuridicaServico _pessoaJuridicaServico;
        private IUfServico _ufServico;
        private IEnderecoServico _enderecoServico;
        private string comando;

        private void ControlarFornecedor_Load(object sender, EventArgs e)
        {
            try
            {
                var container = ContainerWindsor.InicializarContainer();

                _pessoaJuridicaServico = container.Resolve<IPessoaJuridicaServico>();
                _ufServico = container.Resolve<IUfServico>();
                _enderecoServico = container.Resolve<IEnderecoServico>();

                var fornecedores = _pessoaJuridicaServico.PesquisarTodos();
                CarregarGrid(fornecedores);
                CarregarComboEstado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void CarregarGrid(IList<PessoaJuridica> fornecedores)
        {
            var lista = new List<ViewModelFornecedor>();

            foreach (var fornecedor in fornecedores)
            {
                var vm = new ViewModelFornecedor
                             {
                                 Id = fornecedor.Id,
                                 RazaoSocial = fornecedor.RazaoSocial,
                                 NomeFantasia = fornecedor.NomeFantasia,
                                 Cnpj = fornecedor.CNPJ,
                                 InscricaoEstadual = fornecedor.InscricaoEstadual,
                                 Telefone = fornecedor.Telefone,
                                 Cep = fornecedor.Endereco.Cep,
                                 Logradouro = fornecedor.Endereco.Logradouro,
                                 NumeroEndereco = fornecedor.NumeroEndereco,
                                 Bairro = fornecedor.Endereco.Bairro,
                                 Cidade = fornecedor.Endereco.Cidade,
                                 Uf = fornecedor.Endereco.Uf.Descricao
                             };
                lista.Add(vm);

            }

            gridFornecedor.DataSource = lista;
        }

        public class ViewModelFornecedor
        {
            public virtual int Id { get; set; }
            public virtual string RazaoSocial { get; set; }
            public virtual string NomeFantasia { get; set; }
            public virtual string Cnpj { get; set; }
            public virtual string InscricaoEstadual { get; set; }
            public virtual string Telefone { get; set; }
            public virtual string NumeroEndereco { get; set; }
            public virtual string Cep { get; set; }
            public virtual string Logradouro { get; set; }
            public virtual string Bairro { get; set; }
            public virtual string Cidade { get; set; }
            public virtual string Uf { get; set; }

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (rbRazaoSocial.IsChecked)
            {
                var fornecedores = _pessoaJuridicaServico.PesquisarPorRazaoSocial(txtPesquisar.Text);
                CarregarGrid(fornecedores);
            }
            else if (rbNomeFantasia.IsChecked)
            {
                var fornecedores = _pessoaJuridicaServico.PesquisarPorNomeFantasia(txtPesquisar.Text);
                CarregarGrid(fornecedores);
            }
            else if (rbCnpj.IsChecked)
            {
                var fornecedores = _pessoaJuridicaServico.PesquisarPorCnpj(txtPesquisar.Text);
                CarregarGrid(fornecedores);
            }
        }

        private void txtCnpj_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex("[^0-9]");
            if (r.IsMatch(txtCnpj.Text))
            {
                pbCnpj.Image = Resources.error;
                tip.SetToolTip(pbCnpj, "Somente números.");
                return;
            }
            if (txtCnpj.MaxLength == txtCnpj.Text.Length)
            {
                var ok = Util.ValidarCnpj(txtCnpj.Text);
                if (ok)
                {
                    pbCnpj.Image = Resources.Ok_icon;
                    tip.SetToolTip(pbCnpj, "CPF Válido!");
                }
                else
                {
                    pbCnpj.Image = Resources.error;
                    tip.SetToolTip(pbCnpj, "CPF inválido! Verifique.");
                }
            }
            else
            {
                pbCnpj.Image = null;
                tip.SetToolTip(pbCnpj, null);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            comando = "Alterar";

            TabControlFornecedor.SelectedPage = tabDetalhe;

            try
            {
                var viewmodel = (ViewModelFornecedor)gridFornecedor.SelectedRows[0].DataBoundItem;
                var fornecedor = _pessoaJuridicaServico.Pesquisar(Convert.ToInt32(viewmodel.Id));

                txtCodigo.Text = fornecedor.Id.ToString();
                txtRazaoSocial.Text = fornecedor.RazaoSocial;
                txtNomeFantasia.Text = fornecedor.NomeFantasia;
                txtCnpj.Text = fornecedor.CNPJ;
                txtInscEstadual.Text = fornecedor.InscricaoEstadual;
                txtTelefone.Text = fornecedor.Telefone;
                txtCep.Text = fornecedor.Endereco.Cep;
                txtEndereco.Text = fornecedor.Endereco.Logradouro;
                txtCidade.Text = fornecedor.Endereco.Cidade;
                txtBairro.Text = fornecedor.Endereco.Bairro;
                cbEstado.Text = fornecedor.Endereco.Uf.Descricao;
                txtNumero.Text = fornecedor.NumeroEndereco;      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            comando = "Excluir";

            TabControlFornecedor.SelectedPage = tabDetalhe;

            try
            {
                var viewmodel = (ViewModelFornecedor)gridFornecedor.SelectedRows[0].DataBoundItem;
                var fornecedor = _pessoaJuridicaServico.Pesquisar(Convert.ToInt32(viewmodel.Id));

                txtCodigo.Text = fornecedor.Id.ToString();
                txtRazaoSocial.Text = fornecedor.RazaoSocial;
                txtNomeFantasia.Text = fornecedor.NomeFantasia;
                txtCnpj.Text = fornecedor.CNPJ;
                txtInscEstadual.Text = fornecedor.InscricaoEstadual;
                txtTelefone.Text = fornecedor.Telefone;
                txtCep.Text = fornecedor.Endereco.Cep;
                txtEndereco.Text = fornecedor.Endereco.Logradouro;
                txtCidade.Text = fornecedor.Endereco.Cidade;
                txtBairro.Text = fornecedor.Endereco.Bairro;
                cbEstado.Text = fornecedor.Endereco.Uf.Descricao;
                txtNumero.Text = fornecedor.NumeroEndereco;      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRazaoSocial.Text) || !string.IsNullOrWhiteSpace(txtCnpj.Text))
            {
                if (MessageBox.Show("Deseja descartar as alterações realizadas e iniciar um novo cadastro?", "Atenção", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    comando = "Novo";
                    TabControlFornecedor.SelectedPage = tabDetalhe;
                    LiberarCampos();
                    LimparCampos();
                }
            }
            else
            {
                comando = "Novo";
                TabControlFornecedor.SelectedPage = tabDetalhe;
                LiberarCampos();
                LimparCampos();
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            switch (comando)
            {
                case "Novo":
                    try
                    {

                        if ((_pessoaJuridicaServico.PesquisarPorCnpj(txtCnpj.Text).Count > 0))
                        {
                            MessageBox.Show("Cnpj já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        var fornecedor = new PessoaJuridica
                                             {
                                                 RazaoSocial = txtRazaoSocial.Text,
                                                 NomeFantasia = txtNomeFantasia.Text,
                                                 Telefone = txtTelefone.Text,
                                                 CNPJ = txtCnpj.Text,
                                                 InscricaoEstadual = txtInscEstadual.Text,
                                                 Endereco = new Endereco
                                                 {
                                                     Cep = txtCep.Text,
                                                     Logradouro = txtEndereco.Text,
                                                     Cidade = txtCidade.Text,
                                                     Bairro = txtBairro.Text,
                                                     Uf = new Uf
                                                     {
                                                         Descricao = cbEstado.SelectedText
                                                     }
                                                 },
                                                 NumeroEndereco = txtNumero.Text
                                             };



                        fornecedor = _pessoaJuridicaServico.Salvar(fornecedor);

                        MessageBox.Show("Fornecedor cadastrado com sucesso");

                        txtCodigo.Text = fornecedor.Id.ToString();
                        CarregarGrid(_pessoaJuridicaServico.PesquisarTodos());

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
                                _pessoaJuridicaServico.Excluir(Convert.ToInt32(txtCodigo.Text));
                                MessageBox.Show("Forncedor excluido com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                TabControlFornecedor.SelectedPage = tabConsultar;
                                LimparCampos();

                                CarregarGrid(_pessoaJuridicaServico.PesquisarTodos());
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
                        var fornecedor = _pessoaJuridicaServico.Pesquisar(Convert.ToInt32(txtCodigo.Text));

                        fornecedor.Id = Convert.ToInt32(txtCodigo.Text);
                        fornecedor.RazaoSocial = txtRazaoSocial.Text;
                        fornecedor.NomeFantasia = txtNomeFantasia.Text;
                        fornecedor.CNPJ = txtCnpj.Text;
                        fornecedor.InscricaoEstadual = txtInscEstadual.Text;
                        fornecedor.Telefone = txtTelefone.Text;
                        fornecedor.Endereco.Cep = txtCep.Text;
                        fornecedor.Endereco.Logradouro = txtEndereco.Text;
                        fornecedor.Endereco.Cidade = txtCidade.Text;
                        fornecedor.Endereco.Bairro = txtBairro.Text;
                        fornecedor.Endereco.Uf.Descricao = cbEstado.Text;
                        fornecedor.NumeroEndereco = txtNumero.Text;

                        fornecedor = _pessoaJuridicaServico.Salvar(fornecedor);

                        MessageBox.Show("Forncedor alterado com sucesso");

                        txtCodigo.Text = fornecedor.Id.ToString();
                        CarregarGrid(_pessoaJuridicaServico.PesquisarTodos());

                        LimparCampos();
                        LiberarCampos();
                        TabControlFornecedor.SelectedPage = tabConsultar;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        public void LiberarCampos()
        {
             txtRazaoSocial.Enabled = true;
             txtNomeFantasia.Enabled = true;
             txtCnpj.Enabled = true;
             txtInscEstadual.Enabled = true;
             txtTelefone.Enabled = true;
             txtCep.Enabled = true;
             txtEndereco.Enabled = true;
             txtCidade.Enabled = true;
             txtBairro.Enabled = true;
             cbEstado.Enabled = true;
             txtNumero.Enabled = true;
        }

        public void BloquearCampos()
        {
            txtRazaoSocial.Enabled = false;
            txtNomeFantasia.Enabled = false;
            txtCnpj.Enabled = false;
            txtInscEstadual.Enabled = false;
            txtTelefone.Enabled = false;
            txtCep.Enabled = false;
            txtEndereco.Enabled = false;
            txtCidade.Enabled = false;
            txtBairro.Enabled = false;
            cbEstado.Enabled = false;
            txtNumero.Enabled = false;
        }

        public void LimparCampos()
        {
            txtCodigo.Clear();
            txtRazaoSocial.Clear();
            txtNomeFantasia.Clear();
            txtCnpj.Clear();
            txtInscEstadual.Clear();
            txtTelefone.Clear();
            txtCep.Clear();
            txtEndereco.Clear();
            txtCidade.Clear();
            txtBairro.Clear();
            cbEstado.Text = "";
            txtNumero.Clear();
        }
    }
}
