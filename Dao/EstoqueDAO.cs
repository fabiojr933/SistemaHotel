using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaHoteleiro.ConectaBanco;
using SistemaHoteleiro.Entidades;
using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace SistemaHoteleiro.Dao
{
    class EstoqueDAO
    {
        NpgsqlCommand sql;
        Connection con = new Connection();

        public DataTable carregarCombo()
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from fornecedores order by id", con.con);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = sql;
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao carregar " + ex.Message);
                throw;
            }
        }
        public DataTable Listar()
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select a.id, a.nome, b.nome, a.estoque, a.valor_compra, a.id_fornecedor from produtos a" +
                    " inner join fornecedores b on a.id_fornecedor = b.id ", con.con);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = sql;
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao listar " + ex.Message);
                throw;
            }
        }
        public void salvar(produtos dados)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("update produtos set estoque = @estoque, valor_compra = @valorCompra where id = @id", con.con);
                sql.Parameters.Add("@estoque", dados.Estoque);
                sql.Parameters.Add("@valorCompra", dados.ValorCompra);
                sql.Parameters.Add("@id", dados.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao salvar " + ex.Message);
                throw;
            }
        }
    }
}
