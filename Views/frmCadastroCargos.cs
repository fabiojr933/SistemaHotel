using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaHoteleiro.ConectaBanco;
using SistemaHoteleiro.Entidades;
using Npgsql;
using SistemaHoteleiro.Dao;
using SistemaHoteleiro.Model;

namespace SistemaHoteleiro.Cadastros
{
    public partial class frmCargos : Form
    {
        public frmCargos()
        {
            InitializeComponent();
        }
        CargoModel cargoModel = new CargoModel();
        Cargos cargo = new Cargos();

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCargoNome.Enabled = true;
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            txtCargoNome.Focus();
        }

        //salvar cargo
        public void SalvarCargo(Cargos dado)
        {
                dado.Cargo = txtCargoNome.Text;
                cargoModel.SalvarCargo(dado);           
        }
        //Formatar as columas do data grid de cargos
        public void FormatarDados()
        {
            dataGridCargo.Columns[0].HeaderText = "ID";
            dataGridCargo.Columns[0].Width = 50;
            dataGridCargo.Columns[1].HeaderText = "CARGO";
            dataGridCargo.Columns[1].Width = 385;

        //deixar columa nao visivel
        //dataGridCargo.Columns[3].Visible = false;

        }
        //careegar dados na datagrid
        public void ListarDados()
        {
            dataGridCargo.DataSource = cargoModel.ListarDados();
            FormatarDados();
        }
        // metedo para Editar um cargo
        public void EditarCargo(Cargos dado)
        {
            try
            {
                //   dado.Id = Convert.ToInt32(txtId.Text);
                dado.Id = Convert.ToInt32(dataGridCargo.CurrentRow.Cells[0].Value.ToString());
                dado.Cargo = txtCargoNome.Text;
                cargoModel.EditarCargo(dado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        // deletar cargo
        public void DeletarCargo(Cargos dado)
        {
            dado.Id = dado.Id = Convert.ToInt32(dataGridCargo.CurrentRow.Cells[0].Value.ToString());
            cargoModel.DeletarCargo(dado);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtCargoNome.Text.ToString().Trim() == "")
            {
                txtCargoNome.Text = "";
                MessageBox.Show("Peencha o Nome");
                txtCargoNome.Focus();
                return;
            }
            btnNovo.Enabled = true;           


            //CODIGO 
            SalvarCargo(cargo);
            ListarDados();
            //CODIGO
            //FINAL
            MessageBox.Show("Registro salvo com sucesso", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;           
            txtCargoNome.Enabled = false;
            txtCargoNome.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCargoNome.Text.ToString().Trim() == "")
            {
                txtCargoNome.Text = "";
                MessageBox.Show("Peencha o Nome");
                txtCargoNome.Focus();
                return;
            }
            btnNovo.Enabled = true;


            //CODIGO 
            var resultado = MessageBox.Show("Deseja realmente alterar o cadastro? ","ALTERAÇÃO",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                EditarCargo(cargo);
                //CODIGO
                //FINAL
                MessageBox.Show("Registro editado com sucesso", "Dados Editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
                txtCargoNome.Text = "";
                txtCargoNome.Enabled = false;
                ListarDados();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excluir o Registro", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //CODIGO EXCLUIR
                DeletarCargo(cargo);
                ListarDados();
                //CODIGO
                //FINAL

                MessageBox.Show("Registro excluido com sucesso", "Dado Excluido", MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
                txtCargoNome.Text = "";
                txtCargoNome.Enabled = false;
                btnEditar.Enabled = false;
            }
        }


        private void dataGridCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            txtCargoNome.Text = dataGridCargo.CurrentRow.Cells[1].Value.ToString();
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            txtCargoNome.Enabled = true;
        }
    }
}
