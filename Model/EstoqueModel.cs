using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaHoteleiro.Dao;
using SistemaHoteleiro.Entidades;

namespace SistemaHoteleiro.Model
{
    class EstoqueModel
    {
        EstoqueDAO dao = new EstoqueDAO();

        public DataTable carregarCombo()
        {
            try
            {
                DataTable table = new DataTable();
                table = dao.carregarCombo();
                return table;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Listar()
        {
            try
            {
                DataTable table = new DataTable();
                table = dao.Listar();
                return table;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void salvar(produtos dados)
        {
            try
            {
                dao.salvar(dados);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
