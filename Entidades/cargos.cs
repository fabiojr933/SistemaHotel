using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHoteleiro.Entidades
{
    public class Cargos
    {
        int id;
        string cargo;

        public int Id { get => id; set => id = value; }
        public string Cargo { get => cargo; set => cargo = value; }
    }
}
