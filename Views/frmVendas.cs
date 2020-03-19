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

namespace SistemaHoteleiro.Views
{
    public partial class frmVendas : Form
    {
        venda vend = new venda();
        public frmVendas()
        {
            InitializeComponent();
        }

        public void salvar(venda venda)
        {
            venda.ValorTotal = Convert.ToDecimal(txtvalor.Text);
            venda
        }

        private void frmVendas_Load(object sender, EventArgs e)
        {

        }
    }
}
