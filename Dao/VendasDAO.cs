using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using SistemaHoteleiro.ConectaBanco;
using SistemaHoteleiro.Entidades;

namespace SistemaHoteleiro.Dao
{
    public class VendasDAO
    {
        NpgsqlCommand sql;
        Connection con = new Connection();


        public void salvar(venda dados)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("INSERT INTO VENDAS (valor_total, id_funcionario, status, data_venda, vencimento) VALUES(@valortotal, @idfuncionario, @status, @datavenda, @vencimento", con.con);
                sql.Parameters.Add("@valortotal", dados.ValorTotal);
                sql.Parameters.Add("@idfuncionario", dados.Idfuncionario);
                sql.Parameters.Add("@status", dados.Status);
                sql.Parameters.Add("@datavenda", dados.DataVenda);
                sql.Parameters.Add("@vencimento", dados.Vencimento);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro " + ex.Message);
                throw;
            }

        }

    }
}
