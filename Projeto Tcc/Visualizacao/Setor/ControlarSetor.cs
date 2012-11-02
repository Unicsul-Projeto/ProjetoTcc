using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Projeto_Tcc.Entidades;
using Projeto_Tcc.Repositorio.Helpers;

namespace Projeto_Tcc.Visualizacao
{
    public partial class ControlarSetor : Form
    {
        public ControlarSetor()
        {
            InitializeComponent();
        }

        private ISetorServico _setorServico;

        private void ControlarSetor_Load(object sender, EventArgs e)
        {
            try
            {
                var container = ContainerWindsor.InicializarContainer();
                _setorServico = container.Resolve<ISetorServico>();

                gridSetor.DataSource = _setorServico.PesquisarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void txtSetor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var setores = _setorServico.PesquisarPorDesricao(txtSetor.Text);
                gridSetor.DataSource = setores ?? new List<Entidades.Setor>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSetor.Text))
                {
                    var setores = _setorServico.PesquisarTodos();
                    if (setores.Count == 0)
                    {
                        _setorServico.Salvar(new Entidades.Setor { Descricao = txtSetor.Text });
                        MessageBox.Show("Setor cadastrado com sucesso", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {
                        foreach (var setor in setores)
                        {
                            if (setor.Descricao != txtSetor.Text)
                            {
                                _setorServico.Salvar(new Entidades.Setor { Descricao = txtSetor.Text });
                                MessageBox.Show("Setor cadastrado com sucesso", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                        }
                    }

                    gridSetor.DataSource = _setorServico.PesquisarTodos();

                }
                else
                {
                    throw new Exception("Campo Setor não preenchido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
