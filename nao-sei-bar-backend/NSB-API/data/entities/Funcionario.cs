using Nao_Sei_Bar_Backend.src.data.enums;
using System.ComponentModel.DataAnnotations;

namespace NSB_API.data.entities
{
    public class Funcionario
    {
        [Key]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Funcao Funcao { get; set; }
        public double Salario { get; set; }
        public bool Status { get; set; }
        public DateTime DataContratacao { get; set; }
        public int CargaHorario { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
    }
}
