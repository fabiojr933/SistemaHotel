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
using System.IO;

namespace SistemaHoteleiro.Dao
{
    class ProdutosDAO
    {
        Connection con = new Connection();
        NpgsqlCommand sql;

        public DataTable carregarCombo()
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from fornecedores",con.con);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = sql;
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Carregar a combo box " + ex.Message);
                throw;
            }
        }
        public void salvar(produtos dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand(" INSERT INTO public.produtos(nome, descricao, grupo, " +
                    "setor, estoque, id_fornecedor," +
                    " valor_venda, valor_compra, data, nome_imagem, local_imagem)" +
                    " VALUES(@nome, @descricao, @grupo, @setor, @estoque, @id_fornecedor, @valor_venda, @valor_compra, " +
                    "@data, @nome_imagem, @local_imagem)",con.con);
                sql.Parameters.Add("@nome",dado.Nome);
                sql.Parameters.Add("@descricao",dado.Descricao);
                sql.Parameters.Add("@grupo",dado.Grupo);
                sql.Parameters.Add("@setor",dado.Setor);
                sql.Parameters.Add("@estoque",dado.Estoque);
                sql.Parameters.Add("@id_fornecedor",dado.IdFornecedor);
                sql.Parameters.Add("@valor_venda",dado.Venda);
                sql.Parameters.Add("@valor_compra",dado.ValorCompra);
                sql.Parameters.Add("@data",dado.Data);
                sql.Parameters.Add("@nome_imagem",dado.NomeImagem);
                sql.Parameters.Add("@local_imagem",dado.Oid);
                sql.ExecuteNonQuery();
                con.FecharConexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar " + ex.Message);
                throw;
            }
        }
        public DataTable listar()
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select a.id, a.nome, a.descricao, a.grupo, a.setor, a.estoque, a.id_fornecedor, a.valor_venda, a.data, b.nome " +
                    "from produtos a inner join fornecedores b on a.id_fornecedor = b.id order by a.id", con.con);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = sql;
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar " + ex.Message);
                throw;
            }
        }
        public void Editar(produtos dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("update produtos set nome = @nome, descricao = @descricao, grupo = @grupo, setor = @setor," +
                    " id_fornecedor = @id_fornecedor, valor_venda = @valor_venda, data = @data where id = @id",con.con);
                sql.Parameters.Add("@nome", dado.Nome);
                sql.Parameters.Add("@descricao", dado.Descricao);
                sql.Parameters.Add("@grupo", dado.Grupo);
                sql.Parameters.Add("@setor", dado.Setor);
                sql.Parameters.Add("@id_fornecedor", dado.IdFornecedor);
                sql.Parameters.Add("@valor_venda", dado.Venda);
                sql.Parameters.Add("@data", dado.Data);
                sql.Parameters.Add("@id", dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar " + ex.Message);
                throw;
            }
        }
        public void deletar(produtos dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("delete from produtos where id = @id", con.con);
                sql.Parameters.Add("@id",dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar " + ex.Message);
                throw;
            }
        }
        public DataTable pesquisar(produtos dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from produtos where nome LIKE @nome", con.con);
                sql.Parameters.Add("@nome",dado.Nome+"%");
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                adapter.SelectCommand = sql;
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar ");
                throw;
            }
        }
        //subir uma imagen para o banco de dados
        //private byte[] img()
        //{
        //    byte[] image_byte = null;
        //    if (foto == "")
        //    {
        //        return null;
        //    }
        //    FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read);
        //    BinaryReader br = new BinaryReader(fs);
        //    image_byte = br.ReadBytes((int)fs.Length);
        //    return image_byte;
        //}
    }
}
