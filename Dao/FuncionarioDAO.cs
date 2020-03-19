using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaHoteleiro.Entidades;
using Npgsql;
using SistemaHoteleiro.ConectaBanco;
using System.Data;
using System.Windows.Forms;

namespace SistemaHoteleiro.Dao
{
    public class FuncionarioDAO
    {
        NpgsqlCommand sql;
        Connection con = new Connection();

        public DataTable CarregarComboCargo()
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from cargos order by id asc", con.con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao carregar combo " + ex.Message);
                throw;
            }

        }
        public DataTable CarregarComboCidade()
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from municipio order by nome asc", con.con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao carregar combo " + ex.Message);
                throw;
            }
        }
        public DataTable CarregarComboEstado()
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from estado order by uf", con.con); 
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao carregar combo " + ex.Message);
                throw;
            }
        }
        public void CadastrarFuncionarios(funcionarios dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("insert into funcionarios (nome, cpf, endereco, telefone, bairro, " +
                    "id_cidade, id_uf, id_cargo, data) values (@nome, @cpf, @endereco, @telefone, @bairro, " +
                    "@id_cidade, @id_uf, @id_cargo, @data)", con.con);
                sql.Parameters.Add("@nome", dado.Nome);
                sql.Parameters.Add("@cpf", dado.Cpf);
                sql.Parameters.Add("@endereco", dado.Endereco);
                sql.Parameters.Add("@telefone", dado.Telefone);
                sql.Parameters.Add("@bairro", dado.Bairro);
                sql.Parameters.Add("@id_cidade", dado.Cidade);
                sql.Parameters.Add("@id_uf", dado.Uf);
                sql.Parameters.Add("@id_cargo", dado.IdCargo);
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
        public DataTable ListarFuncionarios()
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from funcionarios order by id asc", con.con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao listar funcionario " + ex.Message);
                throw;
            }
        }
        public void EditarCadastro(funcionarios dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("update funcionarios set nome = @nome, cpf = @cpf, endereco = @endereco, telefone =@telefone, bairro = @bairro, " +
                        "id_cidade = @id_cidade, id_uf = @id_uf, id_cargo = @id_cargo, data = @data where id = @id", con.con);
                sql.Parameters.Add("@nome", dado.Nome);
                sql.Parameters.Add("@cpf", dado.Cpf);
                sql.Parameters.Add("@endereco", dado.Endereco);
                sql.Parameters.Add("@telefone", dado.Telefone);
                sql.Parameters.Add("@bairro", dado.Bairro);
                sql.Parameters.Add("@id_cidade", dado.Cidade);
                sql.Parameters.Add("@id_uf", dado.Uf);
                sql.Parameters.Add("@id_cargo", dado.IdCargo);
                sql.Parameters.Add("@data", dado.Data);
                sql.Parameters.Add("@id", dado.Id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao editar funcionario " + ex.Message);
                throw;
            }
        }
        public void DeletarFuncionario(funcionarios dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("delete from funcionarios where id = @id", con.con);
                sql.Parameters.Add("@id", dado.Id);
                sql.ExecuteReader();
                con.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao excluir funcionario " + ex.Message);
                throw;
            }
        }
        public DataTable BuscarNome(funcionarios dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from funcionarios where nome like @nome", con.con);
                sql.Parameters.Add("@nome", dado.Nome+"%");
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao buscar nome " + ex.Message);
                throw;
            }
        }
        public DataTable buscarCpf(funcionarios dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new NpgsqlCommand("select * from funcionarios where cpf like @cpf", con.con);
                sql.Parameters.Add("@cpf", dado.Cpf+"%");
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao buscar cpf " + ex.Message);
                throw;
            }
        }
    }
}
