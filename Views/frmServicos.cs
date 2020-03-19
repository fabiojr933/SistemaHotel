using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaHoteleiro.Dao;
using SistemaHoteleiro.Entidades;
using SistemaHoteleiro.Model;

namespace SistemaHoteleiro.Views
{
    public partial class frmServicos : Form
    {
        public frmServicos()
        {
            InitializeComponent();
        }
        servicos servico = new servicos();
        ServicoModel model = new ServicoModel();

        public void CadastrarServicos(servicos dado)
        {
            dado.Nome = txtServicoNome.Text;
            dado.Valor = Convert.ToDecimal(txtServiçoValor.Text);
            model.CadastrarServico(dado);
        }
        public void ListarServicos()
        {
            dataGridServico.DataSource = model.ListarServicos();
        }
        public void FormatarGrid()
        {
            dataGridServico.Columns[0].HeaderText = "ID";
            dataGridServico.Columns[0].Width = 50;
            dataGridServico.Columns[1].HeaderText = "SERVIÇOS";
            dataGridServico.Columns[1].Width = 150;
            dataGridServico.Columns[2].HeaderText = "VALOR";
            dataGridServico.Columns[2].Width = 50;
        }
        public void Carregar()
        {
            txtServicoNome.Text = dataGridServico.CurrentRow.Cells[1].Value.ToString();
            txtServiçoValor.Text = dataGridServico.CurrentRow.Cells[2].Value.ToString();
        }
        public void EditarServicos(servicos dado)
        {
            dado.Id = Convert.ToInt32(dataGridServico.CurrentRow.Cells[0].Value.ToString());
            dado.Nome = txtServicoNome.Text;
            dado.Valor = Convert.ToDecimal(txtServiçoValor.Text);
            model.EditarServico(dado);
        }
        public void DeletarServico(servicos dado)
        {
           dado.Id = Convert.ToInt32(dataGridServico.CurrentRow.Cells[0].Value.ToString());
            model.DeletarServicos(dado);
        }

        private void frmServicos_Load(object sender, EventArgs e)
        {
            btnNovo.Enabled = true;
            ListarServicos();
            FormatarGrid();

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtServicoNome.Enabled = true;
            txtServiçoValor.Enabled = true;
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CadastrarServicos(servico);
            ListarServicos();
            btnSalvar.Enabled = false;
            txtServicoNome.Text = "";
            txtServiçoValor.Text = "";
        }

        private void txtServiçoValor_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = txt.Text.Replace("R$", "").Trim();
        }

        private void txtServiçoValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //só permite numeros
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == ',') && !(e.KeyChar == Convert.ToChar(8)))
            {
                e.Handled = true;
            }
        }

        private void dataGridServico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            txtServicoNome.Enabled = true;
            txtServiçoValor.Enabled = true;
            Carregar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Tem certeza que deseja Editar", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                EditarServicos(servico);
                ListarServicos();
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                txtServicoNome.Text = "";
                txtServiçoValor.Text = "";
                MessageBox.Show("Serviço Editado com sucesso");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Tem certeza que deseja Excluir", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(resultado == DialogResult.Yes)
            {
                DeletarServico(servico);
                ListarServicos();
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                txtServicoNome.Text = "";
                txtServiçoValor.Text = "";
                MessageBox.Show("Serviço Excluido com sucesso");
            }
        }
    }
}
