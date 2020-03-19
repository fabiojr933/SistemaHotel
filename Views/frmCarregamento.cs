using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHoteleiro.Views
{
    public partial class frmCarregamento : Form
    {
        public frmCarregamento()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(0x42, 0x7A, 0xA1);

            progressBar1.Value = progressBar1.Value + 1;
            if (progressBar1.Value >= 100)
            {
                frmLogin login = new frmLogin();
                this.Hide();
                login.Show();
                timer1.Enabled = true;
                progressBar1.Visible = false;
                timer1.Enabled = false;
            }
        }
    }
}
