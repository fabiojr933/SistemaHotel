using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaHoteleiro.Entidades;
using SistemaHoteleiro.ConectaBanco;
using Npgsql;
using System.Windows.Forms;
using System.Data;

namespace SistemaHoteleiro.Dao
{
    public class ServicoDAO
    {
        Connection con = new Connection();
        NpgsqlCommand sql;

        public void CadastrarServico(servicos dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("insert into servicos (nome, valor) values (@nome, @valor)", con.con);
                sql.Parameters.Add("@nome", dado.Nome);
                sql.Parameters.Add("@valor", dado.Valor);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar Produtos " +ex.Message);
                throw;
            }
        }
        public DataTable ListarServicos()
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from servicos order by id asc ", con.con);
                NpgsqlDataAdapter dt = new NpgsqlDataAdapter();
                dt.SelectCommand = sql;
                DataTable da = new DataTable();
                dt.Fill(da);
                return da;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao listar Serviços" +ex.Message);
                throw;
            }
        }
        public void EditarServico(servicos dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("update servicos set nome = @nome, valor = @valor  where id = @id",con.con);
                sql.Parameters.Add("@nome", dado.Nome);
                sql.Parameters.Add("@valor", dado.Valor);
                sql.Parameters.Add("@id", dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao Editar Serviços" + ex.Message);
                throw;
            }
        }
        public void DeletarServico(servicos dado)
        {
            con.AbrirConexao();
            sql = new NpgsqlCommand("delete from servicos where id = @id",con.con);
            sql.Parameters.Add("@id", dado.Id);
            sql.ExecuteNonQuery();
            con.FecharConexao();
        }
    }
}
