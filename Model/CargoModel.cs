using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaHoteleiro.ConectaBanco;
using SistemaHoteleiro.Entidades;
using Npgsql;
using System.Windows.Forms;
using SistemaHoteleiro.Dao;
using System.Data;

namespace SistemaHoteleiro.Model
{
    class CargoModel
    {
        CargoDAO dao = new CargoDAO();

        public void SalvarCargo(Cargos dados)  //Metedo salvar Model
        {
            try
            {
                dao.SalvarCargo(dados);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable ListarDados()  //metedo carregar dados model
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.ListarDados();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar dados " + ex.Message);
                throw;
            }
        }
        public void EditarCargo(Cargos dado) // metedo para ALTERAR um cargo
        {
            try
            {
                dao.EditarCargo(dado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar o casdastro "+ ex.Message);
                throw;
            }
        }
        public void DeletarCargo(Cargos dado) // deletar cargo
        {
            try
            {
                dao.DeletarCargo(dado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar " + ex.Message);
                throw;
            }
        }
    }
}
