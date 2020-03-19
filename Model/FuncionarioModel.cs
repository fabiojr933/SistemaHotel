using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaHoteleiro.Dao;
using SistemaHoteleiro.Model;
using SistemaHoteleiro.Entidades;
using System.Windows.Forms;
using System.Data;

namespace SistemaHoteleiro.Model
{
    public class FuncionarioModel
    {
        FuncionarioDAO dao = new FuncionarioDAO();

        public DataTable carregarComboCargo()
        {
            try
            {                
                DataTable dt = new DataTable();
                dt = dao.CarregarComboCargo();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao carregar combo " + ex.Message); 
                throw;
            }
        }
        public DataTable CarregarComboCidades()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.CarregarComboCidade();
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
                DataTable da = new DataTable();
                da = dao.CarregarComboEstado();
                return da;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void CadastrarFuncionarios(funcionarios dado)
        {
            try
            {
                dao.CadastrarFuncionarios(dado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao cadastrar funcionarios" + ex.Message);
                throw;
            }
        }
        public DataTable ListarFuncionarios()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.ListarFuncionarios();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void EditarCadastro(funcionarios dado)
        {
            try
            {
                dao.EditarCadastro(dado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao editar funcionario" + ex.Message);
                throw;
            }
        }
        public void DeletarFuncionario(funcionarios dado)
        {
            try
            {
                dao.DeletarFuncionario(dado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro ao excluir funcionario" + ex.Message);
                throw;
            }
        }
        public DataTable BuscarNome(funcionarios dado)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.BuscarNome(dado);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable buscarCpf(funcionarios dado)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.buscarCpf(dado);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
