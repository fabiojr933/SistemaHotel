using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaHoteleiro.Model;
using SistemaHoteleiro.Entidades;
using System.IO;

namespace SistemaHoteleiro.Produtos                                
{
    public partial class frmProdutos : Form
    {
        string foto;

        public frmProdutos()
        {
            InitializeComponent();
        }

        ProdutosModel model = new ProdutosModel();
        produtos produto = new produtos();
        fornecedores fornecedore = new fornecedores();

        public void carregarCombo()
        {
            cbFornecedor.DataSource = model.carregarCombo();
            cbFornecedor.DisplayMember = "nome";
            cbFornecedor.ValueMember = "id";
        }
        public void salvar(produtos dado)
        {
            dado.Nome = txtNome.Text;
            dado.Descricao = txtDescricao.Text;
            dado.Grupo = txtGrupo.Text;
            dado.Setor = txtSetor.Text;
            dado.Estoque =  Convert.ToInt32(txtEstoque.Text);
            dado.IdFornecedor = Convert.ToInt32(cbFornecedor.SelectedValue);
            dado.Venda = Convert.ToDecimal(txtValor.Text);
            dado.Data = DateTime.Now;
            dado.Oid = Convert.ToString(img());
            model.salvar(dado);
            MessageBox.Show("Produto cadastrado com sucesso");
        }
        public void listar()
        {
            dataGridProduto.DataSource = model.listar();
        }
        public void formatarGrid()
        {
            dataGridProduto.Columns[0].HeaderText = "ID";
            dataGridProduto.Columns[0].Width = 60;
            dataGridProduto.Columns[1].HeaderText = "DESCRIÇÃO";
            dataGridProduto.Columns[1].Width = 160;
            dataGridProduto.Columns[2].Visible = false;       
            dataGridProduto.Columns[3].Visible = false;
            dataGridProduto.Columns[4].Visible = false;
            dataGridProduto.Columns[5].HeaderText = "ESTOQUE";
            dataGridProduto.Columns[5].Width = 90;
            dataGridProduto.Columns[6].Visible = false;
            dataGridProduto.Columns[7].DefaultCellStyle.Format = "C2";
            dataGridProduto.Columns[7].HeaderText = "PREÇO";
            dataGridProduto.Columns[7].Width = 90;
            dataGridProduto.Columns[8].Visible = false;
            dataGridProduto.Columns[9].HeaderText = "FORNECEDOR";
            dataGridProduto.Columns[9].Width = 135;

        }


        public void carregarGrid()
        {
            txtNome.Text = dataGridProduto.CurrentRow.Cells[1].Value.ToString();
            txtDescricao.Text = dataGridProduto.CurrentRow.Cells[2].Value.ToString();
            txtGrupo.Text = dataGridProduto.CurrentRow.Cells[3].Value.ToString();
            txtSetor.Text = dataGridProduto.CurrentRow.Cells[4].Value.ToString();
      //    txtEstoque.Text = dataGridProduto.CurrentRow.Cells[5].Value.ToString();
            cbFornecedor.SelectedValue = dataGridProduto.CurrentRow.Cells[6].Value.ToString();
            txtValor.Text = dataGridProduto.CurrentRow.Cells[7].Value.ToString();
            
            //recupera a imagen pelo banco
            //byte[] image = (byte[])dataGridProduto.CurrentRow.Cells[10].Value;
            //MemoryStream ms = new MemoryStream(image);
            //pictureBox1.Image = System.Drawing.Image.FromStream(ms);

            txtEstoque.Enabled = false;
            
        }
        public void pesquisar(produtos dado)
        {
            string formatar = txtBuscarNome.Text;
            string formatado = formatar.ToUpper();
            dado.Nome = formatado;
            dataGridProduto.DataSource = model.pesquisar(dado);
        }

        public void Editar(produtos dado)
        {
            dado.Nome = txtNome.Text;
            dado.Descricao = txtDescricao.Text;
            dado.Grupo = txtGrupo.Text;
            dado.Setor = txtSetor.Text;
            dado.IdFornecedor = Convert.ToInt32(cbFornecedor.SelectedValue);
            dado.Venda = Convert.ToDecimal(txtValor.Text);
            dado.Data = DateTime.Now;
            dado.Id = Convert.ToInt32(dataGridProduto.CurrentRow.Cells[0].Value.ToString());
            model.Editar(dado);
        }
        public void deletar(produtos dado)
        {
            dado.Id = Convert.ToInt32(dataGridProduto.CurrentRow.Cells[0].Value.ToString());
            model.deletar(dado);
        }

       private void limparFoto()
        {
            pictureBox1.Image = Properties.Resources.sem_foto;
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            limparFoto();
            carregarCombo();
            listar();
            formatarGrid();

        }
        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtDescricao.Enabled = true;
            txtValor.Enabled = true;
            cbFornecedor.Enabled = true;
            txtNome.Enabled = true;
            txtNome.Focus();
            txtEstoque.Enabled = true;
            txtGrupo.Enabled = true;
            txtSetor.Enabled = true;
            btnBuscarImagem.Enabled = true;
        }
        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtDescricao.Enabled = false;
            txtValor.Enabled = false;
            cbFornecedor.Enabled = false;
            txtEstoque.Enabled = false;
            txtGrupo.Enabled = false;
            txtSetor.Enabled = false;
            btnBuscarImagem.Enabled = false;
        }
        private void LimparCampos()
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtValor.Text = "";
            txtEstoque.Text = "";
            txtGrupo.Text = "";
            txtSetor.Text = "";            
            limparFoto();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            LimparCampos();
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
            if (txtValor.Text.ToString().Trim() == "")
            {
                txtValor.Text = "";
                MessageBox.Show("Preencha o valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            }

            //COGIGO PARA SALVAR
            salvar(produto);
            listar();
            //FIM
            MessageBox.Show("Registro salvo com sucesso", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            LimparCampos();
            DesabilitarCampos();
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
            if (txtValor.Text.ToString().Trim() == "   .   .   -")
            {
                txtValor.Text = "";
                MessageBox.Show("Preencha o valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            }

            //COGIGO PARA EDITAR
            Editar(produto);
            listar();
            //FIM
            MessageBox.Show("Registro editado com sucesso", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            LimparCampos();
            DesabilitarCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excluir o Registro", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //CODIGO EXCLUIR
                deletar(produto);
                listar();
                //CODIGO
                //FINAL

                MessageBox.Show("Registro excluido com sucesso", "Dado Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                LimparCampos();
                DesabilitarCampos();
            }
        }

        //subir uma imagen para o banco de dados
        private byte[] img()
        {
            byte[] image_byte = null;
            if(foto == "")
            {
                return null;
            }
            FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            image_byte = br.ReadBytes((int)fs.Length);
            return image_byte;
        }

        private void btnBuscarImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Imagens(*.jpg;*.png)|*.jpg;*.png|todos Arquivos(*.*)|*.*";    //mostrar todos (*.*)|*.*
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foto = dialog.FileName.ToString();
                pictureBox1.ImageLocation = foto;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //só permite numeros
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == ',') && !(e.KeyChar == Convert.ToChar(8)))
            {
                e.Handled = true;
            }
        }

        private void txtEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            //só permite numeros
            if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == ',') && !(e.KeyChar == Convert.ToChar(8)))
            {
                e.Handled = true;
            }


        }

        private void dataGridProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            carregarGrid();
            HabilitarCampos();
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            txtEstoque.Enabled = false;
        }

        private void txtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarNome.Text == "")
            {
                listar();
            }
            else
            {
                pesquisar(produto);
            }                     
        }
    }
}
