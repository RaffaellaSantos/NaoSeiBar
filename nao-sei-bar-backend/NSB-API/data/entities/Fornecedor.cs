using Nao_Sei_Bar_Backend.src.data.entities;
using System.ComponentModel.DataAnnotations;

namespace NaoSeiBar.src.data.entities
{
    public class Fornecedor
    {
        [Key]
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public string Banco { get; set; }
        public string NumeroConta { get; set; }
        public string Agencia { get; set; }
        public bool StatusFornecedor { get; set; }
        public DateTime DataContratacao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
