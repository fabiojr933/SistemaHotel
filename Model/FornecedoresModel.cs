using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaHoteleiro.Dao;
using SistemaHoteleiro.Entidades;


namespace SistemaHoteleiro.Model
{
    class FornecedoresModel
    {
		FornecedoresDAO dao = new FornecedoresDAO();
        public void cadastrarFornecedor(fornecedores dado)
        {
			try
			{
				dao.cadastrarFornecedor(dado);
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
			catch (Exception ex)
			{
				MessageBox.Show("Erro ao listar " + ex.Message);
				throw;
			}
		}
		public void Editar(fornecedores dado)
		{
			try
			{
				dao.Editar(dado);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro ao EDITAR" + ex.Message);
				throw;
			}
		}
		public void Deletar(fornecedores dado)
		{
			try
			{
				dao.Deletar(dado);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro ao deletar " + ex.Message);
				throw;
			}
		}
	}
}
