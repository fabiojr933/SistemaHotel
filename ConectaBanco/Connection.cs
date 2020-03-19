using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace SistemaHoteleiro.ConectaBanco
{
    class Connection
    {
        string conexao = "SERVER=localhost;PORT=5432; DATABASE=SistemaHoteleiro; UID=postgres; PWD=postgres; Encoding=ASCII;";       
        public NpgsqlConnection con = null;       
        

        public void AbrirConexao()
        {
            try
            {
                con = new NpgsqlConnection(conexao);
                con.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void FecharConexao()
        {
            try
            {
                con = new NpgsqlConnection(conexao);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nao foi possivel Conectar no Banco de dados.. " + ex.Message);
                throw;
            }
        }
    }
}
