using crudCaminhoneiros.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudCaminhoneiros
{
    public partial class Form1 : Form
    {
        Motorista Motorista = new Motorista();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cadastroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formCadastro cadastro = new formCadastro();
            Hide();
            cadastro.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtGrid.DataSource = Motorista.Listar();
        }
    }
}
