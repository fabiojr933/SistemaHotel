using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaHoteleiro.Dao;
using SistemaHoteleiro.Entidades;

namespace SistemaHoteleiro.Model
{
    public class VendasModel
    {
        VendasDAO dao = new VendasDAO();

        public void salvar(venda dado)
        {
            try
            {
                dao.salvar(dado);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
