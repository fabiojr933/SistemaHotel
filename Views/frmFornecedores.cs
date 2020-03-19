using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaHoteleiro.Entidades;
using SistemaHoteleiro.Model;

namespace SistemaHoteleiro.Views
{
    public partial class frmFornecedores : Form
    {
        public frmFornecedores()
        {
            InitializeComponent();
        }

        FornecedoresModel model = new FornecedoresModel();
        fornecedores fornecedor = new fornecedores();

        public void cadastrarFornecedor(fornecedores dado)
        {
            dado.Nome = txtNome.Text;
            dado.Endereco = txtEndereco.Text;
            dado.Telefone = mascTelefone.Text;
            model.cadastrarFornecedor(dado);
            MessageBox.Show("Fornecedor Cadastrado com sucesso");
        }
        public void listar()
        {
            dataGridFornecedores.DataSource = model.listar();
            formatarGrid();
        }
        public void formatarGrid()
        {
            dataGridFornecedores.Columns[0].HeaderText = "ID";
            dataGridFornecedores.Columns[0].Width = 40;
            dataGridFornecedores.Columns[1].HeaderText = "NOME";
            dataGridFornecedores.Columns[1].Width = 140;
            dataGridFornecedores.Columns[2].HeaderText = "ENDEREÇO";
            dataGridFornecedores.Columns[2].Width = 130;
            dataGridFornecedores.Columns[3].HeaderText = "TELEFONE";
            dataGridFornecedores.Columns[3].Width = 120;
        }
        public void listarNoForn(fornecedores dado)
        {
            txtNome.Text = dataGridFornecedores.CurrentRow.Cells[1].Value.ToString();
            txtEndereco.Text = dataGridFornecedores.CurrentRow.Cells[2].Value.ToString();
            mascTelefone.Text = dataGridFornecedores.CurrentRow.Cells[3].Value.ToString();
        }
        public void editar(fornecedores dado)
        {
            dado.Nome = txtNome.Text;
            dado.Endereco = txtEndereco.Text;
            dado.Telefone = mascTelefone.Text;
            dado.Id = Convert.ToInt32(dataGridFornecedores.CurrentRow.Cells[0].Value.ToString());
            model.Editar(dado);
            MessageBox.Show("Fornecedor EDITADO com sucesso");
        }
        public void Deletar(fornecedores dado)
        {
            dado.Id = Convert.ToInt32(dataGridFornecedores.CurrentRow.Cells[0].Value.ToString());
            model.Deletar(dado);
            MessageBox.Show("Fornecedor DELETADO COM SUCESSO");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            cadastrarFornecedor(fornecedor);
            listar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            mascTelefone.Enabled = true;
            btnSalvar.Enabled = true;
            txtEndereco.Text = "";
            txtNome.Text = "";
            mascTelefone.Text = "";
        }

        private void frmFornecedores_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void dataGridFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            txtEndereco.Enabled = true;
            txtNome.Enabled = true;
            mascTelefone.Enabled = true;
            listarNoForn(fornecedor);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja realmente EDITAR? ", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                editar(fornecedor);
                listar();
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                txtEndereco.Text = "";
                txtNome.Text = "";
                mascTelefone.Text = "";
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Tem certeza que deseja EXCLUIR! ","EXCLUIR",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Deletar(fornecedor);
                listar();
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = false;
                txtEndereco.Text = "";
                txtNome.Text = "";
                mascTelefone.Text = "";
            }
        }
    }
}
