using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHoteleiro.Relatorios
{
    public partial class frmRelProdutos : Form
    {
        public frmRelProdutos()
        {
            InitializeComponent();
        }

        private void frmRelProdutos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dataSet1.ProdutosFornecedores'. Você pode movê-la ou removê-la conforme necessário.
            this.produtosFornecedoresTableAdapter.Fill(this.dataSet1.ProdutosFornecedores);
            // TODO: esta linha de código carrega dados na tabela 'dataSet1.produtos'. Você pode movê-la ou removê-la conforme necessário.
            this.produtosTableAdapter.Fill(this.dataSet1.produtos);

            this.reportViewer1.RefreshReport();
        }
    }
}
