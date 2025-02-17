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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cadastroClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente cl1 = new frmCliente();
            cl1.ShowDialog();
        }

        private void cadastroFornecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFornecedor cl2 = new frmFornecedor();
            cl2.ShowDialog();
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
