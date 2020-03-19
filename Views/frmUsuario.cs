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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }
        UsuarioModel model = new UsuarioModel();
        usuarios usuario = new usuarios();

        public void listarCombo()
        {
            if (model.carregarCargo().Rows.Count > 0)
            {
                cbCargo.DataSource = model.carregarCargo();
                cbCargo.ValueMember = "id";
                cbCargo.DisplayMember = "cargo";

            }
            else
            {
                cbCargo.Text = "Por favar cadastre um cargo";
            }
        }
        public void listaGrid()
        {
            dataGridUsuario.DataSource = model.listar();
            dataGridUsuario.Columns[0].HeaderText = "ID";
            dataGridUsuario.Columns[0].Width = 50;
            dataGridUsuario.Columns[1].Visible = false;
            dataGridUsuario.Columns[2].HeaderText = "Nome";
            dataGridUsuario.Columns[2].Width = 250;
            dataGridUsuario.Columns[3].Visible = false;
            dataGridUsuario.Columns[4].Visible = false;
        }
        public void EditarDados(usuarios dado)
        {
            var resultado = MessageBox.Show("tem certeza que deseja Editar", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                dado.Id = Convert.ToInt32(dataGridUsuario.CurrentRow.Cells[0].Value.ToString());
                dado.Cargo =  Convert.ToInt32(cbCargo.SelectedValue);
                dado.Usuario = txtUsuario.Text;
                dado.Senha = txtSenha.Text;
                dado.Data = DateTime.Now;
                model.editar(dado);
                MessageBox.Show("Usuario Editado com sucesso");
            }
        }
        public void deletarDados(usuarios dado)
        {
            var resultado = MessageBox.Show("tem certeza que deseja excluir", "Ceretza", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                dado.Id = Convert.ToInt32(dataGridUsuario.CurrentRow.Cells[0].Value.ToString());
                model.deletar(dado);
                MessageBox.Show("Usuario Excluido com sucesso");
            }
        }

        public void cadastrarUsuario(usuarios dado)
        {
            dado.Cargo = Convert.ToInt32(cbCargo.SelectedValue);
            dado.Usuario = txtUsuario.Text;
            dado.Senha = txtSenha.Text;
            dado.Data = DateTime.Now;
            model.salvarUsuario(dado);
            MessageBox.Show("Usuario Cadastrado com sucesso");
        }
        public void pequisar(usuarios dado)
        {
            String formatar = txtBuscar.Text;
            String formatado = formatar.ToUpper();
            if (formatado == "")
            {
                listaGrid();
            }
            else
            {
                dado.Usuario = formatado;
                dataGridUsuario.DataSource = model.pequisar(dado);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtSenha.Enabled = true;
            txtUsuario.Enabled = true;
            btnSalvar.Enabled = true;
            cbCargo.Enabled = true;
            txtSenha.Text = "";
            txtUsuario.Text = "";
            listaGrid();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            cadastrarUsuario(usuario);
            listaGrid();
            txtSenha.Text = "";
            cbCargo.Text = "";
            txtUsuario.Text = "";
            btnSalvar.Enabled = false;
            txtUsuario.Focus();
        }

        private void dataGridCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbCargo.SelectedValue = dataGridUsuario.CurrentRow.Cells[1].Value.ToString();
            txtUsuario.Text = dataGridUsuario.CurrentRow.Cells[2].Value.ToString();
            txtSenha.Text = dataGridUsuario.CurrentRow.Cells[3].Value.ToString();
            

            txtSenha.Enabled = true;
            cbCargo.Enabled = true;
            txtUsuario.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnNovo.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarDados(usuario);
            listaGrid();
            txtSenha.Text = "";
            cbCargo.Text = "";
            txtUsuario.Text = "";
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnNovo.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            deletarDados(usuario);
            listaGrid();
            txtSenha.Text = "";
            cbCargo.Text = "";
            txtUsuario.Text = "";
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnNovo.Enabled = true;
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            listaGrid();
            txtBuscar.Enabled = true;
            btnNovo.Enabled = true;
            listarCombo();
            txtUsuario.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            pequisar(usuario);
        }
    }
}
