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
    class ProdutosModel
    {
        ProdutosDAO dao = new ProdutosDAO();
        public DataTable carregarCombo()
        {
            try
            {
                DataTable table = new DataTable();
                table = dao.carregarCombo();
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar " + ex.Message);
                throw;
            }
        }
        public void salvar(produtos dado)
        {
            try
            {
                dao.salvar(dado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar " + ex.Message);
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
        public void Editar(produtos dado)
        {
            try
            {
                dao.Editar(dado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Editar " + ex.Message);
                throw;
            }
        }
        public void deletar(produtos dado)
        {
            try
            {
                dao.deletar(dado);
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
                DataTable table = new DataTable();
                table = dao.pesquisar(dado);
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pesquisar " + ex.Message);
                throw;
            }
        }
    }
}
