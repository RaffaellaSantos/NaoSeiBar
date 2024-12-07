using Nao_Sei_Bar_Backend.src.data.enums;
using NaoSeiBar.src.data.entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nao_Sei_Bar_Backend.src.data.entities
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set;  }
        public string Nome { get; set; }
        public Tipo Tipo { get; set; }
        public double ValorCompra { get; set; }
        public double ValorVenda { get; set; }
        public string Marca { get; set; }
        public int Quantidade { get; set; }
        public DateTime Validade { get; set; }
        public Lote Lote { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public DateTime DataEntrada { get; set; }
    }
}
