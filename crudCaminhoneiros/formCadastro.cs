using crudCaminhoneiros.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudCaminhoneiros
{
    public partial class formCadastro : Form
    {
        Motorista Motorista = new Motorista();
        Endereco Endereco = new Endereco();
        Caminhao Caminhao = new Caminhao();

        public formCadastro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void formCadastro_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Capturando as informações de cadastro
                Motorista.Nome = txtNome.Text;
                Motorista.Sobrenome = txtSobrenome.Text;
                Endereco.Rua = txtEndereco.Text;
                Endereco.Numero = int.Parse(txtNumero.Text);
                Endereco.Bairro = txtBairro.Text;
                Endereco.Cidade = txtCidade.Text;
                Endereco.Estado = txtEstado.Text;
                Caminhao.Marca = txtMarca.Text;
                Caminhao.Modelo = txtModelo.Text;
                Caminhao.Placa = txtPlaca.Text;
                Caminhao.Eixos = int.Parse(txtEixos.Text);

                 Motorista.cadastrarMotorista();
                //Motorista.Endereco.cadastrarEndereco();
                // Motorista.Caminhao.CadastrarVeiculo();

                //Mensagem para quando o cadastro é efetuado com sucesso
                MessageBox.Show("Cadastrado com Sucesso!!");


                //Limpando os campos depois de cadastrar
                txtNome.Text = "";
                txtSobrenome.Text = "";
                txtEndereco.Text = "";
                txtNumero.Text = "";
                txtBairro.Text = "";
                txtCidade.Text = "";
                txtEstado.Text = "";
                txtMarca.Text = "";
                txtModelo.Text = "";
                txtPlaca.Text = "";
                txtEixos.Text = "";

            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao cadastrar. " + ex.Message);
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {

            try
            {
                Motorista.Nome = txtNome.Text;
                Motorista.Sobrenome = txtSobrenome.Text;
                Endereco.Rua = txtEndereco.Text;
                Endereco.Numero = int.Parse(txtNumero.Text);
                Endereco.Bairro = txtBairro.Text;
                Endereco.Cidade = txtCidade.Text;
                Endereco.Estado = txtEstado.Text;
                Caminhao.Marca = txtMarca.Text;
                Caminhao.Modelo = txtModelo.Text;
                Caminhao.Placa = txtPlaca.Text;
                Caminhao.Eixos = int.Parse(txtEixos.Text);

                //Motorista.cadastrarMotorista();
                //Motorista.Endereco.cadastrarEndereco();
                // Motorista.Caminhao.CadastrarVeiculo();
                MessageBox.Show("Atualizado com Sucesso!!");
                

                //Limpando os campos depois de cadastrar
                txtNome.Text = "";
                txtSobrenome.Text = "";
                txtEndereco.Text = "";
                txtNumero.Text = "";
                txtBairro.Text = "";
                txtCidade.Text = "";
                txtEstado.Text = "";
                txtMarca.Text = "";
                txtModelo.Text = "";
                txtPlaca.Text = "";
                txtEixos.Text = "";

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar. " + ex.Message);
            }
        }



        private void moveSidePanel(Control c)
        {


        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnExcluir);
           
            {
                try
                {
                    Motorista.id_Motorista = Convert.ToInt32(lblid.Text);
                    Motorista.Excluir();

                    //Limpando os campos depois de cadastrar
                    txtPlaca.Text = "";
                    txtModelo.Text = "";
                    txtEixos.Text = "";
                    txtMarca.Text = "";
                    MessageBox.Show("Veiculo excluido com Sucesso!!");
                    

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao cadastrar. " + ex.Message);
                }

            }


        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
