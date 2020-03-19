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
using SistemaHoteleiro.Views;


namespace SistemaHoteleiro.Views
{
    public partial class frmControleEstoque : Form
    {
        public frmControleEstoque()
        {
            InitializeComponent();
        }

        EstoqueModel model = new EstoqueModel();
        produtos Produto = new produtos();

        public void carregarCombo()
        {
            cbFornecedor.DataSource = model.carregarCombo();
            cbFornecedor.DisplayMember = "nome";
            cbFornecedor.ValueMember = "id";
        }
        public void formatarGrid()
        {
            dataGridEstoque.Columns[0].HeaderText = "ID";
            dataGridEstoque.Columns[0].Width = 40;
            dataGridEstoque.Columns[1].HeaderText = "NOME";
            dataGridEstoque.Columns[1].Width = 150;
            dataGridEstoque.Columns[2].HeaderText = "FORNECEDOR";
            dataGridEstoque.Columns[2].Width = 110;
            dataGridEstoque.Columns[3].HeaderText = "ESTOQUE";
            dataGridEstoque.Columns[3].Width = 70;
            dataGridEstoque.Columns[4].Visible = false;
            dataGridEstoque.Columns[5].Visible = false;

        }
        public void Listar()
        {           
            dataGridEstoque.DataSource = model.Listar();
        }
        public void listarForm()
        {
            txtNome.Text = dataGridEstoque.CurrentRow.Cells[1].Value.ToString();           
            txtEstoque.Text = dataGridEstoque.CurrentRow.Cells[3].Value.ToString();
            txtVlrCompra.Text = dataGridEstoque.CurrentRow.Cells[4].Value.ToString();
            cbFornecedor.SelectedValue = dataGridEstoque.CurrentRow.Cells[5].Value.ToString();

        }
        public void salvar(produtos dados)
        {
            dados.Estoque = Convert.ToInt32(txtQtd.Text);
            dados.ValorCompra = Convert.ToDecimal(txtVlrCompra.Text);
            dados.Id = Convert.ToInt32(dataGridEstoque.CurrentRow.Cells[0].Value.ToString());
            model.salvar(dados);
        }

        private void ControleEstoque_Load(object sender, EventArgs e)
        {
            carregarCombo();
            Listar();
            formatarGrid();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
        }

        private void dataGridEstoque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            listarForm();

        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //só permite numeros
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == ',') && !(e.KeyChar == Convert.ToChar(8)))
            {
                e.Handled = true;
            }
        }

        private void txtVlrCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            //só permite numeros
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == ',') && !(e.KeyChar == Convert.ToChar(8)))
            {
                e.Handled = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            salvar(Produto);
            Listar();
            txtEstoque.Text = "";
            txtNome.Text = "";
            txtQtd.Text = "";
            txtVlrCompra.Text = "";
            cbFornecedor.Text = "";
        }
    }
}
