using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using SistemaHoteleiro.Entidades;
using SistemaHoteleiro.ConectaBanco;
using System.Data;
using System.Windows.Forms;

namespace SistemaHoteleiro.Dao
{
    class LoginDAO
    {
        NpgsqlCommand sql;
        Connection con = new Connection();
        public bool tem = false;
        public string mensagem = "";

        public bool Logar(string login, string senha)
        
        {
            try
            {
                tem = false;
                con.AbrirConexao();                
                sql = new NpgsqlCommand("select * from usuario where usuario = @usuario and senha = @senha", con.con);
                sql.Parameters.Add("@usuario", login);
                sql.Parameters.Add("@senha", senha);
                NpgsqlDataReader dr;
                dr = sql.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Program.nomeUsuario = Convert.ToString(dr["usuario"]);
                        Program.cargoUsuario = Convert.ToString(dr["cargo"]);                       
                    }

                    tem = true;
                    con.FecharConexao();
                    dr.Close();
                }               
            }
            
            catch (Exception)
            {
                MessageBox.Show("Usuario ou senhas Incorretos ");
                
            }
            return tem;
        }   
        public DataTable LoginCargo(Cargos dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from cargos where id = @id", con.con);
                sql.Parameters.Add("@id",Program.cargoUsuario);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = sql;
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro " + ex.Message);
                throw;
            }
        }
    }
}
