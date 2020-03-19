using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaHoteleiro.ConectaBanco;
using SistemaHoteleiro.Dao;
using SistemaHoteleiro.Entidades;
using Npgsql;
using System.Data;
using System.Windows.Forms;


namespace SistemaHoteleiro.Model
{
    class UsuarioModel
    {
		UsuarioDAO dao = new UsuarioDAO();

        public DataTable carregarCargo()
        {
			try
			{
				DataTable table = new DataTable();
				table = dao.carregarCargo();
				return table;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Falha ao buscar " + ex.Message);
				throw;
			}
        }
		public void salvarUsuario(usuarios dado)
		{
			try
			{
				dao.salvarUsuario(dado);
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
				DataTable table = new DataTable();
				table = dao.listar();
				return table;
			}
			catch (Exception)
			{

				throw;
			}
		}
		public void editar(usuarios dado)
		{
			try
			{
				dao.atualizar(dado);
			}
			catch (Exception ex)
			{
				MessageBox.Show("erro ao atualizar os dados " + ex.Message);
				throw;
			}
		}
		public void deletar(usuarios dado)
		{
			try
			{
				dao.deletar(dado);
			}
			catch (Exception ex)
			{
				MessageBox.Show("erro ao excluir os dados " + ex.Message);
				throw;
			}
		}
		public DataTable pequisar(usuarios dado)
		{
			DataTable table = new DataTable();
			table = dao.pequisar(dado);
			return table;
		}
	}
}
