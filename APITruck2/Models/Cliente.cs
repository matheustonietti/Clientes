using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APITruck.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key()]
        public int Id { get; set;}    
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime? UltimoPedido { get; set; }
        public decimal ValorPendente { get; set; }
        public decimal ValorTotal { get; set; }
        public string Telefone { get; set; }
        public decimal Busto { get; set; }
        public decimal Torax { get; set; }
        public decimal Cintura { get; set; }
        public decimal Gluteo { get; set; }
        public decimal Coxa { get; set; }
        public decimal Canela { get; set; }
        public decimal ComprimentoPerna { get; set; }
        public decimal ComprimentoBraco { get; set; }
        public decimal CircBraco { get; set; }
        public decimal CircAnteBraco { get; set; }

    }
}
