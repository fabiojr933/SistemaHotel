using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHoteleiro.Entidades
{
    public class usuarios
    {
        int id;       
        int cargo;
        string usuario;
        string senha;
        DateTime data;

        public int Id { get => id; set => id = value; }     
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }
        public DateTime Data { get => data; set => data = value; }
        public int Cargo { get => cargo; set => cargo = value; }
    }
}
