using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using SistemaHoteleiro.ConectaBanco;
using SistemaHoteleiro.Entidades;

namespace SistemaHoteleiro.Dao
{
    class UsuarioDAO
    {
        NpgsqlCommand sql;
        Connection con = new Connection();

        public DataTable carregarCargo()
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from cargos order by id", con.con);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = sql;
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("falha a buscar " + ex.Message);
                throw;
            }
        }
        public void salvarUsuario(usuarios dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("insert into usuario (cargo, usuario, senha, data) values (@cargo, @usuario, @senha, @data)", con.con);
                sql.Parameters.Add("@cargo", dado.Cargo);
                sql.Parameters.Add("@usuario", dado.Usuario);
                sql.Parameters.Add("@senha", dado.Senha);
                sql.Parameters.Add("@data", dado.Data);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao cadastrar funcionarios " + ex.Message);
                throw;
            }
        }
        public void atualizar(usuarios dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("update usuario set cargo = @cargo, usuario = @usuario," +
                    "senha = @senha, data = @data where id = @id", con.con);
                sql.Parameters.Add("@cargo", dado.Cargo);
                sql.Parameters.Add("@usuario", dado.Usuario);
                sql.Parameters.Add("@senha", dado.Senha);
                sql.Parameters.Add("@data", dado.Data);
                sql.Parameters.Add("@id", dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao atualizar " + ex.Message);
                throw;
            }
        }
        public DataTable listar()
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from usuario order by id asc", con.con);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = sql;
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao atualizar " + ex.Message);
                throw;
            }
        }
        public void deletar(usuarios dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("delete from usuario where id = @id", con.con);
                sql.Parameters.Add("@id", dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao deletar " + ex.Message);
                throw;
            }
        }
        public DataTable pequisar(usuarios dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from usuario where usuario LIKE @usuario", con.con);
                sql.Parameters.Add("@usuario",dado.Usuario+"%");
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = sql;
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao consultar " + ex.Message);
                throw;
            }
        } 
    }
}
