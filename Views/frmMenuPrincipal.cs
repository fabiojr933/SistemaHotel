using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaHoteleiro.Cadastros;
using SistemaHoteleiro.Produtos;
using SistemaHoteleiro.Views;
using SistemaHoteleiro.ConectaBanco;
using SistemaHoteleiro.Entidades;
using SistemaHoteleiro.Model;
using SistemaHoteleiro.Relatorios;

namespace SistemaHoteleiro
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        Cargos cargo = new Cargos();
        LoginModel model = new LoginModel();
        usuarios dado = new usuarios();

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pnlTopo.BackColor = Color.FromArgb(210,210,210);
            pnlRight.BackColor = Color.FromArgb(0x42, 0x7A, 0xA1);
          //  comboBox1.BackColor = Color.FromArgb(0x42, 0x7A, 0xA1);
            lblUsuario.Text = Program.nomeUsuario;
            cargoLogin(cargo);
        }
        public void cargoLogin(Cargos dado)
        {
            comboBox1.DataSource = model.LoginCargo(dado);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "cargo";
            //comboBox1.BackColor = Color.FromArgb(250, 250, 250); 

            //dado.Cargo =  Convert.ToString(lblCargo.Text);
            //model.LoginCargo(dado);
        } 

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();            
        }

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFuncionarios funcionarios = new frmFuncionarios();
            funcionarios.Show();
        }

        private void cargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargos cargos = new frmCargos();
            cargos.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProdutos produtos = new frmProdutos();
            produtos.Show();
        }

        private void novoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdutos produtos = new frmProdutos();
            produtos.Show();
        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServicos servico = new frmServicos();
            servico.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario usuario = new frmUsuario();
            usuario.Show();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFornecedores fornecedor = new frmFornecedores();
            fornecedor.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdutos produto = new frmProdutos();
            produto.Show();
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmControleEstoque controleEstoque = new frmControleEstoque();
            controleEstoque.Show();
        }

        private void relatoriosDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelProdutos relProduto = new frmRelProdutos();
            relProduto.Show();
        }
    }
}
