using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SistemaHoteleiro.ConectaBanco;
using SistemaHoteleiro.Entidades;
using SistemaHoteleiro.Model;
using SistemaHoteleiro.Views;

namespace SistemaHoteleiro
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            pnlLogin.Visible = false;
        }

        usuarios usuario = new usuarios();
        LoginModel model = new LoginModel();

        //DESABILITA O FECHAR DO FORM
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //DESABILITA O FECHAR DO FORM
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);


            pnlLogin.Location = new Point(this.Width / 2 - 166, this.Height / 2 - 170);
            pnlLogin.Visible = true;
            txtUsuario.Focus();
            // btnEntrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(21,114,160);
           
        }

        //Valid~ção do Login
        public void ChamarLogin(usuarios dado)
        {
            string formatarUser = txtUsuario.Text;
            string formatarPass = txtSenha.Text;
            string formatadoUser = formatarUser.ToUpper();
            string formatadoPass = formatarPass.ToUpper();

            if (txtUsuario.Text.ToString().Trim() == "")
            {               
                MessageBox.Show("Preencha o Usuario", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Text = "";
                txtUsuario.Focus();
                return;
            }
            if (txtSenha.Text.ToString().Trim() == "")
            {                
                MessageBox.Show("Preencha a Senha", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            //Codigo do login

            model.Logar(formatadoUser, formatadoPass);
            if (model.mensagem.Equals(""))
            {
                if (model.tem)
                {
                    frmMenu menu = new frmMenu();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Usuario ou senha incorreto");
                    txtUsuario.Text = "";
                    txtSenha.Text = "";
                    txtUsuario.Focus();
                }
            }
            
                
                    


        }
        //Limpar
        public void Limpar()
        {
            txtSenha.Text = "";
            txtUsuario.Text = "";
            txtUsuario.Focus();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //Validação do button Login
            ChamarLogin(usuario);

        }

        private void btnEntrar_KeyDown(object sender, KeyEventArgs e)
        {
          if(e.KeyCode == Keys.Enter)
            {
                ChamarLogin(usuario);
                
            }            
        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            pnlLogin.Location = new Point(this.Width / 2 - 166, this.Height / 2 - 170);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void Logar(usuarios dado)
        {
        }  
    }
}
