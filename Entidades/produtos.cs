using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHoteleiro.Entidades
{
    public class produtos
    {
        int id;
        string nome;
        string descricao;
        string grupo;
        string setor;
        int estoque;
        int idFornecedor;
        decimal venda;
        decimal valorCompra;
        string nomeImagem;
        string oid;
        DateTime data;

        public string Nome { get => nome; set => nome = value; }
        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Grupo { get => grupo; set => grupo = value; }
        public string Setor { get => setor; set => setor = value; }
        public int Estoque { get => estoque; set => estoque = value; }
        public decimal Venda { get => venda; set => venda = value; }
        public decimal ValorCompra { get => valorCompra; set => valorCompra = value; }
        public string NomeImagem { get => nomeImagem; set => nomeImagem = value; }        
        public DateTime Data { get => data; set => data = value; }
        public int IdFornecedor { get => idFornecedor; set => idFornecedor = value; }
        public string Oid { get => oid; set => oid = value; }
    }
}
