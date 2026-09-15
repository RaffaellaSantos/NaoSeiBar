using Nao_Sei_Bar_Backend.src.data.enums;
using System.ComponentModel.DataAnnotations;

namespace NSB_API.data.dtos
{
    public class FuncionarioDto
    {
        [Required(ErrorMessage = "Campo é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido.")]
        public required string Cpf { get; set; }
        public required string Nome { get; set; }
        public required DateTime DataNascimento { get; set; }
        public required Funcao Funcao { get; set; }
        public required double Salario { get; set; }
        public required bool Status { get; set; }
        public required DateTime DataContratacao { get; set; }
        public required int CargaHorario { get; set; }
        public required string Telefone { get; set; }
    }
}
