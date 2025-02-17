using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Ocsp;
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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        Conexao bd = new Conexao();
        private const string TABELA = "tblClientes";

        private void frmCliente_Load(object sender, EventArgs e)
        {
            ExibirDados();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            if (txtNome.Text != "" && txtTelefone.Text != "")
            {
                cliente.SetNome(txtNome.Text);
                cliente.SetTelefone(txtTelefone.Text);
                cliente.SetSexo(rdbMasculino.Checked ? "M" : "F");
                string inserir = $"INSERT INTO {TABELA} (nome, telefone, sexo) VALUES('{cliente.GetNome()}', '{cliente.GetTelefone()}', '{cliente.GetSexo()}')";
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

        private void ExibirDados()
        {
            string dados = $"SELECT * FROM {TABELA}";
            DataTable dt = bd.ExecutarConsulta(dados);
            dtgCliente.DataSource = dt.AsDataView();
        }
        private void LimpaCampos()
        {
            lblID.Text = "";
            txtNome.Clear();
            txtTelefone.Clear();
            rdbMasculino.Checked = false;
            rdbFeminino.Checked = false;
            txtNome.Focus();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            if (txtNome.Text != "" && txtTelefone.Text != "" && int.TryParse(lblID.Text, out int id))
            {
                cliente.SetId(id);
                cliente.SetNome(txtNome.Text);
                cliente.SetTelefone(txtTelefone.Text);
                cliente.SetSexo(rdbMasculino.Checked ? "M" : "F");
                string alterar = $"UPDATE {TABELA} SET nome = '{cliente.GetNome()}',telefone = '{cliente.GetTelefone()}', sexo = '{cliente.GetSexo()}' WHERE id ={cliente.GetId()}";
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            if (int.TryParse(lblID.Text, out int id))
            {
                cliente.SetId(id);
                string excluir = $"DELETE FROM {TABELA} WHERE id = {cliente.GetId()}";
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ExibirDados();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtgCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.SetId(Convert.ToInt32(dtgCliente.Rows[e.RowIndex].Cells[0].Value));
            cliente.SetNome(dtgCliente.Rows[e.RowIndex].Cells[1].Value.ToString());
            cliente.SetSexo(dtgCliente.Rows[e.RowIndex].Cells[2].Value.ToString());
            cliente.SetTelefone(dtgCliente.Rows[e.RowIndex].Cells[3].Value.ToString());

            lblID.Text = cliente.GetId().ToString();
            txtNome.Text = cliente.GetNome();
            txtTelefone.Text = cliente.GetTelefone();
            rdbMasculino.Checked = cliente.GetSexo() == "M";
            rdbFeminino.Checked = cliente.GetSexo() == "F";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }
    }
}
