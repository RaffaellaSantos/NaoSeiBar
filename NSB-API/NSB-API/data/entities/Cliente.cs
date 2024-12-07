using System.ComponentModel.DataAnnotations;

namespace NaoSeiBar.src.data.entities
{
    public class Cliente
    {
        [Key]
        public string cpf { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public DateTime dataNascimento { get; set; }
    }
}
