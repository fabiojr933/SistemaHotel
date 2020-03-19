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

namespace SistemaHoteleiro.Cadastros
{
    public partial class frmFuncionarios : Form
    {
        public frmFuncionarios()
        {
            InitializeComponent();
        }

        FuncionarioModel model = new FuncionarioModel();
        funcionarios funcionario = new funcionarios();
        Cargos cargo = new Cargos();

        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            txtTelefone.Enabled = true;
            cbCargo.Enabled = true;
            txtCPF.Enabled = true;
            txtBairro.Enabled = true;
            cbCidade.Enabled = true;
            cbUF.Enabled = true;
            txtNome.Focus();
        }
        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            txtTelefone.Enabled = false;
            cbCargo.Enabled = false;
            txtCPF.Enabled = false;
            txtBairro.Enabled = false;
            cbCidade.Enabled = false;
            cbUF.Enabled = false;
        }
        private void LimparCampos()
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtTelefone.Text = "";
            txtCPF.Text = "";
            txtBairro.Text = "";
            cbCargo.Text = "";
            cbCidade.Text = "";
            cbUF.Text = "";
        }   
        public void listarCombo()
        {
            if (model.carregarComboCargo().Rows.Count > 0)
            {
                cbCargo.DataSource = model.carregarComboCargo();
                cbCargo.ValueMember = "id";
                cbCargo.DisplayMember = "cargo";
            }
            else
            {
                cbCargo.Text = "Cadastre um cargo";
            }
        }
        public void ListarComboCidade()
        {        

            cbCidade.DataSource = model.CarregarComboCidades();
            cbCidade.ValueMember = "id";
            cbCidade.DisplayMember = "nome";
        }
        public void ListarComboEstado()
        {
            cbUF.DataSource = model.CarregarComboEstado();
            cbUF.ValueMember = "id";
            cbUF.DisplayMember = "uf";
        }
        public void CadastrarFuncionarios(funcionarios dado)
        {
            dado.Nome = txtNome.Text;
            dado.Cpf = txtCPF.Text;
            dado.Endereco = txtEndereco.Text;
            dado.Telefone = txtTelefone.Text;
            dado.Bairro = txtBairro.Text;
            dado.Cidade = Convert.ToInt32(cbCidade.SelectedValue);
            dado.Uf = Convert.ToInt32(cbUF.SelectedValue);
            dado.IdCargo = Convert.ToInt32(cbCargo.SelectedValue);
            dado.Data = DateTime.Now;
            model.CadastrarFuncionarios(dado);
        }
        public void ListarFuncionarios()
        {
            dataGridFuncionarios.DataSource = model.ListarFuncionarios();
            formatarDataGrid();
        }
        public void formatarDataGrid()
        {
            dataGridFuncionarios.Columns[0].HeaderText = "ID";
            dataGridFuncionarios.Columns[0].Width = 35;
            dataGridFuncionarios.Columns[1].HeaderText = "NOME";
            dataGridFuncionarios.Columns[1].Width = 165;
            dataGridFuncionarios.Columns[2].HeaderText = "CPF";
            dataGridFuncionarios.Columns[2].Width = 100;
            dataGridFuncionarios.Columns[3].HeaderText = "ENDEREÇO";
            dataGridFuncionarios.Columns[3].Width = 100;
            dataGridFuncionarios.Columns[4].HeaderText = "TELEFONE";
            dataGridFuncionarios.Columns[4].Width = 150;   
            dataGridFuncionarios.Columns[5].Visible = false;            
            dataGridFuncionarios.Columns[6].Visible = false;
            dataGridFuncionarios.Columns[7].Visible = false;
            dataGridFuncionarios.Columns[8].Visible = false;
            dataGridFuncionarios.Columns[9].Visible = false;
            
        }
        public void EditarCadastro(funcionarios dado)
        {
            dado.Nome = txtNome.Text;
            dado.Cpf = txtCPF.Text;
            dado.Endereco = txtEndereco.Text;
            dado.Telefone = txtTelefone.Text;
            dado.Bairro = txtBairro.Text;
            dado.Cidade = Convert.ToInt32(cbCidade.SelectedValue);
            dado.Uf = Convert.ToInt32(cbUF.SelectedValue);
            dado.IdCargo = Convert.ToInt32(cbCargo.SelectedValue);
            dado.Data = DateTime.Now;
            dado.Id = Convert.ToInt32(dataGridFuncionarios.CurrentRow.Cells[0].Value.ToString());
            model.EditarCadastro(dado);
        }
        public void DeletarFuncionario(funcionarios dado)
        {
            dado.Id = Convert.ToInt32(dataGridFuncionarios.CurrentRow.Cells[0].Value.ToString());
            model.DeletarFuncionario(dado);
        }
        public void BuscarNome(funcionarios dado)
        {
            string formatar = txtBuscarNome.Text;
            string formatado = formatar.ToUpper();
            dado.Nome = formatado;
            dataGridFuncionarios.DataSource = model.BuscarNome(dado);
        }
        public void BuscarCPF(funcionarios dado)
        {
            if (txtBuscarCPF.Text == "   .   .   -")
            {
                ListarFuncionarios();
            }
            else
            {
                dado.Cpf = txtBuscarCPF.Text;
                dataGridFuncionarios.DataSource = model.buscarCpf(dado);
            }            
        }

        private void frmFuncionarios_Load(object sender, EventArgs e)
        {
            rbNome.Checked = true;    
            
        }

        private void rbNome_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = true;
            txtBuscarCPF.Visible = false;
            txtBuscarNome.Text = "";
        }

        private void rbCPF_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = false;
            txtBuscarCPF.Visible = true;
            txtBuscarCPF.Text = "";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            LimparCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            ListarFuncionarios();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                txtNome.Text = "";
                MessageBox.Show("Peencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }
            if (txtCPF.Text.ToString().Trim() == "   .   .   -")
            {
                txtCPF.Text = "";
                MessageBox.Show("Preencha o CPF", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPF.Focus();
                return;
            }

            //COGIGO PARA SALVAR
            CadastrarFuncionarios(funcionario);
            ListarFuncionarios();

            //FIM
            MessageBox.Show("Registro salvo com sucesso", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;     
            LimparCampos();
            DesabilitarCampos();
        }

        private void dataGridFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;
            txtNome.Text = dataGridFuncionarios.CurrentRow.Cells[1].Value.ToString();
            txtCPF.Text = dataGridFuncionarios.CurrentRow.Cells[2].Value.ToString();
            txtEndereco.Text = dataGridFuncionarios.CurrentRow.Cells[3].Value.ToString();
            txtTelefone.Text = dataGridFuncionarios.CurrentRow.Cells[4].Value.ToString();
            txtBairro.Text = dataGridFuncionarios.CurrentRow.Cells[5].Value.ToString();
            cbCidade.SelectedValue = dataGridFuncionarios.CurrentRow.Cells[6].Value.ToString();
            cbUF.SelectedValue = dataGridFuncionarios.CurrentRow.Cells[7].Value.ToString();
            cbCargo.SelectedValue = dataGridFuncionarios.CurrentRow.Cells[8].Value.ToString();
            HabilitarCampos();

            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                txtNome.Text = "";
                MessageBox.Show("Peencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }
            if (txtCPF.Text.ToString().Trim() == "   .   .   -")
            {
                txtCPF.Text = "";
                MessageBox.Show("Preencha o CPF", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPF.Focus();
                return;
            }

            //COGIGO PARA EDITAR

            var resultado = MessageBox.Show("Tem certeza que deseja Editar o Cadastro","ATENÇÃO", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                EditarCadastro(funcionario);
                MessageBox.Show("Registro editado com sucesso", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                LimparCampos();
                DesabilitarCampos();
                ListarFuncionarios();
            }

            //FIM
           
        
    
    }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excluir o Registro", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {

                //CODIGO EXCLUIR

                DeletarFuncionario(funcionario);

                //CODIGO
                //FINAL

                MessageBox.Show("Registro excluido com sucesso", "Dado Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                LimparCampos();
                DesabilitarCampos();
                ListarFuncionarios();
            }
        }

        private void frmFuncionarios_Load_1(object sender, EventArgs e)
        {
            cbCargo.Enabled = true;
            cbCargo.Text = "";
            cbCidade.Enabled = true;
            cbCidade.Text = "";
            cbUF.Enabled = true;
            cbUF.Text = "";
            listarCombo();
            ListarComboCidade();
            ListarComboEstado();
            ListarFuncionarios();
        }

        private void txtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome(funcionario);
        }

        private void txtBuscarCPF_TextChanged(object sender, EventArgs e)
        {
            BuscarCPF(funcionario);
        }
    }
}
