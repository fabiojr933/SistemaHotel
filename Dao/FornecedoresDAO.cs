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
    class FornecedoresDAO

    {
        NpgsqlCommand sql;
        Connection con = new Connection();

        public void cadastrarFornecedor(fornecedores dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("insert into fornecedores (nome, endereco, telefone) values(@nome, @endereco, @telefone)", con.con);
                sql.Parameters.Add("@nome", dado.Nome);
                sql.Parameters.Add("@endereco", dado.Endereco);
                sql.Parameters.Add("@telefone", dado.Telefone);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao cadastrar " + ex.Message);
                throw;
            }
        }
        public DataTable listar()
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from fornecedores order by id asc", con.con);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = sql;
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu algum erro ao listar " + ex.Message);
                throw;
            }
        } 
        public void Editar(fornecedores dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("update fornecedores set nome = @nome, endereco = @endereco, telefone = @telefone where id = @id", con.con);
                sql.Parameters.Add("@nome",dado.Nome);
                sql.Parameters.Add("@endereco",dado.Endereco);
                sql.Parameters.Add("@telefone",dado.Telefone);
                sql.Parameters.Add("@id",dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao EDITAR " + ex.Message);
                throw;
            }
        }
        public void Deletar(fornecedores dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("delete from fornecedores where id = @id", con.con);
                sql.Parameters.Add("@id", dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar ", ex.Message);
                throw;
            }
        }
    }
}
