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
    public class ServicoModel
    {

		ServicoDAO dao = new ServicoDAO();
        public void CadastrarServico(servicos dado)
        {
			try
			{
				dao.CadastrarServico(dado);
				MessageBox.Show("Serviço cadastrado com sucesso");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Erro ao cadastrar Produtos " + ex.Message);
				throw;
			}
        }
		public DataTable ListarServicos()
		{
			try
			{
				DataTable da = new DataTable();
				da = dao.ListarServicos();
				return da;
			}
			catch (Exception ex)
			{
				MessageBox.Show("erro ao listar " +ex.Message);
				throw;
			}
		}
		public void EditarServico(servicos dado)
		{
			try
			{
				dao.EditarServico(dado);
			}
			catch (Exception ex)
			{
				MessageBox.Show("erro ao editar " + ex.Message);
				throw;
			}
		}
		public void DeletarServicos(servicos dado)
		{
			try
			{
				dao.DeletarServico(dado);
			}
			catch (Exception ex)
			{
				MessageBox.Show("erro ao excluir " + ex.Message);
				throw;
			}
		}
	}
}
