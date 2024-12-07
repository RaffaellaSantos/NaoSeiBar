using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NaoSeiBar.src.data.entities
{
    public class Lote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public DateTime DataFornecimento { get; set; }
        public string Descricao { get; set; }
        public double ValorTotal { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
