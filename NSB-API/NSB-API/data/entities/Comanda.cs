using Nao_Sei_Bar_Backend.src.data.entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NaoSeiBar.src.data.entities
{
    public class Comanda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nomeVendedor { get; set; }
        public DateTime dataCompra { get; set; }
        public DateTime horarioCompra { get; set; }
        public Produto produto { get; set; }
        public int quantidade { get; set; }
        public double valorVenda { get; set; }
        public Cliente cliente { get; set; }
    }
}
