using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud___Cadastro
{
    public partial class frmFornecedor : Form
    {
        public frmFornecedor()
        {
            InitializeComponent();
        }

        Conexao bd = new Conexao();
        private const string TABELA = "tblFornecedor";

        private void frmFornecedor_Load(object sender, EventArgs e)
        {
            ExibirDados();
        }

        private void ExibirDados()
        {
            string dados = $"SELECT * FROM {TABELA}";
            DataTable dt = bd.ExecutarConsulta(dados);
            dtgFornecedor.DataSource = dt.AsDataView();
        }
        private void LimpaCampos()
        {
            lblID.Text = "";
            txtRazaoSocial.Clear();
            txtNomeFantasia.Clear();
            txtCNPJ.Clear();
            txtRazaoSocial.Focus();
        }

        private void dtgFornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.SetId(Convert.ToInt32(dtgFornecedor.Rows[e.RowIndex].Cells[0].Value));
            fornecedor.SetRazaoSocial(dtgFornecedor.Rows[e.RowIndex].Cells[1].Value.ToString());
            fornecedor.SetNomeFantasia(dtgFornecedor.Rows[e.RowIndex].Cells[2].Value.ToString());
            fornecedor.SetCNPJ(dtgFornecedor.Rows[e.RowIndex].Cells[3].Value.ToString());

            lblID.Text = fornecedor.GetId().ToString();
            txtRazaoSocial.Text = fornecedor.GetRazaoSocial();
            txtNomeFantasia.Text = fornecedor.GetNomeFantasia();
            txtCNPJ.Text = fornecedor.GetCNPJ();
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            if (txtRazaoSocial.Text != "" && txtNomeFantasia.Text != "" && txtCNPJ.Text != "")
            {
                fornecedor.SetRazaoSocial(txtRazaoSocial.Text);
                fornecedor.SetNomeFantasia(txtNomeFantasia.Text);
                fornecedor.SetCNPJ(txtCNPJ.Text);
                string inserir = $"INSERT INTO {TABELA} (razao_social, nome_fantasia, cnpj) VALUES('{fornecedor.GetRazaoSocial()}', '{fornecedor.GetNomeFantasia()}', '{fornecedor.GetCNPJ()}')";
                bd.ExecutarComandos(inserir);
                ExibirDados();
                LimpaCampos();
            }
            else
            {

                MessageBox.Show("Informação Inválida!", "Confirmação",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();

            if (txtRazaoSocial.Text != "" && txtNomeFantasia.Text != "" && txtCNPJ.Text != "" && int.TryParse(lblID.Text, out int id))
            {
                fornecedor.SetId(id);
                fornecedor.SetRazaoSocial(txtRazaoSocial.Text);
                fornecedor.SetNomeFantasia(txtNomeFantasia.Text);
                fornecedor.SetCNPJ(txtCNPJ.Text);
                string alterar = $"UPDATE {TABELA} SET razao_social = '{fornecedor.GetRazaoSocial()}',nome_fantasia = '{fornecedor.GetNomeFantasia()}', cnpj = '{fornecedor.GetCNPJ()}' WHERE id ={fornecedor.GetId()}";
                int resultado = bd.ExecutarComandos(alterar);
                if (resultado == 1)
                {
                    MessageBox.Show("Registro atualizado com sucesso!");
                    ExibirDados();
                    LimpaCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar!");
                }
            }
            else
            {
                MessageBox.Show("Informação Inválida!");
            }
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            ExibirDados();
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();

            if (int.TryParse(lblID.Text, out int id))
            {
                fornecedor.SetId(id);
                string excluir = $"DELETE FROM {TABELA} WHERE id = {fornecedor.GetId()}";
                int resultado = bd.ExecutarComandos(excluir);
                if (resultado == 1)
                {
                    MessageBox.Show("Registro deletado com sucesso!");
                    ExibirDados();
                    LimpaCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao excluir!");
                }
            }
            else
            {
                MessageBox.Show("Informação Inválida!");
            }
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
