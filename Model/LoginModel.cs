using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaHoteleiro.Dao;
using SistemaHoteleiro.Model;
using SistemaHoteleiro.ConectaBanco;
using SistemaHoteleiro.Entidades;
using System.Data;

namespace SistemaHoteleiro.Model
{
    class LoginModel
    {
        LoginDAO dao = new LoginDAO();
        public bool tem = false;
        public string mensagem = "";
        public bool Logar(string login, string senha)
        {
            try
            {
                tem = dao.Logar(login, senha);
                if (!dao.mensagem.Equals(""))
                {
                    this.mensagem = dao.mensagem;
                }
                return tem;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable LoginCargo(Cargos dado)
        {
            try
            {
                DataTable table = new DataTable();
                table = dao.LoginCargo(dado);
                return table;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
