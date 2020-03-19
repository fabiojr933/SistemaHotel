using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHoteleiro.Entidades
{
    public class funcionarios
    {
        int id;
        string nome;
        string cpf;
        string endereco;
        string telefone;
        string bairro;
        int idCargo;       
        int uf;
        DateTime data;
        int cidade;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Bairro { get => bairro; set => bairro = value; }       
        public DateTime Data { get => data; set => data = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public int IdCargo { get => idCargo; set => idCargo = value; }
        public int Uf { get => uf; set => uf = value; }
        public int Cidade { get => cidade; set => cidade = value; }
    }
}
