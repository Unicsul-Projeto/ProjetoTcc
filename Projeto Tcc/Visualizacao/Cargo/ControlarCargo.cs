using System;
using System.Linq;
using System.Windows.Forms;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Visualizacao.Cargo
{
    public partial class ControlarCargo : Form
    {
        public ControlarCargo()
        {
            InitializeComponent();
        }

        private ICargoServico _cargoServico;
        private ISetorServico _setorServico;

        private void ControlarCargo_Load(object sender, EventArgs e)
        {
            var container = ContainerWindsor.InicializarContainer();

            _setorServico = container.Resolve<ISetorServico>();
            _cargoServico = container.Resolve<ICargoServico>();

            var setores = _setorServico.PesquisarTodos();
            foreach (var setor in setores)
            {
                cbSetor.Items.Add(setor.Descricao);
            }
        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {
            gridCargo.DataSource = _cargoServico.PesquisarPorSetorDescricao(new Entidades.Setor { Descricao = cbSetor.Text }, txtCargo.Text);
        }

        private void cbSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridCargo.DataSource = _cargoServico.PesquisarPorSetor(new Entidades.Setor { Descricao = cbSetor.Text });
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCargo.Text))
                {
                    if (gridCargo.RowCount == 0)
                    {
                        var cargo = new Entidades.Cargo
                                        {
                                            Setor = _setorServico.PesquisarPorDesricao(cbSetor.Text).First(),
                                            Descricao = txtCargo.Text
                                        };
                        _cargoServico.Salvar(cargo);
                        MessageBox.Show("Cargo cadastrado com sucesso", "Inclusão", MessageBoxButtons.OK,
                                        MessageBoxIcon.None);
                    }
                    gridCargo.DataSource = _cargoServico.PesquisarTodos();
                }
                else
                {
                    throw new Exception("Campo cargo não preenchido");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
