using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaHoteleiro.ConectaBanco;
using SistemaHoteleiro.Entidades;
using Npgsql;
using System.Windows.Forms;
using System.Data;

namespace SistemaHoteleiro.Dao
{
    class CargoDAO
    {
        NpgsqlCommand sql;
        Connection con = new Connection();

        public void SalvarCargo(Cargos dado)   //Metedo salvar DAO
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("insert into cargos (cargo) values(@cargo)", con.con);
                sql.Parameters.Add("@cargo", dado.Cargo);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ops! Ocorreu uma falha ao salvar dados " + ex.Message);
                throw;
            }
        }
        public DataTable ListarDados() //metedo carregar dados DAO
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from cargos order by id asc", con.con);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = sql;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar dados " + ex.Message);
                throw;
            }
        }
        public void EditarCargo(Cargos dado) // metedo para ALTERAR um cargo
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("update cargos set cargo = @cargo where id = @id ", con.con);
                sql.Parameters.Add("@cargo", dado.Cargo);
                sql.Parameters.Add("@id", dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar dados " + ex.Message);
                throw;
            }
        }
        public void DeletarCargo(Cargos dado) // deletar cargo
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("delete from cargos where id = @id", con.con);
                sql.Parameters.Add("@id", dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao deletar " + ex.Message);
                throw;
            }
        }
    }
}
