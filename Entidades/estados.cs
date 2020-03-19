using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHoteleiro.Entidades
{
    public class estados
    {
        int id;
        int codigoUf;
        string nome;
        string uf;
        int regiao;

        public int Id { get => id; set => id = value; }
        public int CodigoUf { get => codigoUf; set => codigoUf = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Uf { get => uf; set => uf = value; }
        public int Regiao { get => regiao; set => regiao = value; }
    }
}
