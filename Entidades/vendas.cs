using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHoteleiro.Entidades
{
    public class venda
    {
        int id;
        decimal valorTotal;
        int idfuncionario;
        int estoque;
        char status;
        DateTime dataVenda;
        DateTime vencimento;

        public int Id { get => id; set => id = value; }
        public decimal ValorTotal { get => valorTotal; set => valorTotal = value; }
        public int Idfuncionario { get => idfuncionario; set => idfuncionario = value; }
        public char Status { get => status; set => status = value; }
        public DateTime DataVenda { get => dataVenda; set => dataVenda = value; }
        public DateTime Vencimento { get => vencimento; set => vencimento = value; }
        public int Estoque { get => estoque; set => estoque = value; }
    }
}
